@echo off
:: -----------------------------------------
:: EF Core Migration Generator Script (.bat)
:: Usage: generate-migration.bat MigrationName
:: -----------------------------------------

:: Go to the directory where this script is located
cd /d %~dp0

:: Navigate to the ORM project folder
cd ../Sig.SecurityServiceTenant.ORM

:: Check if a migration name was provided
IF "%~1"=="" (
    echo Error: You must specify a migration name.
    echo Usage: generate-migration.bat MigrationName
    pause
    exit /b 1
)

:: Run EF Core migration command
dotnet ef migrations add %1 --startup-project ../Sig.SecurityServiceTenant.WebApi

pause
