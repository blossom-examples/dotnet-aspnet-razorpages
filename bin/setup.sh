#!/bin/bash
set -eux

# Create local tool manifest if it doesn't exist
if [ ! -f ".config/dotnet-tools.json" ]; then
    dotnet new tool-manifest
fi

# Install/restore local tools
dotnet tool install --local dotnet-ef --version 9.0.3 || true
dotnet tool restore

# Restore project dependencies
dotnet restore

# Build and publish the application
dotnet publish -c Release -o bin/publish