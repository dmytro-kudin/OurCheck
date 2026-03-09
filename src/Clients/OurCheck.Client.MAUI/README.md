# OurCheck.Client.MAUI

**Layer:** Presentation Layer (Cross-Platform Mobile/Desktop)

This project represents the **.NET MAUI (Multi-platform App UI) Client Application**, providing a native cross-platform user interface for iOS, Android, macOS, and Windows. It follows **MVVM (Model-View-ViewModel)** pattern with **Clean Architecture** principles.

## Responsibilities

- Provides **native UI for iOS, Android, macOS, and Windows** using .NET MAUI
- Implements **MVVM pattern** using CommunityToolkit.Mvvm for ViewModels
- Orchestrates **navigation and user flows** via `AppShell`
- Handles **platform-specific concerns** (permissions, native APIs)
- Manages **dependency injection** and service composition (`MauiProgram.cs`, `ConfigureServices.cs`)
- Implements **structured logging** with Serilog for client-side diagnostics
- Configures **app settings** via `appsettings.json` (API URLs, logging levels)
- Uses **C# Markup** (CommunityToolkit.Maui.Markup) for declarative UI

## Target Platforms

- **iOS** 15.0+
- **Android** 21+ (Android 5.0 Lollipop)
- **macOS** (Catalyst) 15.0+
- **Windows** 10.0.17763.0+

## Dependencies

### Internal Dependencies
| Project | Reason |
|---------|--------|
| `OurCheck.Client.Application` | Client business logic and service orchestration |

### External Dependencies
| Package | Purpose |
|---------|---------|
| **Microsoft.Maui.Controls** (10.0.41) | Core MAUI framework for cross-platform UI |
| **CommunityToolkit.Mvvm** (8.4.0) | MVVM helpers (ObservableObject, RelayCommand, etc.) |
| **CommunityToolkit.Maui** (14.0.1) | Additional MAUI controls and behaviors |
| **CommunityToolkit.Maui.Markup** (7.0.1) | C# Markup for declarative UI |
| **MediatR** (14.1.0) | Optional: Command/Query pattern in ViewModels |
| **Serilog** (multiple packages) | Structured logging (Console, File sinks) |
| **Microsoft.Extensions.Hosting** (10.0.3) | Dependency injection and configuration |

## Key Components

| Component | Description |
|-----------|-------------|
| `MauiProgram.cs` | Application entry point, service registration, logging setup |
| `App.xaml / App.xaml.cs` | Application lifecycle management |
| `AppShell.cs` | Shell-based navigation and routing |
| `/Views` | XAML pages and C# Markup UI definitions |
| `/ViewModels` | MVVM ViewModels using CommunityToolkit.Mvvm |
| `/Setup` | Configuration and service registration helpers |
| `ConfigureServices.cs` | Dependency injection configuration |
| `appsettings.json` | Application configuration (API URLs, logging) |
| `/Platforms` | Platform-specific implementations (iOS, Android, Windows, macOS) |

## Architectural Rules

- ✅ **MUST** use MVVM pattern (Views, ViewModels, Models/Services)
- ✅ **MUST NOT** contain business logic in ViewModels (delegate to `OurCheck.Client.Application`)
- ✅ **MUST NOT** directly instantiate services (use dependency injection)
- ✅ **SHOULD** use `ObservableObject` and `RelayCommand` from CommunityToolkit.Mvvm
- ✅ **SHOULD** handle platform-specific code in `/Platforms` folder
- ✅ **SHOULD** use Shell navigation for routing between pages
- ✅ **MUST** configure HttpClient base URL via `appsettings.json`
- ✅ Uses **AOT (Ahead-of-Time) compilation** and **trimming** for optimized binaries
- ✅ Follows **single-project structure** for simplified multi-platform development

## Configuration

Configure the backend API URL in `appsettings.json`:

```json
{
  "ApiSettings": {
    "BaseUrl": "https://localhost:7198"
  },
  "Serilog": {
    "MinimumLevel": "Information"
  }
}
```

## Running the Application

### Prerequisites
- **.NET 10 SDK**
- **Visual Studio 2022** or **JetBrains Rider** with MAUI workload
- **Xcode** (for iOS/macOS development on macOS)
- **Android SDK** (for Android development)

### Run Commands
```bash
# Run on Android emulator
dotnet build -t:Run -f net10.0-android

# Run on iOS simulator (macOS only)
dotnet build -t:Run -f net10.0-ios

# Run on Windows
dotnet build -t:Run -f net10.0-windows10.0.19041.0
```

## Platform Support Matrix

| Platform | Minimum Version | Status |
|----------|----------------|--------|
| iOS | 15.0 | ✅ Supported |
| Android | 21 (Lollipop) | ✅ Supported |
| macOS (Catalyst) | 15.0 | ✅ Supported |
| Windows | 10.0.17763.0 | ✅ Supported |
