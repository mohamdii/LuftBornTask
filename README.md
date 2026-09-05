# Product Management API

A production-oriented **.NET Web API** built as a technical task, demonstrating clean software architecture, modern backend development practices, design patterns, authentication, testing, and containerization.

## 🚀 Overview

This project is a **Product Management API** implementing complete CRUD operations for products while following **Clean Architecture**, **CQRS**, **MediatR**, **Repository & Unit of Work patterns**, **FluentValidation**, and **Factory Method**.

The application also integrates **Microsoft Entra ID SSO** for authentication and is fully containerized using **Docker**.

The primary goal of the project was to build a maintainable, testable, scalable, and production-oriented backend rather than simply implementing CRUD endpoints.

---

## 🏗️ Architecture

The solution follows **Clean Architecture**, separating business rules, application logic, infrastructure concerns, and API responsibilities.

```text
.
├── src
│   ├── Product.API
│   │   ├── Controllers
│   │   ├── Middleware
│   │   ├── DI Wiring
│   │   └── Program.cs
│   │
│   ├── Product.Application
│   │   ├── Features
│   │   │   └── Products
│   │   │       ├── Commands
│   │   │       ├── Queries
│   │   │       ├── Handlers
│   │   │       └── Validators
│   │   ├── Behaviors
│   │   ├── Interfaces
│   │   └── DI Wiring
│   │
│   ├── Product.Domain
│   │   ├── Entities
│   │   ├── Value Objects
│   │   ├── Factories
│   │   └── Domain Rules
│   │
│   └── Product.Infrastructure
│       ├── Persistence
│       ├── Repositories
│       ├── UnitOfWork
│       ├── Configurations
│       └── DI Wiring
│
├── tests
│   └── Product.UnitTests
│       ├── Domain
│       ├── Application
│       └── Features
│
├── Dockerfile
└── README.md
```

### Dependency Direction

```text
             ┌─────────────────┐
             │    Product.API  │
             └────────┬────────┘
                      │
                      ▼
          ┌───────────────────────┐
          │ Product.Application  │
          └───────────┬───────────┘
                      │
                      ▼
             ┌────────────────┐
             │ Product.Domain │
             └────────────────┘
                      ▲
                      │
          ┌───────────┴───────────┐
          │ Product.Infrastructure│
          └───────────────────────┘
```

The **Domain layer remains independent** of infrastructure and external frameworks, while the Application layer defines the required abstractions and Infrastructure provides their implementations.

---

# ✨ Features

* Product CRUD operations
* Clean Architecture
* CQRS
* MediatR
* Generic Repository Pattern
* Unit of Work Pattern
* Factory Method Design Pattern
* FluentValidation
* Microsoft Entra ID SSO
* Dependency Injection
* Separation of concerns
* Unit testing
* Docker containerization
* Centralized DI wiring
* RESTful API design

---

# 🧩 Design Patterns & Principles

## Clean Architecture

The application is divided into four main layers:

### Domain

Contains the core business logic and domain entities.

The Domain layer does not depend on the API, database, or external services.

### Application

Contains application use cases and business workflows.

CQRS commands, queries, handlers, validators, interfaces, and application behaviors are located here.

### Infrastructure

Contains implementation details such as:

* Database access
* Entity Framework Core
* Repository implementations
* Unit of Work
* Entity configurations
* External infrastructure services

### API

Responsible for:

* HTTP endpoints
* Authentication
* Middleware
* Request/response handling
* Dependency injection configuration

---

# 🔀 CQRS

The project uses **Command Query Responsibility Segregation (CQRS)**.

Commands are responsible for changing application state:

```text
CreateProductCommand
UpdateProductCommand
DeleteProductCommand
```

Queries are responsible for retrieving data:

```text
GetProductByIdQuery
GetProductsQuery
```

This separates read and write responsibilities and keeps individual use cases focused and easier to test.

---

# 📬 MediatR

**MediatR** is used to implement the CQRS request/handler pattern.

Instead of controllers directly calling repositories or application services, they send requests through MediatR.

```text
HTTP Request
     │
     ▼
Controller
     │
     ▼
MediatR
     │
     ▼
Command / Query Handler
     │
     ▼
Repository / Unit of Work
     │
     ▼
Database
```

This reduces coupling between the API layer and application use cases.

---

# ✅ FluentValidation

Request validation is implemented using **FluentValidation**.

Validation rules are separated from controllers and handlers, keeping business/application workflows clean.

Example validation responsibilities include:

* Required product fields
* Valid product name
* Valid price
* Valid product data
* Business-specific input constraints

Invalid requests are rejected before reaching the core application logic.

---

# 🏭 Factory Method Pattern

The **Factory Method design pattern** is used to control the creation of domain objects.

Instead of allowing consumers to freely construct domain entities, object creation can be centralized through a factory.

This provides a single location for enforcing creation rules and maintaining valid domain state.

```text
Application
     │
     ▼
Domain Factory
     │
     ▼
Valid Domain Entity
```

