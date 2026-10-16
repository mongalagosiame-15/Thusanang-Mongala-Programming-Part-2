# Thusanang-Mongala-Programming-Part-2
git commit -m "chore: initialize ASP.NET Core Web API project structure for RaceDayAPI"

git commit -m "deps: install Entity Framework Core, SQL Server, and BCrypt NuGet packages"

git commit -m "config: configure database connection string in appsettings.json for RaceDayDB"

git commit -m "models: add entity classes for Organiser, Participant, Event, Category, Enrolment, and Result"

git commit -m "data: setup RaceDayDbContext and configure table relationships and constraints"
git commit -m "dto: add RegisterDto and LoginDto transfer objects"

git commit -m "config: configure session middleware in Program.cs for role-based session state"

git commit -m "auth: create AuthController skeleton and dependency injection setup"

git commit -m "auth: implement secure user registration with BCrypt password hashing"

git commit -m "auth: implement user login endpoint with session tracking for roles"

git commit -m "auth: add logout endpoint to clear active user sessions"
git commit -m "events: implement GET endpoints to view events and associated categories"

git commit -m "events: implement POST endpoint for event creation restricted to Organisers"

git commit -m "events: implement DELETE endpoint for event removal with role validation"

git commit -m "enrolments: implement participant event enrolment endpoint with session checks"
