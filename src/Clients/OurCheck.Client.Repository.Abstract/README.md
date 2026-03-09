# OurCheck.Client.Repository.Abstract

**Layer:** Client Data Access Abstractions Layer

This project defines **repository abstractions** for client-side data access, following the **Repository Pattern**. It provides interfaces that decouple client business logic from concrete data sources (HTTP APIs, local databases, caching), enabling **Inversion of Control** in client applications.

## Responsibilities

- Defines **client repository interface contracts** (`IRepositoryBase<TDto>`, `IAppointmentRepository`, `ISavedPlaceRepository`)
- Provides **generic base repository interface** for CRUD operations on DTOs
- Declares **entity-specific repository interfaces** with client-specific query methods
- Establishes the **boundary between client business logic and data sources**
- Enables **dependency inversion** — Client Application layer depends on abstractions
- Facilitates **unit testing** of client services through mockable interfaces
- Supports **multiple data source implementations** (API, SQLite, in-memory cache)

## Dependencies

### Internal Dependencies
| Project | Reason |
|---------|--------|
| `OurCheck.Dto` | References DTOs for data contracts (not domain entities) |

### External Dependencies
- **.NET 10.0** (Target Framework)
- No third-party NuGet packages

## Key Components

| Component | Description |
|-----------|-------------|
| `/Repositories/IRepositoryBase.cs` | Generic repository interface with CRUD operations for DTOs |
| `/Repositories/IAppointmentRepository.cs` | Appointment-specific repository interface (extends `IRepositoryBase<AppointmentDto>`) |
| `/Repositories/ISavedPlaceRepository.cs` | SavedPlace-specific repository interface (extends `IRepositoryBase<SavedPlaceDto>`) |

## Architectural Rules

- ✅ **MUST** define only abstractions (interfaces), never implementations
- ✅ **MUST** work with DTOs (from `OurCheck.Dto`), not domain entities
- ✅ **MUST NOT** reference `OurCheck.Client.Repository.API` or any infrastructure projects
- ✅ **MUST NOT** contain any HTTP, database, or caching logic
- ✅ **SHOULD** use generic constraints on DTOs to enforce type safety
- ✅ Implemented by **OurCheck.Client.Repository.API** (HTTP API client)
- ✅ Enables **offline-first architecture** through alternative implementations (SQLite, cache)
- ✅ Supports **switching data sources** without changing client business logic
