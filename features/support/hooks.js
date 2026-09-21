var {After, Before} = require('@cucumber/cucumber');

// Asynchronous Promise
After(function () {
  // Assuming this.driver is a selenium webdriver
  return this.driver.quit();
});