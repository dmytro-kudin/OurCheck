# OurCheck.Application

**Layer:** Application/Use Cases Layer

This project represents the **Application Layer**, implementing business use cases and orchestrating the flow of data between the Domain and Infrastructure layers. It defines how the system executes business operations using the **CQRS pattern** with **MediatR**.

## Responsibilities

- Implements **application use cases** organized by feature (Appointment, SavedPlace)
- Defines **CQRS commands and queries** using MediatR handlers
- Provides **DTOs (Data Transfer Objects)** for data contracts between layers
- Enforces **cross-cutting concerns** via MediatR pipeline behaviors (validation, logging)
- Defines **repository abstractions** through interfaces (`IAppDbContext`)
- Applies **FluentValidation** for input validation rules

## Dependencies

### Internal Dependencies
| Project | Reason |
|---------|--------|
| `OurCheck.Domain` | References domain entities and business logic |

### External Dependencies
| Package | Purpose |
|---------|---------|
| **MediatR** (12.2.0) | CQRS command/query handling and pipeline orchestration |
| **FluentValidation** (11.9.1) | Declarative validation rules for commands/queries |
| **Microsoft.EntityFrameworkCore** (10.0.3) | Database abstraction interface (`IAppDbContext`) |
| **Serilog.AspNetCore** (10.0.0) | Structured logging integration |

## Key Components

| Component | Description |
|-----------|-------------|
| `/Appointment` | Appointment feature (Commands, Queries, DTOs) |
| `/SavedPlace` | SavedPlace feature (Commands, Queries, DTOs) |
| `/Common/Interfaces` | Application abstractions (e.g., `IAppDbContext`) |
| `/Common/Behaviors` | MediatR pipeline behaviors (`ValidationBehavior`, `RequestResponseLoggingBehavior`) |
| `/Common/Constants` | Shared application constants |
| `DependencyInjection.cs` | Service registration extension method (`AddApplicationServices`) |

## Architectural Rules

- ✅ **MUST** depend only on `OurCheck.Domain`
- ✅ **MUST NOT** reference `OurCheck.Infrastructure` or `OurCheck.API`
- ✅ **MUST** define abstractions (interfaces) for infrastructure services (e.g., database access)
- ✅ **MUST** organize features using **Vertical Slice Architecture** (Commands/Queries/DTOs per feature)
- ✅ Infrastructure layer implements interfaces defined here (**Inversion of Control**)