const { chromium } = require('playwright-chromium');
const { expect } = require('chai');
 
let browser, page; // Declare reusable variables
let clientUrl = 'http://127.0.0.1:5500/01.Messenger/index.html'
 
function myResponse(data) {
    return {
        status: 200,
        headers: {
            'Access-Control-Allow-Origin': '*',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(data),
    }
}
 
let myTestMessages = {
    1: {
        author: 'Harry',
        content: 'Messaage from Harry'
    },
    2: {
        author: 'Alan',
        content: 'Message from Alan'
    }
}
 
describe('E2E tests', function () {
    this.timeout(6000);
    before(async () => { 
        browser = await chromium.launch( { headless: false, slowMo: 1000}); 
        // browser = await chromium.launch(); 
    });
    after(async () => { await browser.close(); });
    beforeEach(async () => { page = await browser.newPage(); });
    afterEach(async () => { await page.close(); });
 
    describe('load messages', () => {
        it('should call server', async () => {
            await page.route('**/jsonstore/messenger', route => {
                route.fulfill(myResponse(myTestMessages))
            });
 
            await page.goto(clientUrl);
 
            const [response] = await Promise.all([
                page.waitForResponse('**/jsonstore/messenger'),
                page.click('#refresh')
            ]);
            let result = await response.json();
            expect(result).to.eql(myTestMessages);
        });
 
        it('should show data in text area', async () => {
            await page.route('**/jsonstore/messenger', route => {
                console.log(1);
                route.fulfill(myResponse(myTestMessages))
            });
 
            await page.goto(clientUrl);
 
            const [response] = await Promise.all([
                page.waitForResponse('**/jsonstore/messenger'),
                page.click('#refresh')
            ]);
            
            let textAreaText = await page.$eval('#messages', (textArea) => textArea.value);
 
            let text = Object.values(myTestMessages).map(v => `${v.author}: ${v.content}`).join('\n');
            expect(textAreaText).to.eql(text);
        });
    })
});