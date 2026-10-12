# 🔄 Unit Converter API

![Version](https://img.shields.io/badge/.NET-8.0-blue.svg)

A scalable, enterprise-grade REST API built in ASP.NET Core for converting numerical values between different units of measurement (Length, Mass, Temperature).

## 🚀 Getting Started

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- GitHub Codespaces or a local IDE (Visual Studio / VS Code)

### How to Run
1. Open your terminal in the root directory.
2. Build the solution to verify dependencies:
3. Run the API:
4. Open the provided local host URL in your browser and append `/swagger` to view the interactive API testing interface.

## 🏗 Architecture
This project uses a **Clean Architecture** approach divided into three tiers:
* **API (`UnitConverter.Api`):** HTTP routing, Swagger documentation, and Controller logic.
* **Services (`UnitConverter.Services`):** Business logic implementing the **Strategy Pattern** for scalable conversions.
* **Core (`UnitConverter.Core`):** Domain models, DTOs, and interface definitions.

### Adding New Units
The converter uses the Strategy Pattern to remain Open/Closed. To add a new category (e.g., Digital Storage):
1. Create a new class implementing `IUnitConverterStrategy` in the `Services/Strategies` folder.
2. Register the new strategy in `Program.cs` via Dependency Injection.