# ASP.NET Core Razor Pages Todo App

A simple Todo application built with ASP.NET Core Razor Pages and PostgreSQL, ready to deploy on [Blossom](https://blossom-cloud.com).

## Quick Start

```bash
# Install dependencies
bin/setup.sh

# Set up database
bin/db-setup.sh

# Run the app
dotnet run
```

Visit `http://localhost:5137` in your browser to see the demo application.

## Environment Variables

- `DATABASE_URL`: PostgreSQL connection string (required for production)
