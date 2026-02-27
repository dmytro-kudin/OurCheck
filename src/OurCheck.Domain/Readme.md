# OurCheck.Domain

**Layer:** Core/Domain Layer

This project represents the **Domain Layer** in Clean Architecture, containing the core business entities and domain logic. It defines the heart of the application's business rules and is completely independent of external concerns.

## Responsibilities

- Defines **core business entities** (e.g., `Appointment`, `SavedPlace`)
- Contains domain models with business logic encapsulated within entities
- Provides the `EntityBase` abstract class for common entity infrastructure (ID generation, audit timestamps)
- Establishes the foundational types that all other layers depend upon
- Enforces domain invariants and business rules at the entity level

## Dependencies

### Internal Dependencies
**Has no internal dependencies** — This project references no other projects in the solution, maintaining strict architectural purity as the innermost layer.

### External Dependencies
- **.NET 10.0** (Target Framework)
- No third-party NuGet packages

## Key Components

| Component | Description |
|-----------|-------------|
| `/Entities` | Contains domain entities (`Appointment`, `SavedPlace`, `EntityBase`) |
| `EntityBase` | Abstract base class providing `Id`, `Created`, and `LastModified` properties with domain logic |

## Architectural Rules

- ✅ **MUST NOT** reference any other project in the solution
- ✅ **MUST NOT** depend on infrastructure concerns (databases, APIs, frameworks)
- ✅ **MUST** contain only pure domain logic and business entities
- ✅ **MUST** remain framework-agnostic and technology-independent
- ✅ All other layers may depend on this layer (**Dependency Inversion Principle**)