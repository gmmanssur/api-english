---
🚀 *English Path Game (EPG) – API*

*English Path Game (EPG)* is a platform designed to transform English learning into a dynamic, interactive, and gamified experience.

Instead of passive content consumption, EPG applies game mechanics and structured progression to reinforce learning through engagement.

---

🎮 *Core Learning Concept*

EPG combines:

- 🧩 Puzzles

- 🎯 Challenges

- 🏆 Achievement Badges

- 🎮 Missions

- 📚 Structured Learning Paths

The goal is to create measurable progression and sustained motivation using gamification psychology.

---

🏗️ *Architecture*

The project follows Clean Architecture principles combined with a CQRS-inspired approach using MediatR.

*Architectural Goals*

- Clear separation of concerns

- Scalability

- Testability

- Maintainability

- Low coupling between layers

- Vertical feature organization

---

🧱 *Layered Structure*
-> API
-> Application
-> Domain
-> Infrastructure

🔹 *API Layer*

- HTTP contracts

- Controllers

- Request/Response models

- No business logic

🔹 *Application Layer*

- Commands

- Handlers (CQRS pattern)

- Validation (FluentValidation)

- Business orchestration

- MediatR pipeline behaviors

🔹 *Domain Layer*

- Core entities

- Business rules

- Domain abstractions

🔹 *Infrastructure Layer*

- PostgreSQL integration

- Entity Framework Core

- JWT generation

- Password hashing (BCrypt)

- Repository implementations

🛠️ *Tech Stack Backend*

- .NET 10

- C#

- ASP.NET Core Web API

- MediatR

- FluentValidation

- CQRS (Command/Handler Pattern)

- Database

- PostgreSQL

- Entity Framework Core

- Security

- JWT (Access Token)

- BCrypt Password Hashing

- Refresh Token (planned)

- Role & Claims-based authorization (planned)

- Frontend (Planned)

- React
