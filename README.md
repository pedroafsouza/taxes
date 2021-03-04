## Taxes

This solutions implements a minimal Tax schdules via web api.

## Usage

With [docker](https://docker.com/) installed, run to build:

    $ docker-compose up

## Why?

The project was created as a part of the interview process for Dansk Bank. It aims to simulate some daily activities of a sofware development in the company.

## Running swagger

We are using Swagger for easier documentation and to allow us to call the api easier.

Access the webpage from any browser:

```
    https://localhost:5000/swagger/
```

All documentation necessary for the endpoints should be in the swagger page.

![alt text](https://github.com/pedroafsouza/taxes/blob/main/assets/swagger.png?raw=true)

## Architecture

The architecture is simple, the client sends a message to controllers and the controllers publish the message for RabitMQ that later on is capable to process every message and perform a calculation.


## Overview

### Domain

This will contain all entities, enums, exceptions, interfaces, types and logic specific to the domain layer.

### Application

This layer contains all application logic. It is dependent on the domain layer, but has no dependencies on any other layer or project. This layer defines interfaces that are implemented by outside layers. For example, if the application need to access a notification service, a new interface would be added to application and an implementation would be created within infrastructure.

### Infrastructure

This layer contains classes for accessing external resources such as file systems, web services, smtp, and so on. These classes should be based on interfaces defined within the application layer.

### webapi

This layer is a single page application based on Angular 10 and ASP.NET Core 5. This layer depends on both the Application and Infrastructure layers, however, the dependency on Infrastructure is only to support dependency injection. Therefore only *Startup.cs* should reference Infrastructure.


## Acknowledgments of problems

- I would introduce a better logger platform for the project like logstash or kibana.
- I would never use passwords in the code as I have done here. Instead, I would setup using builds like github actions, azureDevops actions and pass it as environment variables.

## License

MIT