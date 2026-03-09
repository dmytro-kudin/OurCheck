# OurCheck.Dto

**Layer:** Shared Contracts Layer

This project represents the **Data Transfer Objects (DTOs) Layer**, containing pure data contracts shared between the backend API and client applications. It serves as the communication boundary, ensuring consistent data structures across distributed systems.

## Responsibilities

- Defines **API request and response contracts** (DTOs) for all features
- Provides **create/update DTOs** for command operations (e.g., `CreateAppointmentDto`, `CreateSavedPlaceDto`)
- Provides **read DTOs** for query operations (e.g., `AppointmentDto`, `SavedPlaceDto`)
- Contains **common response DTOs** (e.g., `CreatedDto`) for standardized API responses
- Acts as the **anti-corruption layer** between domain entities and external contracts
- Enables **API versioning** through independent DTO evolution

## Dependencies

### Internal Dependencies
**Has no internal dependencies** — This project is completely standalone, containing only data contracts with no external references.

### External Dependencies
- **.NET 10.0** (Target Framework)
- No third-party NuGet packages

## Key Components

| Component | Description |
|-----------|-------------|
| `/Appointment` | Appointment-related DTOs (`AppointmentDto`, `CreateAppointmentDto`) |
| `/SavedPlace` | SavedPlace-related DTOs (`SavedPlaceDto`, `CreateSavedPlaceDto`) |
| `/Common` | Shared response DTOs (`CreatedDto`) for standard API responses |

## Architectural Rules

- ✅ **MUST NOT** reference any other project in the solution
- ✅ **MUST NOT** contain business logic or validation rules
- ✅ **MUST** remain technology-agnostic (no framework dependencies)
- ✅ **MUST** be serializable for API communication (JSON-friendly properties)
- ✅ **SHOULD** be immutable or use init-only properties for thread safety
- ✅ Used by both **backend API** (Application/API layers) and **client applications** (MAUI, Blazor, etc.)
- ✅ Enables **contract-first API design** and independent client/server evolution
