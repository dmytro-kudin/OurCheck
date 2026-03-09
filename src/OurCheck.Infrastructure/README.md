# OurCheck.Infrastructure

**Layer:** Infrastructure/Integration Layer

This project represents the **Infrastructure Layer**, providing concrete implementations of external integrations, services, and cross-cutting concerns that are not related to data persistence. It complements `OurCheck.Persistence.EF` by handling non-database infrastructure needs.

## Responsibilities

- Implements **external service integrations** (email, SMS, cloud storage, etc.)
- Provides **cross-cutting infrastructure services** (caching, file system access)
- Handles **third-party API integrations** (payment gateways, notification services)
- Implements **application service abstractions** defined in Application layer
- Configures **dependency injection** for infrastructure services
- May contain **background job implementations** (Hangfire, Quartz.NET)

## Dependencies

### Internal Dependencies
| Project | Reason |
|---------|--------|
| `OurCheck.Application` | Implements service abstractions defined in Application layer |
| `OurCheck.Domain` | Access to domain entities if needed for infrastructure operations |

### External Dependencies
| Package | Purpose |
|---------|---------|
| **Microsoft.AspNetCore.OpenApi** (10.0.3) | OpenAPI/Swagger integration |
| **Microsoft.EntityFrameworkCore** (10.0.3) | Database abstractions (for infrastructure concerns) |
| **Microsoft.EntityFrameworkCore.Design** (10.0.3) | Design-time tools |
| **Npgsql.EntityFrameworkCore.PostgreSQL** (10.0.0) | PostgreSQL provider |
| **Microsoft.Extensions.Hosting.Abstractions** (10.0.3) | Dependency injection abstractions |

## Key Components

| Component | Description |
|-----------|-------------|
| `/Data` | Database context and configurations (may be moved to Persistence.EF) |
| `DependencyInjection.cs` | Service registration extension method (`AddInfrastructureServices`) |

## Architectural Rules

- ✅ **MUST** implement abstractions defined in `OurCheck.Application`
- ✅ **MUST NOT** be referenced by `OurCheck.Domain` (preserves domain independence)
- ✅ **SHOULD** encapsulate all external service integrations and infrastructure concerns
- ✅ **SHOULD** handle cross-cutting concerns not related to data persistence
- ✅ Works alongside **OurCheck.Persistence.EF** for complete infrastructure implementation
- ✅ Used by **OurCheck.API** for service composition

## Note

This project currently contains database-related code that overlaps with `OurCheck.Persistence.EF`. Consider consolidating pure persistence logic into `OurCheck.Persistence.EF` and keeping only non-database infrastructure concerns here (e.g., email services, caching, file storage).
