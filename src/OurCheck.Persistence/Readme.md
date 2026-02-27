# OurCheck.Infrastructure

**Layer:** Infrastructure/Data Access Layer

This project represents the **Infrastructure Layer**, providing concrete implementations of persistence, data access, and external integrations. It implements repository patterns and database context using **Entity Framework Core** with **PostgreSQL**.

## Responsibilities

- Implements **Entity Framework Core DbContext** (`AppDbContext`)
- Provides **database configurations** and entity mappings
- Manages **EF Core migrations** for schema versioning
- Implements **IAppDbContext** interface defined in Application layer
- Configures **PostgreSQL** as the database provider
- Handles **database initialization and seeding** logic

## Dependencies

### Internal Dependencies
| Project | Reason |
|---------|--------|
| `OurCheck.Domain` | Access to entity definitions for persistence mapping |
| `OurCheck.Application` | Implements `IAppDbContext` and other application abstractions |

### External Dependencies
| Package | Purpose |
|---------|---------|
| **Npgsql.EntityFrameworkCore.PostgreSQL** (10.0.0) | PostgreSQL database provider for EF Core |
| **Microsoft.EntityFrameworkCore** (10.0.3) | ORM framework for data access |
| **Microsoft.EntityFrameworkCore.Design** (10.0.3) | Design-time tools for migrations |
| **Microsoft.Extensions.Hosting.Abstractions** (10.0.3) | Dependency injection abstractions |

## Key Components

| Component | Description |
|-----------|-------------|
| `/Data/AppDbContext.cs` | EF Core DbContext implementing `IAppDbContext` with seeding logic |
| `/Data/Configurations` | Entity type configurations (Fluent API mappings) |
| `/Data/ApplicationDbContextInitialiser.cs` | Database initialization and migration logic |
| `/Migrations` | EF Core migration files for schema evolution |
| `DependencyInjection.cs` | Service registration extension method (`AddInfrastructureServices`) |

## Architectural Rules

- ✅ **MUST** implement abstractions defined in `OurCheck.Application`
- ✅ **MUST NOT** be referenced by `OurCheck.Domain` (preserves domain independence)
- ✅ **SHOULD** encapsulate all persistence and external service concerns
- ✅ **MUST** use **Repository Pattern** or **DbContext abstraction** to avoid tight coupling
- ✅ Uses **async/await seeding** for database initialization (`UseAsyncSeeding`)