<img src="IMS.svg" alt="Probable Folder Structure">

Creating a well-organized folder structure in our ASP.NET Core project is essential for maintaining clean code, promoting separation of concerns, and making it easier for team members to navigate the project. The structure we provided follows the principles of Clean Architecture, which helps in organizing the project into distinct layers.

# IMS (Inventory Management System)

Welcome to the IMS (Inventory Management System) project! This repository contains the source code and documentation for our comprehensive inventory management solution. Below, we'll guide you through the folder structure of our project to help you understand its organization and facilitate contributions.

## Project Structure

Our project is organized into several key directories, each serving a specific purpose. Here's a detailed overview of the folder structure:

```
/IMS
│
├── src
│   ├── Application               // Application layer
│   │   ├── Commands              // Command handlers (CQRS pattern)
│   │   ├── Queries               // Query handlers (CQRS pattern)
│   │   ├── Interfaces            // Interfaces for application services
│   │   └── Mapping               // Mapping profiles (e.g., AutoMapper)
│   │
│   ├── Domain                    // Domain layer
│   │   ├── Entities              // Domain models/entities
│   │   ├── Repositories          // Interfaces for repositories
│   │   ├── Services              // Domain services
│   │   └── Exceptions            // Custom domain exceptions
│   │
│   ├── Infrastructure            // Infrastructure layer
│   │   ├── Persistence           // Database context and migrations
│   │   ├── Repositories          // Implementations of repositories
│   │   ├── Services              // External services (e.g., email service)
│   │   ├── Identity              // Authentication and authorization logic
│   │   ├── Logging               // Logging configurations
│   │   └── Extensions            // Extension methods
│   │
│   ├── Presentation              // Presentation layer (Web API)
│   │   ├── Controllers           // API controllers
│   │   ├── Filters               // Action filters (e.g., exception handling)
│   │   ├── Models                // DTOs and view models
│   │   ├── Startup               // Configuration (e.g., Startup.cs)
│   │   └── Extensions            // Extension methods for IServiceCollection, etc.
│   │
│   ├── Clients                   // Clients (MVC or Angular)
│   │   ├── MVC                   // MVC Client
│   │   │   ├── Controllers       // MVC controllers
│   │   │   ├── Views             // Razor views
│   │   │   ├── Models            // View models
│   │   │   ├── wwwroot           // Static files for MVC
│   │   │   └── Program.cs        // MVC Startup configuration
│   │   │
│   │   └── Angular               // Angular Client
│   │       ├── src               // Source code for Angular application
│   │       │   ├── app           // Angular components, services, etc.
│   │       │   ├── assets        // Static assets for Angular
│   │       │   ├── environments  // Environment configurations
│   │       │   └── index.html    // Main HTML file for Angular
│   │       │
│   │       ├── angular.json      // Angular CLI configuration
│   │       ├── package.json      // NPM dependencies
│   │       └── tsconfig.json     // TypeScript configuration
│   │
│   └── Tests                     // Unit tests, integration tests
│
└── wwwroot                       // Static files (if applicable)
```

### Folder Descriptions

#### /src

The `src` directory contains all the source code for our project. It's organized into several subdirectories representing different layers and components of the application.

- **Application**: This layer contains the business logic and application services.
  - **Commands**: Houses the command handlers following the CQRS (Command Query Responsibility Segregation) pattern.
  - **Queries**: Contains the query handlers for retrieving data.
  - **Interfaces**: Defines the interfaces for application services.
  - **Mapping**: Includes mapping profiles (e.g., for AutoMapper) to map between different object models.

- **Domain**: This layer includes the core domain entities and business logic.
  - **Entities**: Contains the domain models/entities that represent our business objects.
  - **Repositories**: Defines the interfaces for data access repositories.
  - **Services**: Implements domain services that encapsulate business logic.
  - **Exceptions**: Contains custom exceptions specific to the domain.

- **Infrastructure**: This layer deals with external dependencies and data access.
  - **Persistence**: Includes the database context and migration files.
  - **Repositories**: Implements the repository interfaces defined in the domain layer.
  - **Services**: Contains implementations of external services (e.g., email service).
  - **Identity**: Manages authentication and authorization logic.
  - **Logging**: Configures logging providers and settings.
  - **Extensions**: Contains extension methods for various purposes.

- **Presentation**: This layer is responsible for the API and user interface.
  - **Controllers**: Contains the API controllers that handle HTTP requests and responses.
  - **Filters**: Includes action filters for cross-cutting concerns like exception handling.
  - **Models**: Defines DTOs (Data Transfer Objects) and view models used in API requests and responses.
  - **Startup**: Configures services and middleware in the `Startup.cs` file.
  - **Extensions**: Adds extension methods for IServiceCollection, IApplicationBuilder, etc.

- **Clients**: This directory includes client applications (MVC or Angular).
  - **MVC**: Contains the MVC client application.
    - **Controllers**: MVC controllers.
    - **Views**: Razor views.
    - **Models**: View models.
    - **wwwroot**: Static files for the MVC application.
    - **Startup.cs**: MVC startup configuration.
  - **Angular**: Contains the Angular client application.
    - **src**: Source code for the Angular application.
      - **app**: Angular components, services, etc.
      - **assets**: Static assets for Angular.
      - **environments**: Environment configurations.
      - **index.html**: Main HTML file for Angular.
    - **angular.json**: Angular CLI configuration.
    - **package.json**: NPM dependencies.
    - **tsconfig.json**: TypeScript configuration.

- **Tests**: Contains unit tests and integration tests to ensure the reliability and correctness of our application.

#### /wwwroot

The `wwwroot` directory is used for storing static files (if applicable), such as images, CSS, JavaScript, etc.

---

We hope this detailed breakdown helps you understand our project's structure and the purpose of each folder. If you have any questions or need further clarification, feel free to reach out!
