# OurCheck.Persistence.Abstract

**Layer:** Application Persistence Abstractions Layer

This project defines **repository abstractions** for data access operations, following the **Repository Pattern**. It provides interfaces that decouple the application logic from concrete data access implementations, enabling **Inversion of Control**.

## Responsibilities

- Defines **repository interface contracts** (`IRepositoryBase<T>`, `IAppointmentRepository`, `ISavedPlaceRepository`)
- Provides **generic base repository interface** (`IRepositoryBase<T>`) with standard CRUD operations
- Declares **entity-specific repository interfaces** with specialized query methods
- Establishes the **boundary between business logic and data access**
- Enables **dependency inversion**  Application layer depends on abstractions, Infrastructure implements them
- Facilitates **unit testing** through mockable interfaces

## Dependencies

### Internal Dependencies
| Project | Reason |
|---------|--------|
| `OurCheck.Domain` | References domain entities (`EntityBase`) for generic repository constraints |

### External Dependencies
- **.NET 10.0** (Target Framework)
- No third-party NuGet packages

## Key Components

| Component | Description |
|-----------|-------------|
| `/Repositories/IRepositoryBase.cs` | Generic repository interface with CRUD operations (`GetAllAsync`, `GetByIdAsync`, `AddAsync`, `UpdateAsync`, `DeleteAsync`) |
| `/Repositories/IAppointmentRepository.cs` | Appointment-specific repository interface (extends `IRepositoryBase<Appointment>`) |
| `/Repositories/ISavedPlaceRepository.cs` | SavedPlace-specific repository interface (extends `IRepositoryBase<SavedPlace>`) |

## Architectural Rules

-  **MUST** define only abstractions (interfaces), never implementations
-  **MUST** depend only on `OurCheck.Domain` for entity types
-  **MUST NOT** reference `OurCheck.Persistence.EF` or any infrastructure projects
-  **MUST NOT** contain any data access logic (EF Core, SQL, etc.)
-  **SHOULD** use generic constraints (`where T : EntityBase`) to enforce domain rules
-  Implemented by **OurCheck.Persistence.EF** project (concrete EF Core repositories)
-  Enables **switching persistence technologies** without changing business logic
