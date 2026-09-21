# README

Ramp up / learning project for .NET 10 and the Core Web API with the minimal API approach. Includes C#/SQL/EF8/Xunit/Moq/Swagger.

The front-end by AI and the back-end is organic.

My wife is a veterinarian so this practice project uses pet appointments instead of the usual todos.

Front-end displays these fields for each appointment:
Appt ID
Appt Date (and time)
Pet Name
Owner Name
Owner Address

| API                        | Description                                            | Request Body | Response Body  |
| -------------------------- | ------------------------------------------------------ | ------------ | -------------- |
| GET /appointments          | Assumes one vet or clinic                              | none         | array of appts |
| GET /appointments/upcoming | Appointments from today and later                      | none         | array of appts |
| GET /appointments/{id}     | Get just one appointment                               | none         | appt           |
| POST /appointments         | Create new appointment with data but not ID            | appt         | appt           |
| PUT /appointments/{id}     | Update all fields of existing appointment              | appt         | none           |
| PATCH /todoitems/{id}      | Update part of appointment, blank fields are ignored   | partial appt | none           |
| DELETE /appointments/{id}  | Remove appointment from database                       | none         | none           |


# System / Front-end testing with with Cucumber-js and Selenium

I get a lot of joy out of cucumber and behavior-driven development so it's included here, but not currently wired up at the time of writing.

Steps to enable:
1. add node & npm
3. run `npm install --save-dev @cucumber/cucumber selenium-webdriver` to install the test framework (cucumber) and the browser driver (selenium)
4. Add/edit the package.json so that the test script calls cucumber-js:
```
  "scripts": {
    "test": "cucumber-js"
  },
```
5. `npm test` to run the smoke test which will test and pass two scenarios against a selenium test page
6. Customize features/smoke_test.features to match this site's heading and menu, change the domain in features/support/world.js to match this domain, and then re-run `npm test` to confirm they pass
7. Add new scenarios want to test into features/smoke_test.feature with [Gherkin keywords](https://cucumber.io/docs/gherkin/reference), adding new feature files into the folder and wiring them up with new steps in features/step_definitions.
