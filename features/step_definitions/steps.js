const { Given, When, Then } = require('@cucumber/cucumber');
const {Builder, By, Until, error} = require('selenium-webdriver');
const assert = require('assert');

When('the user visits {string}', async function (path) {
    this.getPage(this.domain + path);
});

Then('the {string} contains the text {string}', async function (inputElement, inputText) {
    let text = await this.driver.findElement(By.css(inputElement)).getText();
    assert(text.toString() === inputText);
});

Then('the link to {string} is within {string}', async function (path, cssClass) {
    let parent = await this.driver.findElement(By.className(cssClass));

    // Find the child element containing the link under test
    try {
        let ele = await parent.findElement(By.css('[href="' + path + '"]'));
    } catch (e) {
        if (e instanceof error.NoSuchElementError) {
            throw new Error("No element was found with " + path + " as the path.");
        } else {
            throw e;
        }
    }
});
