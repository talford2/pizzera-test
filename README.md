# pizzera

This project represents the front (React TypeScript App) and back end (.Net API) for a pizzeria ordering system.

## Run API
Open the solution **Pizzeria.Api.sln**, build and run

## Run UI
Open the inner **pizzeria** folder and ```run npm i```, followed by ```npm start```

## Notes
This project demonstrates using a fake relational SQL datatbase, there is a repository layer with DTO models that represents a normalised database, there is then a Business layer which utilises this via abstraction and dependency injection, the API then simply calls into the business services again using abstraction and dependency injection.

The front end consumes the API via PizzeriaService using TypeScript so strongly typed objects can be used throughout the React app.
