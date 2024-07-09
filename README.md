<img src="IMS.svg" alt="Probable Folder Structure">

Creating a well-organized folder structure in our ASP.NET Core project is essential for maintaining clean code, promoting separation of concerns, and making it easier for team members to navigate the project. The structure we provided follows the principles of Clean Architecture, which helps in organizing the project into distinct layers.

Here’s a detailed explanation of each part of the structure:

### Root Level

- **/IMS**: The root directory of our project. This contains all the source code, configurations, and other resources needed for our application.


### src/Application

In the **Application** layer, we keep all application logic. This layer contains the following subfolders:

- **Commands**: Handlers for commands following the CQRS (Command Query Responsibility Segregation) pattern.
- **Queries**: Handlers for queries, also following the CQRS pattern.
- **Interfaces**: Interfaces for application services, promoting loose coupling.
- **Mapping**: Profiles for mapping entities to DTOs and vice versa, often using tools like AutoMapper.

### src/Domain

The **Domain** layer houses the core business logic and rules of our application:

- **Entities**: Domain models representing the core business entities.
- **Repositories**: Interfaces for the repositories used to access data.
- **Services**: Domain services that encapsulate business logic.
- **Exceptions**: Custom exceptions specific to the domain layer.

### src/Infrastructure

The **Infrastructure** layer implements the interfaces defined in the Domain layer and handles cross-cutting concerns:

- **Persistence**: Database context and migrations using tools like Entity Framework Core.
- **Repositories**: Concrete implementations of repository interfaces.
- **Services**: Implementations of external services (e.g., email, third-party APIs).
- **Identity**: Logic related to authentication and authorization.
- **Logging**: Logging configurations.
- **Extensions**: Extension methods for various purposes.

### src/Presentation

The **Presentation** layer is our entry point for user interactions, specifically for our Web API:

- **Controllers**: API controllers that handle HTTP requests and responses.
- **Filters**: Action filters for cross-cutting concerns like exception handling and logging.
- **Models**: DTOs (Data Transfer Objects) and view models used in API requests and responses.
- **Startup**: Configuration files for setting up services and middleware.
- **Extensions**: Extension methods to keep configuration files clean.

### src/Clients

The **Clients** folder contains the client-side applications, organized by technology:

- **MVC**: An ASP.NET MVC client.
  - **Controllers**: MVC controllers.
  - **Views**: Razor views.
  - **Models**: View models.
  - **wwwroot**: Static files for the MVC client.
  - **Startup.cs**: MVC-specific startup configuration.

- **Angular**: An Angular client.
  - **src**: Source code for the Angular application.
    - **app**: Angular components, services, etc.
    - **assets**: Static assets.
    - **environments**: Environment-specific configurations.
    - **index.html**: Main HTML file for the Angular application.
  - **angular.json**: Angular CLI configuration.
  - **package.json**: NPM dependencies.
  - **tsconfig.json**: TypeScript configuration.

### src/Tests

The **Tests** folder includes unit tests and integration tests to ensure the reliability of our application.

### wwwroot

The **wwwroot** folder is used for static files that are served directly by the web server, if applicable.

---

We hope this detailed breakdown helps you understand our project's structure and the purpose of each folder. If you have any questions or need further clarification, feel free to reach out!
