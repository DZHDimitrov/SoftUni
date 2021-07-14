const { chromium } = require('playwright-chromium');

const { expect,assert } = require('chai');

let browser, page; // Declare reusable variables

describe('E2E tests', function () {
    this.timeout(6000);
    before(async () => {
        browser = await chromium.launch({headless:false,slowMo:500});
    });

    after(async () => {
        await browser.close();
    });

    beforeEach(async () => {
        page = await browser.newPage();
    });

    afterEach(async () => {
        await page.close();
    });

    it.only('loads static page', async () => {
        await page.goto('http://localhost:3000/');
        
        const titles = await page.$$eval('.accordion div span',(spans) => spans.map(x=>x.textContent));
        expect(titles).includes('Scalable Vector Graphics');
        expect(titles).includes('Open standard');
        expect(titles).includes('Unix');
        expect(titles).includes('ALGOL');
    });

    it('toggles content', async() => {
        await page.goto('http://localhost:3000/');

        await page.click('#main>.accordion:first-child >> text=More');

        const visible = await page.isVisible('#main>.accordion:first-child >> .extra p');
        expect(visible).to.be.true;
    })
    it('toggles content', async() => {
        await page.goto('http://localhost:3000/');

        await page.click('#main>.accordion:first-child >> text=More');
        await page.click('#main>.accordion:first-child >> text=Less');

        const visible = await page.isVisible('#main>.accordion:first-child >> .extra p');
        expect(visible).to.be.false;
    })
});