This keeps domain creation logic encapsulated inside the Domain layer.

---

# 🗄️ Generic Repository Pattern

A **Generic Repository** abstraction is used to provide common data-access operations.

Typical operations include:

```text
Add
GetById
GetAll
Update
Delete
```

The generic repository reduces repetitive data-access code while keeping the Application layer independent of the underlying persistence implementation.

---

# 🔄 Unit of Work

The project uses the **Unit of Work pattern** to coordinate database operations.

Repositories participate in a single unit of work, allowing multiple changes to be committed together.

```text
UnitOfWork
   │
   ├── Product Repository
   ├── Other Repositories
   │
   └── SaveChanges()
```

This provides a clear abstraction around transaction/commit boundaries.

---

# 🔐 Microsoft Entra ID SSO

Authentication is implemented using **Microsoft Entra ID**.

The API is protected using bearer-token authentication, allowing authenticated users to access protected endpoints.

Authentication flow:

```text
User
 │
 ▼
Microsoft Entra ID
 │
 │ Access Token
 ▼
Client Application
 │
 │ Bearer Token
 ▼
.NET Web API
 │
 ▼
Token Validation
 │
 ▼
Authorized Endpoint
```

This provides centralized identity management and Single Sign-On (SSO) through Microsoft's identity platform.

---

# 💉 Dependency Injection

Dependency Injection is organized through dedicated **DI Wiring** modules.

The Application and Infrastructure layers each expose their own dependency-registration methods, keeping dependency configuration modular and maintainable.

For example:

```text
Product.Application
        │
        └── AddApplication()

Product.Infrastructure
        │
        └── AddInfrastructure()

Product.API
        │
        └── Composition Root
```

The API acts as the composition root and brings the required dependencies together.

---

# 🧪 Unit Testing

The solution includes a dedicated test project for **unit testing**.

Tests focus on important application and domain behavior, including:

* Domain logic
* Product creation
* Validation
* Commands
* Queries
* Handlers
* Business rules

The test structure follows the same feature-oriented organization used by the application.

```text
tests
└── Product.UnitTests
    ├── Domain
    ├── Application
    └── Features
```

---

# 🐳 Docker

The application is containerized using **Docker**.

A `Dockerfile` is included to package the .NET API and its runtime dependencies into a portable container image.

This allows the application to run consistently across different environments.

### Build

```bash
docker build -t product-api .
```

### Run

```bash
docker run -p 8080:8080 product-api
```

The containerized application can then be accessed through the configured API port.

---

# 📡 API Operations

The Product API provides standard CRUD operations.

| Method   | Endpoint             | Description       |
| -------- | -------------------- | ----------------- |
| `GET`    | `/api/products`      | Get all products  |
| `GET`    | `/api/products/{id}` | Get product by ID |
| `POST`   | `/api/products`      | Create a product  |
| `PUT`    | `/api/products/{id}` | Update a product  |
| `DELETE` | `/api/products/{id}` | Delete a product  |

Protected endpoints require a valid Microsoft Entra ID access token.

---

# 🛠️ Technologies

| Technology                | Purpose                            |
| ------------------------- | ---------------------------------- |
| **C#**                    | Programming language               |
| **.NET**                  | Web API framework                  |
| **ASP.NET Core**          | REST API                           |
| **Entity Framework Core** | Data access                        |
| **CQRS**                  | Separation of commands and queries |
| **MediatR**               | Request/handler implementation     |
| **FluentValidation**      | Request validation                 |
| **Microsoft Entra ID**    | Authentication & SSO               |
| **Docker**                | Containerization                   |
| **xUnit**                 | Unit testing                       |
| **Dependency Injection**  | Dependency management              |

---

# 🎯 Architectural Goals

The project was designed with the following principles in mind:

* **Separation of Concerns**
* **Single Responsibility Principle**
* **Dependency Inversion**
* **Low Coupling**
* **High Cohesion**
* **Testability**
* **Maintainability**
* **Scalability**
* **Extensibility**
* **Domain-driven design principles**

Rather than placing business logic inside controllers, responsibilities are distributed across the appropriate architectural layers.

---

# 🚀 Running the Project

### Prerequisites

* .NET SDK
* Docker
* Microsoft Entra ID application registration
* Configured database

### Clone the repository

```bash
git clone <repository-url>
cd <repository-folder>
```

### Configure settings

Configure the required database and Microsoft Entra ID settings in the application's configuration/environment variables.

### Run locally

```bash
dotnet restore
dotnet build
dotnet run
```

### Or run with Docker

```bash
docker build -t product-api .
docker run -p 8080:8080 product-api
```

---

# 📌 Summary

This project demonstrates a complete backend implementation using modern **.NET architecture and development practices**, combining:

**Clean Architecture + CQRS + MediatR + Repository + Unit of Work + Factory Method + FluentValidation + Microsoft Entra ID SSO + Unit Testing + Docker**

The focus was not only on implementing Product CRUD functionality, but on creating a **maintainable, testable, loosely coupled, and production-oriented application architecture**.
