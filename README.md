# Voyager — Traveling System

An early portfolio project for browsing trips, finding activities, and managing travel-related posts. The application combines an ASP.NET Core MVC website, account pages, and SQL Server persistence.

**Status:** historical project source. This README describes the checked-in implementation; the original application has not been rebuilt or deployed as part of this documentation update.

[Ali Faour's portfolio](https://cyberfaour.github.io/Portfolio/) · [Companion bot](https://github.com/Cyberfaour/Voyager-AzureBot)

## What the source demonstrates

- A trip catalogue with detail pages and search by location, activity, or tag.
- Trip records containing descriptions, images, prices, and start/end dates.
- Create, read, update, and delete actions for trips and posts, with a separate administration interface.
- ASP.NET Core Identity registration, sign-in, and account-management pages.
- Entity Framework Core models and migrations, plus an embedded Bot Framework web-chat entry point on the homepage.

The project includes Voyager-specific models, controllers, and views alongside generated ASP.NET Identity scaffolding and third-party frontend assets. It is presented as an early example of connecting web pages, application logic, identity, and a relational database.

## Technology

| Layer | Checked-in implementation |
| --- | --- |
| Application | C#, ASP.NET Core MVC, Razor views; target framework `net6.0` |
| Data | Entity Framework Core 6.0.8, SQL Server provider |
| Accounts | ASP.NET Core Identity with `ApplicationDbContext` |
| Frontend | HTML, CSS, JavaScript, Bootstrap and AdminLTE assets |

Package versions are defined in [Voyager.csproj](Voyager.csproj). Application services and routing are registered in [Program.cs](Program.cs).

## Start with these files

| Location | Purpose |
| --- | --- |
| [Models](Models) | `Trip` and `Post` records |
| [Controllers](Controllers) | Homepage, trip, post, and administration actions |
| [Views](Views) | MVC pages and shared layouts |
| [Areas/Identity](Areas/Identity) | Scaffolded account workflows |
| [Data/ApplicationDbContext.cs](Data/ApplicationDbContext.cs) | Identity, trip, and post persistence |
| [Data/Migrations](Data/Migrations) | Database schema history |
| [wwwroot](wwwroot) | Styles, scripts, images, and other static assets |

## Local setup for the original implementation

Use an isolated development environment with a .NET 6 SDK/runtime, SQL Server or SQL Server LocalDB, and EF Core 6 tooling. The commands below document the original project structure and have not been executed during this documentation review.

1. Clone the repository and open its root directory.
2. Restore dependencies:

   ```sh
   dotnet restore Voyager.csproj
   ```

3. Override `ConnectionStrings:DefaultConnection` with a connection string for a **local development database you control**. The project already declares a user-secrets ID, so the setting can stay outside the repository:

   ```sh
   dotnet user-secrets set "ConnectionStrings:DefaultConnection" "<your-local-sql-server-connection-string>" --project Voyager.csproj
   ```

   `Program.cs` uses `DefaultConnection`; the other connection-string names in the original settings file are not the registered application's database connection.

4. Install EF Core 6 tooling if it is not already available, then apply the checked-in migrations to that development database:

   ```sh
   dotnet tool install --global dotnet-ef --version 6.0.8
   dotnet ef database update --context ApplicationDbContext --project Voyager.csproj
   ```

5. Start the development launch profile:

   ```sh
   dotnet run --project Voyager.csproj --launch-profile Voyager
   ```

   The checked-in profile uses `https://localhost:7163` and `http://localhost:5163`. Follow the local HTTPS certificate setup required by your development tools. The application requires account confirmation for sign-in; the scaffolded confirmation page includes a development confirmation link.

## Scope and limitations

This source snapshot needs an engineering review before shared deployment. In particular, `AdminController` has no controller-level authorization attribute, while `TripsController` and `PostsController` require a signed-in user. Complete and verify the intended permissions before exposing administration actions.

The original dependencies, database configuration, and account/email flow also need review when modernizing the application. The homepage's hosted chat depends on the separate bot project and its services; local website startup does not establish that the chat integration works. No working public demo or current build result is claimed here.
