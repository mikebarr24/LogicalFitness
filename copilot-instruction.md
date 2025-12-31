# GitHub Copilot / AI agent instructions for LogicalFitness (concise)

Purpose: Short, actionable notes to make an AI coding agent productive quickly. Note: This repository follows Clean Architecture (Domain / Infrastructure / Presentation).

- Big picture

  - `src/apps/LogicalFitness.Api/Program.cs` — Minimal API, DI for `AppDbContext`, reads connection string `db-logical-fitness`.
  - `src/apps/LogicalFitness.AppHost/AppHost.cs` — Aspire AppHost provisions Postgres and volumes; DB logical name maps to connection string key.
  - Layers: Domain (`src/libs/LogicalFitness.Domain`), Infrastructure (`src/libs/LogicalFitness.Infrastructure`), Presentation (Api), Tests (`LogicalFitness.Tests`).

- Key conventions

  - Use Aspire AppHost to provision infra (`AddPostgres("pg-...")`, `AddDatabase("db-...")`).
  - Shared defaults in `LogicalFitness.ServiceDefaults` (OpenTelemetry, health checks, HTTP client defaults).
  - Health endpoints only enabled in Development by default.
  - DB uses Npgsql + EF Core. `AppDbContext` configures model indices (see unique Email).

- Commands
  - Build: `dotnet build`
  - Run AppHost: `dotnet run --project src/apps/LogicalFitness.AppHost` (Docker required)
  - Run API: `dotnet run --project src/apps/LogicalFitness.Api` (ensure `ConnectionStrings:db-logical-fitness` present)
  - Tests: `dotnet test ./LogicalFitness.Tests` (integration test scaffolding in `GlobalSetup.cs`)
