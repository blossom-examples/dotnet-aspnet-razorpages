#!/bin/bash

echo "Setting up database..."
echo "DATABASE_URL: $DATABASE_URL"
set -eux

# Change to the publish directory
cd bin/publish

# Update database using our application's db-update command
dotnet DemoApp.dll db-update