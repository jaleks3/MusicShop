## Description
MusicShop is an ASP.NET Core web application developed to establish business logic for a music store. 
The project utilizes Entity Framework in "Database First" mode, follows the Clean Architecture principles, SOLID design principles, implements the Dependency Injection and Repository. It provides a standardized structure and organization for building robust and maintainable ASP.NET Core web applications with complete CRUD (Create, Read, Update, Delete) operations.

## Project Structure
The project structure is designed to promote separation of concerns and modularity, making it easier to understand, test, and maintain the application.
```
├── MusicShop                   # Contains project folder
│   ├── Controllers             # Handles HTTP requests and responses.
│   ├── Data                    # Contains ProjectContext
│   ├── Migrations              # Manages database schema changes.
│   ├── Models                  # Defines entity models as well as DTOs
│   ├── Properties              # Contains launch settings
│   ├── Services                # Implements database operations and business logic. 
│   └── MusicShop.sln           # Solution file                  
├── DB/SQL Files
│   ├── ERD.jpg                 # Entity-Relationship Diagram - visual representation of the database schema.
│   ├── MusicShop_create.sql    # Create the database schema and tables.
│   ├── MusicShop_drop.sql      # Drop database tables and objects.
│   └── MusicShop_seed.sql      # Seed database with inital data.
└── README.md                   # Project documentation (you are here!)
```

## Features
ASP.NET Core: Utilizes the ASP.NET Core framework for building robust and scalable web applications.
Entity Framework: Implements Entity Framework in "Database First" mode for efficient data access and management.
Custom Database: The project supports a custom database schema tailored to the needs of a music store.
Migrations: Utilizes database migrations to manage changes to the database schema over time.
Business Logic: Implements business logic to facilitate essential operations within the music store application.
## Getting Started
To get started with the MusicShop project, follow these steps:

1. Ensure the .NET 7 SDK is installed on your machine.
2. Clone or download this repository to your local machine.
3. Open the solution in your preferred IDE (e.g., Visual Studio, Visual Studio Code).
4. Build the solution to restore NuGet packages and compile the code.
5. Configure the necessary database connection settings in the [user-secrets](https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-8.0&tabs=windows).
6. Open the Package Manager Console, run the Update-Database command to create the database
7. Run the application by starting the MusicShop project.

