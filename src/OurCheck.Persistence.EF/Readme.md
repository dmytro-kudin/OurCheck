# OurCheck.Persistence.EF

**Layer:** Infrastructure/Persistence Implementation Layer

This project provides the **concrete Entity Framework Core implementation** of repository abstractions and database access. It implements the **Repository Pattern** using EF Core with **PostgreSQL**, handling all data persistence concerns for the backend application.

## Responsibilities

- Implements **repository interfaces** defined in `OurCheck.Persistence.Abstract`
- Provides **Entity Framework Core DbContext** (`AppDbContext`) for database operations
- Contains **entity type configurations** using Fluent API for precise schema control
- Manages **EF Core migrations** for database schema versioning
- Implements **generic repository base class** (`RepositoryBase<T>`) with CRUD operations
- Handles **database initialization and seeding** logic
- Configures **PostgreSQL** as the database provider
- Applies **query filters** (e.g., `AppointmentQueryFilter`) for cross-cutting concerns

## Dependencies

### Internal Dependencies
| Project | Reason |
|---------|--------|
| `OurCheck.Domain` | Access to domain entities for persistence mapping |
| `OurCheck.Persistence.Abstract` | Implements repository interface contracts |

### External Dependencies
| Package | Purpose |
|---------|---------|
| **Npgsql.EntityFrameworkCore.PostgreSQL** (10.0.0) | PostgreSQL database provider for EF Core |
| **Microsoft.EntityFrameworkCore** (10.0.3) | ORM framework for data access operations |
| **Microsoft.EntityFrameworkCore.Design** (10.0.3) | Design-time tools for migrations and scaffolding |
| **Microsoft.Extensions.Hosting.Abstractions** (10.0.3) | Dependency injection abstractions |

## Key Components

| Component | Description |
|-----------|-------------|
| `/Db/AppDbContext.cs` | EF Core DbContext with entity configurations and seeding logic |
| `/Db/Configurations` | Entity type configurations using Fluent API (`AppointmentConfiguration`, etc.) |
| `/Db/ApplicationDbContextInitialiser.cs` | Database initialization, migration application, and seeding |
| `/Repositories/RepositoryBase.cs` | Generic repository base class implementing `IRepositoryBase<T>` |
| `/Repositories/AppointmentRepository.cs` | Appointment-specific repository implementing `IAppointmentRepository` |
| `/Repositories/SavedPlaceRepository.cs` | SavedPlace-specific repository implementing `ISavedPlaceRepository` |
| `/Migrations` | EF Core migration files for database schema evolution |
| `/Constants/AppointmentQueryFilter.cs` | Global query filters for entities |
| `DependencyInjection.cs` | Service registration (`AddPersistenceServices`) |

## Architectural Rules

- ✅ **MUST** implement all interfaces defined in `OurCheck.Persistence.Abstract`
- ✅ **MUST NOT** be referenced by `OurCheck.Domain` (preserves domain independence)
- ✅ **MUST** encapsulate all EF Core-specific logic (DbContext, migrations, configurations)
- ✅ **SHOULD** use **async/await** for all database operations
- ✅ **SHOULD** use `AsNoTracking()` for read-only queries in repositories
- ✅ **MUST** apply migrations automatically or via initialization logic
- ✅ Uses **Repository Pattern** to abstract EF Core from Application layer
- ✅ Enables **switching ORM technologies** without affecting business logic (via abstraction layer)
