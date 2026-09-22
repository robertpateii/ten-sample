# README

Ramp up / learning project for .NET 10 and the Core Web API with the minimal API approach. Includes C#/SQL/EF8/Scalar. Next is adding Xunit and Moq.

The front-end by AI and the back-end is organic.

I've many pets so this practice project uses pet appointments instead of the usual todos, and assumes there's just one vet or clinic for the sake of scope.

Front-end displays these fields for each appointment:
Appt ID
Appt Date (and time)
Pet Name
Owner Name
Owner Address

| API                        | Description                                            | Request Body | Response Body  |
| -------------------------- | ------------------------------------------------------ | ------------ | -------------- |
| GET /appointments          | Show all appointments in system                        | none         | array of appts |
| GET /appointments/upcoming | Appointments from today and later                      | none         | array of appts |
| GET /appointments/{id}     | Get just one appointment                               | none         | appt           |
| POST /appointments         | Create new appointment with data but not ID            | appt         | appt           |
| PUT /appointments/{id}     | Update all fields of existing appointment              | appt         | none           |
| PATCH /todoitems/{id}      | Update part of appointment, blank fields are ignored   | partial appt | none           |
| DELETE /appointments/{id}  | Remove appointment from database                       | none         | none           |

## Build Dependencies
.NET 10 SDK, VS Code, and C# Dev Kit for VS Code

## Debug / Local Testing
* In VS Code, start with or without debug
* Outside it, use `dotnet run --launch-profile http` or `dotnet run --launch-profile https`
* Add /scalar/v1 to the debug server domain to explore/test the API with Scalar

## Todo
- [ ] wire up front-end - almost there just need a create button or create default appointments for debug
- [ ] add unit tests with Moq
- [ ] update endpoints with MapGroup to DRY and TypedResults
- [ ] the ID is a good case for data transfer object, FE should not be supplying it
- [ ] Add cucumber support of some sort, Reqnroll, Xunit.Gherkin.Quick, compare to cucumber-js or cucumber-js compare to cucumber-js that I normally use