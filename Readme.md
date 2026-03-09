# OurCheck

**A production-ready appointment management system built with ASP.NET Core.** Demonstrates enterprise-level architectural patterns, clean code principles, and modern .NET development practices.

[![.NET](https://img.shields.io/badge/.NET-10.0-512BD4?logo=dotnet)](https://dotnet.microsoft.com/)
[![License](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE)
[![Build Status](https://img.shields.io/badge/build-passing-brightgreen.svg)]()
[![Docker](https://img.shields.io/badge/docker-ready-2496ED?logo=docker)](https://www.docker.com/)

---

## 📸 Screenshots

![API Documentation](docs/images/scalar-ui.png)
<!-- Add Scalar UI screenshot here -->

---

## ✨ Features

- **Full CRUD Operations** for appointment management
- **RESTful API** with versioning support (v1.0)
- **Interactive API Documentation** powered by Scalar UI
- **Global Exception Handling** with RFC 7807 Problem Details
- **Request/Response Logging** with correlation IDs for traceability
- **Automatic Validation** using FluentValidation pipeline
- **Database Migrations** with Entity Framework Core
- **Data Seeding** for quick development startup
- **Containerized Deployment** with Docker and Docker Compose
- **Health Checks** for PostgreSQL database

---

## 🛠️ Tech Stack

### **Core Framework**
| Technology | Purpose |
|------------|---------|
| **.NET 10** | Runtime and SDK |
| **ASP.NET Core 10** | Web API framework |
| **C# 13** | Programming language |

### **Data Access**
| Technology | Purpose |
|------------|---------|
| **Entity Framework Core 10** | ORM for database operations |
| **Npgsql.EntityFrameworkCore.PostgreSQL** | PostgreSQL provider |
| **PostgreSQL 17 (Alpine)** | Relational database |

### **Architecture & Patterns**
| Technology | Purpose |
|------------|---------|
| **MediatR 12.2** | CQRS and mediator pattern implementation |
| **FluentValidation 11.9** | Model validation |

### **API Documentation**
| Technology | Purpose |
|------------|---------|
| **Scalar 2.1** | Modern API documentation UI |
| **Microsoft.AspNetCore.OpenApi** | OpenAPI specification generation |
| **Asp.Versioning** | API versioning support |

### **Logging & Observability**
| Technology | Purpose |
|------------|---------|
| **Serilog 10.0** | Structured logging |

### **DevOps**
| Technology | Purpose |
|------------|---------|
| **Docker** | Containerization |
| **Docker Compose** | Multi-container orchestration |

---

## 🏗️ Architecture

This project follows **Clean Architecture** principles organized into a **multi-project layered solution**, implementing:

- **CQRS (Command Query Responsibility Segregation)**: Separate models for read and write operations
- **MediatR Pipeline Behaviors**: Cross-cutting concerns handled via:
  - `RequestResponseLoggingBehavior`: Structured logging with correlation IDs
  - `ValidationBehavior`: Automatic request validation before handler execution
- **Repository Pattern**: Abstracted via EF Core DbContext (`IAppDbContext`)
- **Domain-Driven Design**: Domain entities with encapsulated business logic
- **Dependency Inversion Principle**: Application layer defines abstractions, Infrastructure implements them
- **Global Exception Handling**: Centralized error handling with RFC 7807 Problem Details responses
- **API Versioning**: URL segment-based versioning with header fallback support
- **Vertical Slice Architecture**: Features organized by use case (Commands, Queries, DTOs per feature)

### Solution Structure (Layered Architecture)

```
src/
├── Backend (Server-Side)
│   │
│   ├── OurCheck.Domain/              # 🟦 Core/Domain Layer
│   │   ├── Entities/                 #    - Appointment, SavedPlace, EntityBase
│   │   └── README.md                 #    - Zero dependencies (pure domain logic)
│   │
│   ├── OurCheck.Dto/                 # 📦 Shared Contracts Layer
│   │   ├── Appointment/              #    - AppointmentDto, CreateAppointmentDto
│   │   ├── SavedPlace/               #    - SavedPlaceDto, CreateSavedPlaceDto
│   │   ├── Common/                   #    - CreatedDto
│   │   └── README.md                 #    - Shared between backend & clients
│   │
│   ├── OurCheck.Application/         # 🟩 Application/Use Cases Layer
│   │   ├── Appointment/              #    - CQRS Commands & Queries
│   │   │   ├── Commands/             #    - Create, Delete, Update handlers
│   │   │   ├── Queries/              #    - Get, List queries
│   │   │   └── Dtos/                 #    - Feature-specific DTOs
│   │   ├── SavedPlace/               #    - SavedPlace feature slice
│   │   ├── Common/
│   │   │   ├── Behaviors/            #    - ValidationBehavior, LoggingBehavior
│   │   │   ├── Interfaces/           #    - IAppDbContext (abstraction)
│   │   │   └── Constants/
│   │   ├── DependencyInjection.cs    #    - MediatR + FluentValidation setup
│   │   └── README.md                 #    - Depends on Domain + Dto
│   │
│   ├── OurCheck.Persistence.Abstract/ # 🔷 Persistence Abstractions
│   │   ├── Repositories/             #    - IRepositoryBase<T>, IAppointmentRepository
│   │   └── README.md                 #    - Repository interface contracts
│   │
│   ├── OurCheck.Persistence.EF/      # 🟨 Persistence Implementation (EF Core)
│   │   ├── Db/                       #    - AppDbContext, Configurations
│   │   ├── Repositories/             #    - RepositoryBase<T>, concrete repositories
│   │   ├── Migrations/               #    - EF Core migration files
│   │   ├── DependencyInjection.cs    #    - PostgreSQL + EF Core setup
│   │   └── README.md                 #    - Implements Persistence.Abstract
│   │
│   ├── OurCheck.Infrastructure/      # 🟧 Infrastructure (External Services)
│   │   ├── Data/                     #    - Legacy database code (consider moving)
│   │   ├── DependencyInjection.cs    #    - External integrations setup
│   │   └── README.md                 #    - Email, caching, file storage, etc.
│   │
│   └── OurCheck.API/                 # 🟥 Presentation/API Layer
│       ├── Controllers/              #    - AppointmentController, SavedPlaceController
│       ├── Exceptions/               #    - GlobalExceptionHandler
│       ├── Program.cs                #    - Application entry point
│       ├── DependencyInjection.cs    #    - API versioning, Swagger, CORS
│       └── README.md                 #    - Orchestrates all layers
│
└── Clients/ (Client Applications)
    │
    ├── OurCheck.Client.Repository.Abstract/  # 🔷 Client Repository Abstractions
    │   ├── Repositories/             #    - IRepositoryBase<TDto>, IAppointmentRepository
    │   └── README.md                 #    - Client data access interface contracts
    │
    ├── OurCheck.Client.Repository.API/       # 🌐 HTTP API Client Implementation
    │   ├── Repositories/             #    - RepositoryBase (HttpClient), AppointmentRepository
    │   ├── DependencyInjection.cs    #    - HttpClient + typed client setup
    │   └── README.md                 #    - Implements Client.Repository.Abstract via HTTP
    │
    ├── OurCheck.Client.Application/          # 🟢 Client Business Logic
    │   ├── Services/                 #    - IAppointmentService, AppointmentService
    │   ├── Exceptions/               #    - Client-specific exceptions
    │   ├── DependencyInjection.cs    #    - Client services setup
    │   └── README.md                 #    - Platform-agnostic client logic
    │
    └── OurCheck.Client.MAUI/                 # 📱 MAUI Cross-Platform UI
        ├── Views/                    #    - XAML/C# Markup pages
        ├── ViewModels/               #    - MVVM ViewModels
        ├── Setup/                    #    - Configuration helpers
        ├── MauiProgram.cs            #    - MAUI entry point
        ├── AppShell.cs               #    - Navigation routing
        ├── appsettings.json          #    - API URL, logging config
        └── README.md                 #    - iOS, Android, macOS, Windows UI
```

### Dependency Flow (Clean Architecture)

#### Backend Dependency Graph

```mermaid
graph TD
    API[OurCheck.API<br/>Presentation]
    APP[OurCheck.Application<br/>Use Cases]
    INFRA[OurCheck.Infrastructure<br/>External Services]
    EF[OurCheck.Persistence.EF<br/>Database Implementation]
    PERSIST[OurCheck.Persistence.Abstract<br/>Repository Interfaces]
    DOMAIN[OurCheck.Domain<br/>Core Entities]
    DTO[OurCheck.Dto<br/>Contracts]

    API -->|depends on| APP
    API -->|depends on| INFRA
    API -->|depends on| EF

    INFRA -->|depends on| APP
    INFRA -->|depends on| DOMAIN

    EF -->|depends on| PERSIST
    EF -->|depends on| DOMAIN

    APP -->|depends on| PERSIST
    APP -->|depends on| DOMAIN
    APP -->|depends on| DTO

    PERSIST -->|depends on| DOMAIN
    
    classDef presentation fill:#fdfdff,stroke:#5c6bc0,stroke-width:2px;
    classDef application fill:#f1f8e9,stroke:#7cb342,stroke-width:2px;
    classDef infrastructure fill:#fff3e0,stroke:#fb8c00,stroke-width:2px;
    classDef core fill:#e3f2fd,stroke:#1e88e5,stroke-width:2px;
    
    class API presentation;
    class APP application;
    class INFRA,EF infrastructure;
    class DOMAIN,DTO,PERSIST core;
```

#### Client Dependency Graph

```mermaid
graph TD
    MAUI[OurCheck.Client.MAUI<br/>Presentation]
    CAPP[OurCheck.Client.Application<br/>Business Logic]
    CREP_API[OurCheck.Client.Repository.API<br/>HTTP Implementation]
    CREP_ABS[OurCheck.Client.Repository.Abstract<br/>Interfaces]
    DTO[OurCheck.Dto<br/>Shared Contracts]

    MAUI -->|depends on| CAPP
    
    CAPP -->|depends on| CREP_API
    CAPP -->|depends on| CREP_ABS
    CAPP -->|depends on| DTO
    
    CREP_API -->|depends on| CREP_ABS
    CREP_ABS -->|depends on| DTO

    classDef presentation fill:#fdfdff,stroke:#5c6bc0,stroke-width:2px;
    classDef application fill:#f1f8e9,stroke:#7cb342,stroke-width:2px;
    classDef infrastructure fill:#fff3e0,stroke:#fb8c00,stroke-width:2px;
    classDef core fill:#e3f2fd,stroke:#1e88e5,stroke-width:2px;

    class MAUI presentation;
    class CAPP application;
    class CREP_API infrastructure;
    class CREP_ABS,DTO core;
```

> **📖 Each project contains its own detailed README.md** explaining responsibilities, dependencies, and architectural rules.
>
> **🔑 Key Architectural Benefit:** `OurCheck.Dto` enables **contract-first design** and serves as the **integration point** between backend API and client applications.

---

## 📱 Client Applications

The solution includes a **.NET MAUI cross-platform client application** that consumes the backend API, demonstrating a complete end-to-end architecture.

### OurCheck.Client.MAUI

**Multi-platform native app** for iOS, Android, macOS, and Windows using:
- **MVVM Pattern** with CommunityToolkit.Mvvm
- **C# Markup** for declarative UI (CommunityToolkit.Maui.Markup)
- **Clean Architecture** with separation of concerns (Repository, Application, Presentation)
- **HttpClient-based API communication** via typed repositories
- **Serilog structured logging** for diagnostics
- **Dependency Injection** for testability

**Supported Platforms:**
- iOS 15.0+
- Android 21+ (Lollipop)
- macOS Catalyst 15.0+
- Windows 10.0.17763.0+

**Key Features:**
- Native UI with platform-specific optimizations
- AOT compilation and trimming for optimized binaries
- Shared business logic across all platforms
- Type-safe API client with DTOs
- Configuration via `appsettings.json`

See `src/Clients/OurCheck.Client.MAUI/README.md` for detailed setup instructions.

---

## 🚀 Getting Started

### Prerequisites

#### Backend Prerequisites

- **.NET 10 SDK** ([Download](https://dotnet.microsoft.com/download/dotnet/10.0))
- **Docker Desktop** ([Download](https://www.docker.com/products/docker-desktop))
- **Entity Framework Core CLI Tools**:
  ```bash
  dotnet tool install --global dotnet-ef
  ```

#### Client Prerequisites (for MAUI app)

- **.NET 10 SDK** with MAUI workload
- **Visual Studio 2022** or **JetBrains Rider** with MAUI support
- **Xcode** (macOS only, for iOS/macOS development)
- **Android SDK** (for Android development)

Install MAUI workload:
```bash
dotnet workload install maui
```

### Setup Instructions

#### Backend Setup

1. **Clone the repository**
   ```bash
   git clone https://github.com/yourusername/OurCheck.git
   cd OurCheck
   ```

2. **Start PostgreSQL with Docker**
   ```bash
   docker compose up -d
   ```
   This will start a PostgreSQL 17 container on `localhost:5432` with:
   - Username: `admin`
   - Password: `secret`
   - Database: `ourCheck`

3. **Restore NuGet packages**
   ```bash
   dotnet restore
   ```

4. **Add migrations** (if needed)
   ```bash
   dotnet ef migrations add <MigrationName> --project src/OurCheck.Persistence.EF --startup-project src/OurCheck.API
   ```

5. **Apply database migrations**
   ```bash
   dotnet ef database update --project src/OurCheck.Persistence.EF --startup-project src/OurCheck.API
   ```
   > **Note:** The database will be seeded automatically on first run with sample data.

6. **Run the backend API**
   ```bash
   dotnet run --project src/OurCheck.API
   ```

7. **Access the API**
   - **HTTPS**: [https://localhost:7198](https://localhost:7198)
   - **HTTP**: [http://localhost:5017](http://localhost:5017)
   - **API Documentation (Scalar)**: [https://localhost:7198/scalar/v1](https://localhost:7198/scalar/v1)

#### Client Setup (MAUI)

1. **Configure API URL** in `src/Clients/OurCheck.Client.MAUI/appsettings.json`:
   ```json
   {
     "ApiSettings": {
       "BaseUrl": "https://localhost:7198"
     }
   }
   ```

2. **Run the MAUI app** (choose your target platform):
   ```bash
   # Android
   dotnet build -t:Run -f net10.0-android -p src/Clients/OurCheck.Client.MAUI

   # iOS (macOS only)
   dotnet build -t:Run -f net10.0-ios -p src/Clients/OurCheck.Client.MAUI

   # Windows
   dotnet build -t:Run -f net10.0-windows10.0.19041.0 -p src/Clients/OurCheck.Client.MAUI

   # macOS Catalyst
   dotnet build -t:Run -f net10.0-maccatalyst -p src/Clients/OurCheck.Client.MAUI
   ```

   Or use Visual Studio/Rider's built-in MAUI debugger.

---

## 📚 API Documentation

Once the application is running, navigate to the **Scalar UI** at:

```
https://localhost:7198/scalar/v1
```

Here you can:
- Explore all available endpoints
- Test API requests interactively
- View request/response schemas
- Download the OpenAPI specification

### Available Endpoints (v1)

#### Appointments
| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/v1/Appointment` | List all appointments |
| GET | `/api/v1/Appointment/{id}` | Get appointment by ID |
| POST | `/api/v1/Appointment` | Create new appointment |
| PUT | `/api/v1/Appointment/{id}` | Update appointment |
| DELETE | `/api/v1/Appointment/{id}` | Delete appointment |

#### Saved Places
| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/v1/SavedPlace` | List all saved places |
| GET | `/api/v1/SavedPlace/{id}` | Get saved place by ID |
| POST | `/api/v1/SavedPlace` | Create new saved place |
| PUT | `/api/v1/SavedPlace/{id}` | Update saved place |
| DELETE | `/api/v1/SavedPlace/{id}` | Delete saved place |

---

## 🧪 Testing

```bash
# Run all tests
dotnet test

# Run tests with coverage
dotnet test /p:CollectCoverage=true
```

> **Note:** Test project not yet implemented. See [Future Improvements](#-future-improvements).

---

## 🐳 Docker Deployment

### Build and run with Docker

```bash
# Build the Docker image
docker build -t ourcheck:latest -f src/OurCheck.API/Dockerfile .

# Run the container
docker run -p 5017:8080 --env-file .env ourcheck:latest
```

### Docker Compose (Full Stack)

```bash
# Start all services (API + PostgreSQL)
docker compose up --build

# Stop all services
docker compose down

# Stop and remove volumes
docker compose down -v
```

---

## 🔧 Configuration

### Database Connection

Edit `appsettings.json` to configure your connection string:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=ourCheck;Username=admin;Password=secret"
  }
}
```

### Logging

Serilog is configured in `Program.cs`. Default output is console. To configure additional sinks, modify:

```csharp
builder.Host.UseSerilog((context, loggerConfiguration) =>
{
    loggerConfiguration.WriteTo.Console();
    loggerConfiguration.ReadFrom.Configuration(context.Configuration);
});
```

---

## 📊 Database Migrations

```bash
# Add a new migration
dotnet ef migrations add MigrationName --project src/OurCheck.Infrastructure --startup-project src/OurCheck.API

# Update database to latest migration
dotnet ef database update --project src/OurCheck.Infrastructure --startup-project src/OurCheck.API

# Rollback to specific migration
dotnet ef database update PreviousMigrationName --project src/OurCheck.Infrastructure --startup-project src/OurCheck.API

# Remove last migration (if not applied)
dotnet ef migrations remove --project src/OurCheck.Infrastructure --startup-project src/OurCheck.API

# Generate SQL script from migrations
dotnet ef migrations script --project src/OurCheck.Infrastructure --startup-project src/OurCheck.API --output migrations.sql
```

---

## 🚧 Future Improvements

- [ ] Add unit and integration test projects (xUnit, FluentAssertions, Testcontainers)
- [ ] Implement authentication & authorization (JWT/OAuth)
- [ ] Implement soft delete functionality
- [ ] Set up CI/CD pipeline (GitHub Actions/Azure DevOps)
- [ ] Add health check endpoints
- [ ] Implement rate limiting and throttling
- [ ] Add monitoring and telemetry (Application Insights/OpenTelemetry)

---

## 🤝 Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

1. Fork the project
2. Create your feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

---

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

---

## 👤 Author

**Dmytro Kudin**

- LinkedIn: [linkedin.com/in/dmytro-kudin-7a038815a](https://www.linkedin.com/in/dmytro-kudin-7a038815a/)
- GitHub: [@dmytro-kudin](https://github.com/dmytro-kudin)

---

## 🙏 Acknowledgments

- Built with modern .NET 10 and ASP.NET Core
- Inspired by Clean Architecture and Vertical Slice Architecture principles
- API documentation powered by [Scalar](https://github.com/scalar/scalar)

---

<div align="center">
  <strong>⭐ If you find this project useful, please consider giving it a star!</strong>
</div>