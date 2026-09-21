const {setWorldConstructor, World } = require('@cucumber/cucumber');
const {Builder, Browser} = require('selenium-webdriver');
const Chrome = require('selenium-webdriver/chrome');
const coptions = new Chrome.Options();

// Runs around every scenario, providing this as a reference to the scenario
class CustomWorld extends World {
    // exclude enable-logging (turns off logging) to avoid non-test-related output from Chrome
    driver = new Builder()
        .forBrowser(Browser.CHROME)
        .setChromeOptions(coptions.excludeSwitches('enable-logging'))
        .build();
    
    domain = "https://www.selenium.dev"

    constructor(options) {
        super(options)
    }
    
    async getPage(page) {
        return await this.driver.get(page);
    }
}
setWorldConstructor(CustomWorld);
