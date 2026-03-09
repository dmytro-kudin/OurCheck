# OurCheck.Client.Application

**Layer:** Client Application/Business Logic Layer

This project represents the **Client Application Layer** for client applications (MAUI, Blazor, etc.), containing business logic and service orchestration specific to client-side operations. It follows Clean Architecture principles adapted for mobile and desktop client scenarios.

## Responsibilities

- Defines **client-side business services** (e.g., `IAppointmentService`, `AppointmentService`)
- Orchestrates **data retrieval and manipulation** logic for client applications
- Implements **business rules specific to client scenarios** (filtering, sorting, caching)
- Provides **abstraction over repository operations** for ViewModels/Pages
- Handles **exception handling and error management** for client operations
- Facilitates **offline-first capabilities** and data synchronization logic (future)
- Registers services via **dependency injection** (`DependencyInjection.cs`)

## Dependencies

### Internal Dependencies
| Project | Reason |
|---------|--------|
| `OurCheck.Dto` | Uses DTOs for data contracts with backend API |
| `OurCheck.Client.Repository.Abstract` | Depends on repository abstractions for data access |
| `OurCheck.Client.Repository.API` | Concrete HTTP repository implementation for API communication |

### External Dependencies
- **.NET 10.0** (Target Framework)
- No third-party NuGet packages (framework abstractions only)

## Key Components

| Component | Description |
|-----------|-------------|
| `/Services/Appointment` | Appointment business services (`IAppointmentService`, `AppointmentService`) |
| `/Exceptions` | Client-specific exceptions (`InvalidConfigurationException`) |
| `DependencyInjection.cs` | Service registration extension method (`AddClientApplicationServices`) |

## Architectural Rules

- ✅ **MUST** depend on `OurCheck.Client.Repository.Abstract` (not concrete implementations)
- ✅ **MUST** use DTOs from `OurCheck.Dto` for all data operations
- ✅ **MUST NOT** contain UI logic (ViewModels, Views, Pages)
- ✅ **MUST NOT** directly call HttpClient or API endpoints (use repositories)
- ✅ **SHOULD** implement business logic that is shared across multiple client platforms
- ✅ **SHOULD** handle cross-cutting concerns (error handling, logging, validation)
- ✅ Used by **OurCheck.Client.MAUI** (and future Blazor/WPF clients)
- ✅ Enables **platform-agnostic business logic** reusable across clients
