
# Weather app
This application serves as a template of a typical .net core API implementation with CQRS (using MediatR, repository and unit of work pattern), EF core with SQLite database and use of popular nugets (FluentValidation, Automapper, Swagger)

This API lets user get/store/delete latest info about weather for provided coordinates. It uses https://api.open-meteo.com for weather forecast info. If external service is unavailable API provides latest data that is stored in DB for given coordinates.






## Tech Stack

**API:** .NET Core 8
**DB:** SQLite + EF
**Others:** MediatR, Automapper, FluentValidation, Swagger


## Run Locally

Clone the project + run in visual studio;
Swagger documentation will open automatically
