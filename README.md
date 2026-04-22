# UPZMG
Administration system for UPZMG - Modular project

## 1. Architecture
**ASP.NET Core MVC**

| Project | What handles? |
| --- | --- |
| **Modules** |  Feature modules: Academic, RRHH, etc. with domain/application logic |
| **UPZMG.Api** | REST API (JSON endpoints), JWT Token issuing, Business operations
| **UPZMG.Web** |  UI, Login (Cookie Auth), Role-Based pages
| **UPZMG.Persistence** |  Class Library: EF Core DbContext, Entity configurations, Migrations
| **UPZMG.Shared** | Shared primitives: Result pattern, DTOs, constants, errors, helpers

### Authentication & Authorization

## Highlights

- **Modular Architecture:** Each domain module is isolated in its own module for maintainability and scalability.
- **ASP.NET Core MVC:** Modern, robust web framework for both UI and API layers.
- **Secure Authentication:** Cookie-based authentication for the web, JWT Bearer tokens for API .access.
- **EF Core + PostgreSQL:** Strong ORM with code-first migrations, leveraging PostgreSQL for reliability and performance.
- **Dockerized Database:** Easy local development and deployment using Docker Compose for PostgreSQL.
- **Separation of Concerns:** Clear boundaries between UI, API, persistence, and shared logic.
- **Role-Based Access:** Fine-grained authorization for different user roles.
- **Extensible:** Easily add new modules/features without impacting existing functionality.

- **UPZMG.Web** authenticates users using **Cookie Authentication**
- **UPZMG.Api** is protected using **JWT Bearer tokens**
- Token flow:
  1. Web authenticates the user and creates a Cookie session
  2. Web requests a JWT from API via `POST /auth/token` (internal shared secret)
  3. Web calls API endpoints using `Authorization: Bearer <token>`

### Secrets Configuration

Secrets must not be stored in `appsettings*.json`.

For local development, store them with `dotnet user-secrets`:

```powershell
dotnet user-secrets set "Jwt:Key" "<long-random-jwt-signing-key>" --project .\UPZMG.API
dotnet user-secrets set "InternalAuth:WebSharedSecret" "<long-random-shared-secret>" --project .\UPZMG.API
dotnet user-secrets set "InternalAuth:WebSharedSecret" "<same-long-random-shared-secret>" --project .\UPZMG.Web
```

For production, use environment variables or a secret manager:

```powershell
$env:Jwt__Key = "<long-random-jwt-signing-key>"
$env:InternalAuth__WebSharedSecret = "<long-random-shared-secret>"
```

Rotation steps:

1. Generate a new JWT signing key and a new internal shared secret.
2. Update the API secret store with both new values.
3. Update the Web secret store with the new internal shared secret.
4. Restart both applications so they pick up the new configuration.
5. Invalidate existing API tokens if immediate cutover is required.

## 2. Database
**PostgreSQL + Docker**

- Engine: **Postgres 16**
- Schema changes are managed with **EF Core Migrations**

