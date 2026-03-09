# OurCheck.Client.Repository.API

**Layer:** Client Infrastructure/HTTP API Client Layer

This project provides the **concrete HTTP API client implementation** of client repository abstractions. It communicates with the backend ASP.NET Core API via **HttpClient**, handling all remote data access concerns for client applications.

## Responsibilities

- Implements **repository interfaces** defined in `OurCheck.Client.Repository.Abstract`
- Provides **HTTP-based data access** using `HttpClient` to communicate with backend API
- Implements **generic repository base class** (`RepositoryBase<TDto, TCreateDto>`) for REST operations
- Handles **HTTP request/response serialization** (JSON) for DTOs
- Manages **API endpoint routing** and versioning (e.g., `api/v1/appointment`)
- Implements **CRUD operations** via REST verbs (GET, POST, PUT, DELETE)
- Provides **typed HttpClient** configuration and error handling
- Registers services via **dependency injection** (`DependencyInjection.cs`)

## Dependencies

### Internal Dependencies
| Project | Reason |
|---------|--------|
| `OurCheck.Client.Repository.Abstract` | Implements repository interface contracts |

### External Dependencies
| Package | Purpose |
|---------|---------|
| **Microsoft.Extensions.DependencyInjection.Abstractions** (10.0.3) | Dependency injection service registration |

## Key Components

| Component | Description |
|-----------|-------------|
| `/Repositories/Abstract/RepositoryBase.cs` | Generic HTTP repository base class with REST operations (`GetAllAsync`, `GetByIdAsync`, `CreateAsync`, `UpdateAsync`, `DeleteAsync`) |
| `/Repositories/AppointmentRepository.cs` | Appointment-specific HTTP repository implementing `IAppointmentRepository` |
| `DependencyInjection.cs` | Service registration (`AddApiRepositories`) with HttpClient configuration |

## Architectural Rules

- ✅ **MUST** implement all interfaces defined in `OurCheck.Client.Repository.Abstract`
- ✅ **MUST** use `HttpClient` for all HTTP operations (do not use WebClient or HttpWebRequest)
- ✅ **MUST** work with DTOs (from `OurCheck.Dto`), never domain entities
- ✅ **SHOULD** use typed HttpClient with IHttpClientFactory for connection pooling
- ✅ **SHOULD** handle HTTP errors gracefully (404, 500, network failures)
- ✅ **SHOULD** implement retry policies and circuit breakers (Polly) for resilience
- ✅ **MUST** configure base API URL via dependency injection (appsettings.json)
- ✅ Uses **generic RepositoryBase** to eliminate HTTP boilerplate code
- ✅ Enables **swapping data sources** (e.g., switch to SQLite offline repository) without changing client logic
