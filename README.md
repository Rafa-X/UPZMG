# UPZMG
Administration system for UPZMG - Modular project

## 1. Architecture
**ASP.NET Core MVC**

| Project | What handles? |
| --- | --- |
| **UPZMG.Web** |  UI, Login (Cookie Auth), Role-Based pages
| **UPZMG.Api** | REST API (JSON endpoints), JWT Token issuing, Business operations
| **UPZMG.Persistence** |  Class Library: EF Core DbContext, Entity configurations, Migrations
| **UPZMG.Shared** | Shared primitives: Result pattern, DTOs, constants, errors, helpers
| **Modules** |  Feature modules: Academic, RRHH, etc. with domain/application logic |

### Authentication & Authorization
- **UPZMG.Web** authenticates users using **Cookie Authentication**
- **UPZMG.Api** is protected using **JWT Bearer tokens**
- Token flow:
  1. Web authenticates the user and creates a Cookie session
  2. Web requests a JWT from API via `POST /auth/token` (internal shared secret)
  3. Web calls API endpoints using `Authorization: Bearer <token>`

## 2. Database
**PostgreSQL + Docker**

- Engine: **Postgres 16**
- DB is created using `docker-compose.yml`
- Schema changes are managed with **EF Core Migrations**

