const { chromium } = require('playwright-chromium');

const { expect } = require('chai');

const mockData = require('./mockData.json');

const url = 'http://127.0.0.1:5500/index.html';

function json(data) {
    return {
        status: 200,
        headers: {
            'Access-Control-Allow-Origin': '*',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(data)
    };
}

let browser, page; // Declare reusable variables

describe('E2E tests', function () {
    this.timeout(20000);
    before(async () => {
        // browser = await chromium.launch({ headless: false, slowMo: 1000 });
        browser = await chromium.launch(); 
    });

    after(async () => { await browser.close(); });

    beforeEach(async () => {
        page = await browser.newPage();
    });

    afterEach(async () => { await page.close(); });


    describe('load titles', () => {
        it('should call server', async () => {

            await page.route('**/jsonstore/collections/books', route =>
                route.fulfill(json(mockData)));
            await page.goto(url);

            const [response] = await Promise.all([
                page.waitForResponse('**/jsonstore/collections/books'),
                page.click('#loadBooks')
            ]);
            let result = await response.json();
            expect(result).to.eql(mockData);
        })
    });
    describe('add new book', () => {
        it('should work correctly with valid data', async () => {
            await page.route('**/jsonstore/collections/books', route =>
                route.fulfill(json({"title":"something","author":"someone"})));

            await page.goto(url);

            await page.fill('#createForm input[name="title"]','something');
            await page.fill('#createForm input[name="author"]','someone');
            
            const [request] = await Promise.all([
                page.waitForRequest(request => request.method() == 'POST'),
                page.click('text="Submit"'),
            ])

            const postData = JSON.parse(request.postData());
            expect(postData.title).to.equal('something');
            expect(postData.author).to.equal('someone');          
        })
    })
    describe('edit book', () => {
        it('should work correctly with valid data', async () => {
            await page.route('**/jsonstore/collections/books', route =>
                route.fulfill(json(mockData)));
            await page.goto(url);
            await page.click('#loadBooks');
            await page.click('table tbody tr .editBtn')
            

            await page.fill('#editForm input[name="title"]','something');
            await page.fill('#editForm input[name="author"]','someone');
            
            const [request] = await Promise.all([
                page.waitForRequest(request => request.method() == 'PUT'),
                page.click('text="Save"'),
            ]);
            const postData = JSON.parse(request.postData());
            expect(postData.title).to.equal('something');
            expect(postData.author).to.equal('someone');
            

            await page.click('#loadBooks');
        });
    })
    describe('delete book', () => {
        it('should work correctly', async () => {
            await page.route('**/jsonstore/collections/books', route =>
                route.fulfill(json(mockData)));
            await page.goto(url);
            await page.click('#loadBooks');
            await page.click('table tbody tr .deleteBtn');
            expect(mockData).to.eql(mockData);
        });
    })
});