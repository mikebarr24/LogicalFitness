# GitHub Copilot / AI agent instructions for LogicalFitness (concise)

Purpose: Short, actionable notes to make an AI coding agent productive quickly in this repo.

## Big picture (what matters) ✅

- Clean Architecture split: Domain (`src/libs/LogicalFitness.Domain`), Application (`src/libs/LogicalFitness.Application`), Infrastructure (`src/libs/LogicalFitness.Infrastructure`), Presentation: API (`src/apps/LogicalFitness.Api`) and AppHost (`src/apps/LogicalFitness.AppHost`).
- `AppHost` (Aspire) provisions infra (Postgres, volumes) and wires logical DB name `db-logical-fitness` to the API at runtime (see `src/apps/LogicalFitness.AppHost/AppHost.cs`).
- `LogicalFitness.Api` is a Minimal API that registers services and auto-discovers endpoints (see `Program.cs`).

## Quick commands & workflows 🔧

- Build: `dotnet build` (run from repo root)
- Run AppHost (requires Docker):
  - `dotnet run --project src/apps/LogicalFitness.AppHost` (provisions Postgres; host port configured in `AppHost.cs` (51571) in the example)
- Run API locally (needs connection string set):
  - `dotnet run --project src/apps/LogicalFitness.Api`
  - Ensure `ConnectionStrings:db-logical-fitness` is set in `appsettings.*` or environment variables before starting.
- EF migrations (API project is the migrations assembly):
  - Add: `dotnet ef migrations add <Name> --project src/apps/LogicalFitness.Api --startup-project src/apps/LogicalFitness.Api`
  - Apply: `dotnet ef database update --project src/apps/LogicalFitness.Api --startup-project src/apps/LogicalFitness.Api`

## Project-specific conventions & patterns ⚙️

- Endpoint discovery: implement `IEndpoint` (file: `src/apps/LogicalFitness.Api/Abstractions/IEndpoint.cs`). The API calls `AddEndpoints(Assembly)` which registers all non-abstract `IEndpoint` types, and `MapEndpoints()` invokes each `MapEndpoint` (see `Extensions/EndpointExtensions.cs`). Example: `src/apps/LogicalFitness.Api/Endpoints/Users/AddUser.cs`.
- Service registration: `src/apps/LogicalFitness.Api/Extensions/ServiceExtensions.cs` registers app services (e.g., `IUserService -> UserService`). Prefer adding service registrations here.
- Validation: Uses FluentValidation. API registers validators in `Extensions/ValidationExtensions.cs` (example: `IValidator<UserDto>` -> `UserDtoValidator`).
- Commands & MediatR: Application uses MediatR (commands/handlers e.g., `AddUserCommand`, `AddUserCommandHandler`). Endpoints expect an `ISender` (injected by DI) and call `sender.Send(command, ct)`. Verify MediatR is registered in DI if you're adding handlers/using `ISender`.
- DB rules: `AppDbContext` configures a unique index on `User.Email` (see `src/libs/LogicalFitness.Infrastructure/Data/AppDbContext.cs`). Command handlers check uniqueness and throw `InvalidOperationException` when violated—tests rely on that behavior.
- Migrations Assembly: `UseNpgsql(..., options => options.MigrationsAssembly("LogicalFitness.Api"))`—migrations live in the API project under `Migrations/`.

## Tests & integration notes 🧪

- Integration test scaffolding exists in `tests/LogicalFitness.Tests`. `GlobalSetup.cs` shows how to start your Aspire AppHost for tests using `DistributedApplicationTestingBuilder` (commented). To enable, add a `<ProjectReference>` to your AppHost in the test project and uncomment the setup.
- Tests use retry attributes and may rely on the Aspire test harness; follow existing test examples when adding integration tests.

## Small style & idioms to match 📝

- Prefer small focused services and commands (Application layer) that are consumed by endpoints.
- Use DTO -> Domain mapping helpers where available (e.g., `UserDto.MapUserDtoToUser`).
- Handle domain validation via FluentValidation in the Application layer validators and register them in the API.
- Exceptions thrown in handlers are simple (e.g., `InvalidOperationException`) and relied upon by tests—be conservative about changing them.

---

If anything above is unclear or you want me to add more examples (e.g., how to register MediatR or add a migration end-to-end), tell me which topic to expand and I’ll update this file. ✅
