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

## 2. Database
**PostgreSQL + Docker**

- Engine: **Postgres 16**
- Schema changes are managed with **EF Core Migrations**

