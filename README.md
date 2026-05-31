# 🖥️ C# .NET Console App — Learning Project

> A hands-on C# learning project built while completing the **C# .NET Tutorial for Complete Beginners — Masterclass** on Udemy.  
> Covers OOP, Entity Framework Core, MySQL integration, Dependency Injection, and Database Migrations.

[![C#](https://img.shields.io/badge/C%23-.NET%209-512BD4?style=flat&logo=dotnet)](https://dotnet.microsoft.com/)
[![EF Core](https://img.shields.io/badge/Entity%20Framework-Core%209.0-purple?style=flat)](https://learn.microsoft.com/en-us/ef/core/)
[![MySQL](https://img.shields.io/badge/Database-MySQL%208.0-4479A1?style=flat&logo=mysql&logoColor=white)](https://www.mysql.com/)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE.txt)

---

## 📁 Project Structure

```
ConsoleApp/
├── ConsoleApp/                  # Main console application
│   ├── Program.cs               # Entry point, DI setup, app logic
│   └── Person.cs                # Person class with OOP methods
│
├── Csharp.Entites/              # Class Library (Data Layer)
│   ├── Context.cs               # EF Core DbContext
│   ├── ContextFactory.cs        # Design-time DB factory
│   └── Model/
│       ├── PersonEntity.cs      # Person database model
│       └── CarCompany.cs        # CarCompany database model
│
├── ConsoleApp.slnx              # Solution file
└── README.md
```

---

## ✨ Features

- ✅ **Object-Oriented Programming** — Classes, properties, methods, encapsulation
- ✅ **Entity Framework Core 9** — Code-first database approach
- ✅ **MySQL Integration** — Via Pomelo.EntityFrameworkCore.MySql
- ✅ **Dependency Injection** — Using `IServiceCollection` & `ServiceProvider`
- ✅ **Database Migrations** — `Add-Migration` & `Update-Database` workflow
- ✅ **Foreign Key Relationships** — `CarCompany` linked to `PersonEntity`
- ✅ **GUID Primary Keys** — Unique identifiers for all entities
- ✅ **CRUD Operations** — Save and retrieve data from MySQL

---

## 🗄️ Database Schema

### `PersonEntity` Table
| Column | Type | Constraints |
|--------|------|-------------|
| `PersonEntityID` | `GUID` | Primary Key |
| `FullName` | `VARCHAR` | Required |
| `Age` | `INT` | Required |

### `CarCompanies` Table
| Column | Type | Constraints |
|--------|------|-------------|
| `CarID` | `GUID` | Primary Key |
| `CarName` | `VARCHAR` | Required |
| `PersonEntityID` | `GUID` | Foreign Key → PersonEntity |

> **Relationship:** One `Person` → Many `CarCompanies` (One-to-Many with CASCADE DELETE)

---

## ⚙️ Tech Stack

| Technology | Version | Purpose |
|-----------|---------|---------|
| C# / .NET | 9.0 | Core language & runtime |
| Entity Framework Core | 9.0.0 | ORM / Database management |
| Pomelo.EntityFrameworkCore.MySql | 9.0.0 | MySQL database provider |
| MySQL | 8.0 | Database |
| MySQL Workbench | 8.0 CE | Database GUI |
| Visual Studio | 2022 | IDE |

---

## 🚀 Getting Started

### Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [MySQL Server 8.0](https://dev.mysql.com/downloads/mysql/)
- [MySQL Workbench](https://dev.mysql.com/downloads/workbench/) *(optional, for GUI)*
- Visual Studio 2022

---

### 1️⃣ Clone the Repository

```bash
git clone https://github.com/hammadrahil/ConsoleApp.git
cd ConsoleApp
```

---

### 2️⃣ Set Up the Database

Open **MySQL Workbench** and run:

```sql
CREATE DATABASE CarCompanyDB;
```

---

### 3️⃣ Configure Connection String

In `Csharp.Entites/ContextFactory.cs`, update your connection string:

```csharp
public static string ConnectionString = 
    "Server=localhost;Port=3306;Database=CarCompanyDB;User=root;Password=YOUR_PASSWORD;SslMode=Preferred;";
```

Also update `Program.cs` to match the same connection string.

---

### 4️⃣ Install NuGet Packages

In **Visual Studio Package Manager Console**, set Default Project to `Csharp.Entites` and run:

```powershell
Install-Package Pomelo.EntityFrameworkCore.MySql -Version 9.0.0
Install-Package Microsoft.EntityFrameworkCore.Tools -Version 9.0.0
Install-Package Microsoft.EntityFrameworkCore.Design -Version 9.0.0
```

---

### 5️⃣ Run Database Migrations

In **Package Manager Console** (Default Project: `Csharp.Entites`):

```powershell
Add-Migration InitialCreate
Update-Database
```

Expected output:
```
Build started...
Build succeeded.
Applying migration 'InitialCreate'.
Done.
```

---

### 6️⃣ Run the Application

Press **F5** in Visual Studio or:

```bash
cd ConsoleApp
dotnet run
```

The app will prompt:
```
What is your name?
> Muhammad Hammad

What is your age?
> 22

Can you name a car company?
> Toyota

Can you name a car company?
> Honda

Can you name a car company?
> BMW

Your name is Muhammad Hammad and you are 22 years old.
Toyota
Honda
BMW
```

---

## 🔄 Migration History

| Migration | Description |
|-----------|-------------|
| `InitialCreate` | Creates `PersonEntity` and `CarCompanies` tables |
| `AddedForeignKeyToCarCompany` | Adds `PersonEntityID` foreign key to `CarCompanies` with CASCADE DELETE |

---

## 🏗️ Key Code Highlights

### Dependency Injection Setup
```csharp
private static void _registerServiceProvider()
{
    IServiceCollection services = new ServiceCollection();
    services.AddDbContext<Context>(options => 
        options.UseMySql(ContextFactory.ConnectionString,
            ServerVersion.AutoDetect(ContextFactory.ConnectionString)));
    services.AddTransient<Context>();
    ServiceProvider = services.BuildServiceProvider();
}
```

### EF Core DbContext
```csharp
public class Context : DbContext
{
    public Context(DbContextOptions<Context> options) : base(options) { }

    public DbSet<PersonEntity> PersonEntity { get; set; } = default!;
    public DbSet<CarCompany> CarCompanies { get; set; } = default!;
}
```

### Saving to Database
```csharp
public void SavePersonInDatabase(Context context)
{
    context.PersonEntity.Add(new PersonEntity()
    {
        PersonEntityID = Guid.NewGuid(),
        FullName = this.FullName,
        Age = this.Age
    });
    context.SaveChanges();
}
```

---

## 📚 What I Learned

- Setting up a **multi-project C# solution** (Console App + Class Library)
- Implementing **OOP principles** with classes, properties, and methods
- Using **Entity Framework Core** with a code-first approach
- Configuring **MySQL** as a database provider with Pomelo
- Setting up **Dependency Injection** from scratch
- Running **database migrations** and resolving version conflicts
- Defining **foreign key relationships** between entities
- Handling **NuGet package version compatibility** between projects

---

## 🎓 Certificate

This project was built as part of the Udemy course:

**C# .NET Tutorial for Complete Beginners — Masterclass in 3h**  
Instructor: Jordan Smith | Completed: June 1, 2026

[🔗 View Certificate](https://ude.my/UC-758aa51b-83de-43d8-9648-1be43e5d107d)

---

## 👤 Author

**Muhammad Hammad**  
WordPress & Shopify Developer | Learning C# & .NET Backend Development

- 💼 LinkedIn: [linkedin.com/in/hammadrahil](https://linkedin.com/in/hammadrahil)
- 📧 Email: hammadmen@gmail.com

---

## 📄 License

This project is licensed under the MIT License — see [LICENSE.txt](LICENSE.txt) for details.
