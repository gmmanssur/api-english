🚀 English Path Game (EPG) – API

English Path Game (EPG) is a SaaS-based platform designed to make English learning dynamic, engaging, and gamified.

The core idea is to combine:

🧩 Puzzles

🎯 Challenges

🏆 Badges

🎮 Missions

📚 Structured learning paths

Instead of passive study, EPG focuses on interactive progression and game mechanics to reinforce learning.

🏗️ Architecture Overview

The project follows Clean Architecture principles, ensuring:

Separation of concerns

Scalability

Testability

Maintainability

Low coupling between layers

Current architecture layers:

Domain
Application
Infrastructure
API

The project is structured using a feature-based vertical slice approach, especially for authentication.

🛠️ Tech Stack
Backend

.NET 10

C#

ASP.NET Core Web API

Database

PostgreSQL

Entity Framework Core (Persistence layer)

Authentication & Security

ASP.NET Identity (planned integration)

JWT (Access Token)

Refresh Token (planned for session continuity)

BCrypt password hashing

FluentValidation

MediatR

Command/Handler pattern (CQRS approach)

Frontend

React (planned, not implemented yet)

🔐 Authentication Module (Current Focus)

The project currently implements a production-ready Authentication module, designed for SaaS scalability.

Implemented Features
✔ Register Endpoint

User account creation

Password hashing with BCrypt

DTO validation using FluentValidation

Clean separation between Request, Command, and Domain

Persistence in PostgreSQL

✔ Login Endpoint

Credential validation

Secure password verification

JWT Access Token generation

Stateless authentication

🧠 Architectural Decisions
1️⃣ Clean Architecture

Authentication logic is implemented inside the Application layer using:

RegisterCommand

LoginCommand

Handlers

Response models

The API layer only handles HTTP contracts.

Infrastructure is responsible for:

PostgreSQL integration

JWT generation

Password hashing

Repository implementation

2️⃣ Security Approach

Passwords are never stored in plain text

BCrypt hashing algorithm

Short-lived JWT tokens

Stateless authentication

Separation between validation and persistence logic

3️⃣ Validation Strategy

FluentValidation is used to:

Validate DTOs before business logic execution

Enforce password rules

Enforce email format

Keep controllers clean

📂 Current Project Structure (Simplified)

API
 └── Controllers
      └── AuthController

Application
 └── Features
      └── Auth
           ├── Register
           ├── Login
           └── Handlers

Infrastructure
 ├── Persistence (PostgreSQL)
 ├── Jwt
 └── Identity / Security

Domain
 └── Core Entities (User - evolving)


🎯 Project Goals

Build a scalable SaaS architecture

Implement secure authentication from scratch

Apply Clean Architecture correctly

Prepare system for:

Multi-tenant evolution

Subscription plans

Gamification engine

Ranking system

Progress tracking

Mobile expansion

📈 Roadmap
🔜 Next Steps

Refresh Token implementation

Email confirmation flow

Password reset flow

Role & Claim-based authorization

User progression model (XP, Levels, Streaks)

Stripe integration (subscription model)

React frontend implementation

💡 Vision

EPG is designed not just as a study tool, but as a scalable SaaS platform that:

Encourages consistent learning

Uses gamification psychology

Tracks measurable progress

Can evolve into a commercial product