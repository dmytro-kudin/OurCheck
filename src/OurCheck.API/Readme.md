# OurCheck.API

**Layer:** Presentation/API Layer

This project represents the **Presentation Layer**, exposing HTTP endpoints via **ASP.NET Core Web API**. It orchestrates requests, delegates business logic to the Application layer via **MediatR**, and handles API concerns such as versioning, OpenAPI documentation, and global exception handling.

## Responsibilities

- Defines **RESTful API controllers** (`AppointmentController`, `SavedPlaceController`)
- Exposes **HTTP endpoints** for external clients (mobile, web, third-party integrations)
- Handles **API versioning** using `Asp.Versioning.Mvc`
- Provides **OpenAPI/Swagger documentation** via Scalar UI
- Implements **global exception handling** middleware
- Configures **structured logging** with Serilog
- Orchestrates dependency injection setup for all layers

## Dependencies

### Internal Dependencies
| Project | Reason |
|---------|--------|
| `OurCheck.Application` | Sends commands/queries via MediatR to execute use cases |
| `OurCheck.Infrastructure` | Registers infrastructure services (DbContext, migrations) |

### External Dependencies
| Package | Purpose |
|---------|---------|
| **Asp.Versioning.Mvc** (8.1.1) | API versioning support |
| **MediatR** (12.2.0) | Command/query delegation to Application layer |
| **FluentValidation** (11.9.1) | Request validation integration |
| **Scalar.AspNetCore** (2.1.9) | Modern OpenAPI UI for API documentation |
| **Serilog.AspNetCore** (10.0.0) | Structured logging framework |
| **Microsoft.EntityFrameworkCore.Design** (10.0.3) | EF Core CLI tooling for migrations |

## Key Components

| Component | Description |
|-----------|-------------|
| `/Controllers` | API controllers exposing HTTP endpoints (`AppointmentController`, `SavedPlaceController`) |
| `/Exceptions/GlobalExceptionHandler.cs` | Centralized exception handling middleware |
| `/Features` | (Future) Vertical slice feature endpoints if migrating from Controllers |
| `Program.cs` | Application entry point, DI configuration, middleware pipeline |
| `DependencyInjection.cs` | Service registration extension method (`AddApiServices`) |
| `appsettings.json` | Configuration for logging, database connection strings, etc. |

## Architectural Rules

- ✅ **MUST NOT** contain business logic — delegate to `OurCheck.Application` via MediatR
- ✅ **MUST NOT** directly reference `OurCheck.Domain` entities in controller signatures (use DTOs)
- ✅ **SHOULD** use **thin controllers** that only handle HTTP concerns (routing, model binding, response formatting)
- ✅ **MUST** handle cross-cutting concerns (exception handling, logging, validation) via middleware/filters
- ✅ **SHOULD** maintain **API versioning** for backward compatibility
- ✅ Entry point (`Program.cs`) composes all layers via dependency injection