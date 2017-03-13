How to use EFCore Migrations with Console App
=============================================

This sample shows how to use Entity Framework Core Migrations CLI tools in a .NET Core Console application.

The Solution
------------

This sample application is contained in a single executable assembly.

Assembly    | Description
------------|------------
CLI         | Contains the DbContext

Running Commands
----------------

To run the commands, `CLI` should be used as the startup project (`-StartupProject` in PMC and `--startup-project` in CLI).

```sh
dotnet restore
cd src/CLI
dotnet ef migrations add Init
dotnet ef database update
```

Points of Interest
------------------

There is a simple trick to get this all to work. The EFCore tooling looks for an implementation of
`IDbContextFactory<TContext>` to construct the DbContext instance. If it exists, it will be sued and the EF CLI tool will function as expected.

Note that you cannot pass dependencies in to the implementation of `IDbContextFactory<TContext>`. According to this issue, the EFCore tooling will only consume ServiceCollections wired up in a ASP.NET Core Startup class. It will not look for
any other implentation of a service builder.
