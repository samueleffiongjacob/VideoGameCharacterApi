# VideoGameCharacterApi

This project is a Web API for managing Video Game Characters. It is built using .NET 10, Entity Framework Core, and Scalar.

## Scalar

**What it does:**
Scalar is an API reference generator that provides a modern, interactive documentation UI for your OpenAPI/Swagger specifications. In this project, it replaces SwaggerUI to offer a sleek interface for viewing and testing API endpoints.

**Installation & Setup:**
1. Install the `Scalar.AspNetCore` package via NuGet.
2. In your `Program.cs`, you can map the Scalar API reference endpoint.

```csharp
// In Program.cs
if (app.Environment.IsDevelopment())
{
    app.MapScalarApiReference();
}
```

**Usage:**
Once the application is running in Development mode, you can navigate to the `/scalar/v1` endpoint (or the default mapped route) in your browser to view the interactive API documentation.

---

## Database Setup (Entity Framework Core & SQL Server)

This project uses Entity Framework Core with SQL Server.

### Connection String

Define your connection string in the `appsettings.json` file. 

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=.\\SQLEXPRESS;Database=VideoGameCharacterDb;Trusted_Connection=True;TrustServerCertificate=True"
  }
}
```
*(Note: If you do not have a full SQL Server instance or it is not named `SQLEXPRESS`, you can use LocalDB with `"Server=(localdb)\\mssqllocaldb;..."`)*

### Required NuGet Packages

You can search for these in the NuGet Package Manager and make sure to pick the official Microsoft `10.0.x` packages:

**Providers:**
- `Microsoft.EntityFrameworkCore`
- `Microsoft.EntityFrameworkCore.SqlServer`

**Tools:**
- `Microsoft.EntityFrameworkCore.Tools` (For Visual Studio Package Manager Console)
- `Microsoft.EntityFrameworkCore.Design` (Required for EF Core design-time tools)

### Entity Framework Core Workflow

Once your packages are installed and your `AppDbContext` is registered in `Program.cs`, follow these steps to create and apply migrations:

#### Visual Studio (Package Manager Console)

Open the Package Manager Console via **View > Other Windows > Package Manager Console**.

1. **Create initial migration:**
   ```powershell
   Add-Migration Initial
   ```
2. **Apply migration to the database:**
   ```powershell
   Update-Database
   ```
3. **Remove the last migration** (if needed before updating the database):
   ```powershell
   Remove-Migration
   ```

#### VS Code / CLI (Bash or PowerShell)

Ensure you have the EF Core tools installed globally (`dotnet tool install --global dotnet-ef`). Navigate to the project directory in your terminal before running these commands:

1. **Create initial migration:**
   ```bash
   dotnet ef migrations add Initial
   ```
2. **Apply migration to the database:**
   ```bash
   dotnet ef database update
   ```
3. **Remove the last migration:**
   ```bash
   dotnet ef migrations remove
   ```

### Troubleshooting Database Connections
- Make sure your SQL Server service is running.
- Ensure the instance name (`SQLEXPRESS` vs `mssqllocaldb`) in your connection string matches what is actually installed on your machine.
- If using `SQLEXPRESS`, verify that SQL Server is configured to allow local connections.


---

## Project Folder Structure

We have adopted a clear, modular folder structure based on Separation of Concerns. This makes the codebase much easier for a beginner to navigate, and stops the application from becoming a tangled mess as it grows. Feel free to explore the `README.md` files placed inside each respective folder for a friendly explanation of how they work:

- **[Controllers](./VideoGameCharacterApi/Controllers/README.md)**: The "Front Desk". Handles incoming HTTP requests and maps them to endpoints.
- **[Services](./VideoGameCharacterApi/Services/README.md)**: The "Kitchen". Contains the core business logic of the application.
- **[Model](./VideoGameCharacterApi/Model/README.md)**: The "Blueprints". Defines core entities mapping exactly to our database schema.
- **[Dtos](./VideoGameCharacterApi/Dtos/README.md)**: The "Delivery Boxes". Data Transfer Objects to defensively shape data going in/out of the application.
- **[DataBase](./VideoGameCharacterApi/DataBase/README.md)**: The "Translator". Holds the Entity Framework Core Context (`AppDbContext`), securely translating C# into SQL execution.

---

## Docker

Docker helps us package this application into a "container" that can run consistently anywhere—whether that's your laptop, a coworker's machine, or a cloud server. 

**Why use Docker?**
- **No More "It works on my machine"**: Containers include the OS, the .NET 10 runtime, and your app all in one package. If it runs on your machine via Docker, it will run identically on the deployment server.
- **Environment Isolation**: You could spin up a containerized SQL Server database right next to your API container using Docker Compose. This means you don't even have to install SQL Express on your actual host OS, keeping your system fast and clean! To utilize it, simply run your `Dockerfile` using the standard `docker build` and `docker run` commands.