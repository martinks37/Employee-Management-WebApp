[README.md](https://github.com/user-attachments/files/29995113/README.md)
# Employee Manager — Full Stack Application

A full stack Employee Management application.

---

## Tech Stack

| Layer | Technology |
|---|---|
| Frontend | Angular 17+ |
| Backend | ASP.NET Core Web API (C#) |
| Database | MySQL |
| API Testing | Postman / Swagger |

---

## Project Structure

```
EmployeeManager/
│
├── EmployeeAPI/                  # ASP.NET Core Web API
│   ├── Controllers/
│   │   └── EmployeeController.cs # All 5 CRUD endpoints
│   ├── Models/
│   │   └── Employee.cs           # Employee data model
│   ├── Data/
│   │   └── DatabaseHelper.cs     # MySQL connection helper
│   ├── appsettings.json          # DB connection string
│   └── Program.cs                # App configuration & middleware
│
└── EmployeeApp/                  # Angular Frontend
    └── src/
        └── app/
            ├── models/
            │   └── employee.ts           # Employee interface
            ├── services/
            │   └── employee.service.ts   # API calls via HttpClient
            ├── employee-list/
            │   ├── employee-list.ts      # Component logic
            │   ├── employee-list.html    # Component template
            │   └── employee-list.css     # Component styles
            ├── app.ts                    # Root component
            ├── app.config.ts             # App configuration
            └── app.routes.ts             # Routing config
```

---

## Features

- View all employees in a table
- Get employee by ID
- Add a new employee
- Update an existing employee
- Delete an employee

---

## API Endpoints

| Method | Endpoint | Description |
|---|---|---|
| GET | `/api/Employee` | Get all employees |
| GET | `/api/Employee/{id}` | Get employee by ID |
| POST | `/api/Employee` | Add new employee |
| PUT | `/api/Employee/{id}` | Update employee |
| DELETE | `/api/Employee/{id}` | Delete employee |

---

## Database Schema

```sql
CREATE DATABASE EmployeeDB;
USE EmployeeDB;

CREATE TABLE Employees (
    Id       INT          PRIMARY KEY AUTO_INCREMENT,
    Name     VARCHAR(100) NOT NULL,
    Position VARCHAR(100) NOT NULL,
    Salary   DECIMAL(10,2)
);
```

---

## Getting Started

### Prerequisites

- Visual Studio 2022
- .NET 6.0 or higher
- MySQL Server & MySQL Workbench
- Node.js & npm
- Angular CLI (`npm install -g @angular/cli`)
- Postman (optional, for API testing)

---

### 1. Database Setup

Open MySQL Workbench and run:

```sql
CREATE DATABASE EmployeeDB;
USE EmployeeDB;

CREATE TABLE Employees (
    Id       INT          PRIMARY KEY AUTO_INCREMENT,
    Name     VARCHAR(100) NOT NULL,
    Position VARCHAR(100) NOT NULL,
    Salary   DECIMAL(10,2)
);

INSERT INTO Employees (Name, Position, Salary) VALUES ('John', 'Manager', 55000);
INSERT INTO Employees (Name, Position, Salary) VALUES ('Sara', 'Developer', 45000);
INSERT INTO Employees (Name, Position, Salary) VALUES ('Martin', 'Developer', 47000);
```

---

### 2. Backend Setup (ASP.NET API)

1. Open `EmployeeAPI` folder in Visual Studio
2. Update `appsettings.json` with your MySQL credentials:

```json
"ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=EmployeeDB;User=root;Password=yourpassword;"
}
```

3. Press **F5** to run the API
4. Swagger UI opens at `https://localhost:7234/swagger`

---

### 3. Frontend Setup (Angular)

```bash
cd EmployeeApp
npm install
ng serve
```

Open your browser at `http://localhost:4200`

---

## How It Works

```
Angular (localhost:4200)
        ↓  HTTP Request
ASP.NET API (localhost:7234)
        ↓  SQL Query
MySQL Database
        ↓  Data
        ↑  JSON Response
        ↑
Angular displays data in browser
```

---

## Coding Standards

This project follows Standard coding conventions:

- Member variables prefixed with `m_` and type prefix (e.g. `m_strName`, `m_iCount`)
- Classes and methods use PascalCase (e.g. `EmployeeController`, `GetAll()`)
- Constants use FULL_CAPS_SNAKE_CASE (e.g. `MAX_RETRY_COUNT`)
- Properties use PascalCase with no type prefix (e.g. `TotalAmount`)
- One variable declaration per line
- Parameterized SQL queries to prevent SQL injection

---

## What I Learned

Building this project covered the full Software Engineering syllabus:

- **C# & OOP** — all 4 pillars (encapsulation, inheritance, polymorphism, abstraction), generics, LINQ, lambda expressions, exception handling
- **MySQL** — CRUD, constraints, joins, stored procedures, normalization (1NF, 2NF, 3NF)
- **ASP.NET Web API** — REST principles, routing, dependency injection, CORS configuration
- **Angular** — components, services, HttpClient, Observables, data binding, lifecycle hooks
- **Full Stack Integration** — connecting Angular frontend to C# API to MySQL database

---

## Author

Martin — Fresher Developer
