SET NOCOUNT ON;
GO

IF EXISTS (SELECT 1 FROM [barber].[EnvironmentType] WHERE [EnvironmentTypeKey] = 0)
    UPDATE [barber].[EnvironmentType]
        SET
            [EnvironmentTypeName] = N'(None)'
        WHERE [EnvironmentTypeKey] = 0;
ELSE
    INSERT INTO [barber].[EnvironmentType] (
            [EnvironmentTypeKey],
            [EnvironmentTypeName])
        SELECT
            0,
            N'(None)';
GO

IF EXISTS (SELECT 1 FROM [barber].[EnvironmentType] WHERE [EnvironmentTypeKey] = 1)
    UPDATE [barber].[EnvironmentType]
        SET
            [EnvironmentTypeName] = N'Production'
        WHERE [EnvironmentTypeKey] = 1;
ELSE
    INSERT INTO [barber].[EnvironmentType] (
            [EnvironmentTypeKey],
            [EnvironmentTypeName])
        SELECT
            1,
            N'Production';
GO

IF EXISTS (SELECT 1 FROM [barber].[EnvironmentType] WHERE [EnvironmentTypeKey] = 2)
    UPDATE [barber].[EnvironmentType]
        SET
            [EnvironmentTypeName] = N'Staging'
        WHERE [EnvironmentTypeKey] = 2;
ELSE
    INSERT INTO [barber].[EnvironmentType] (
            [EnvironmentTypeKey],
            [EnvironmentTypeName])
        SELECT
            2,
            N'Staging';
GO

IF EXISTS (SELECT 1 FROM [barber].[EnvironmentType] WHERE [EnvironmentTypeKey] = 3)
    UPDATE [barber].[EnvironmentType]
        SET
            [EnvironmentTypeName] = N'Test'
        WHERE [EnvironmentTypeKey] = 3;
ELSE
    INSERT INTO [barber].[EnvironmentType] (
            [EnvironmentTypeKey],
            [EnvironmentTypeName])
        SELECT
            3,
            N'Test';
GO

IF EXISTS (SELECT 1 FROM [barber].[EnvironmentType] WHERE [EnvironmentTypeKey] = 4)
    UPDATE [barber].[EnvironmentType]
        SET
            [EnvironmentTypeName] = N'Development'
        WHERE [EnvironmentTypeKey] = 4;
ELSE
    INSERT INTO [barber].[EnvironmentType] (
            [EnvironmentTypeKey],
            [EnvironmentTypeName])
        SELECT
            4,
            N'Development';
GO
