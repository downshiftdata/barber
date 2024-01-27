IF NOT EXISTS (SELECT 1 FROM sys.database_principals WHERE [name] = N'barber')
    CREATE USER [barber] WITHOUT LOGIN;
GO

IF NOT EXISTS (SELECT 1 FROM sys.schemas WHERE [name] = N'barber')
    EXEC (N'CREATE SCHEMA [barber] AUTHORIZATION [barber];');
GO
