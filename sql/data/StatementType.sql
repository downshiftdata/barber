SET NOCOUNT ON;
GO

IF EXISTS (SELECT 1 FROM [barber].[StatementType] WHERE [StatementTypeKey] = 0)
    UPDATE [barber].[StatementType]
        SET
            [StatementTypeName] = N'(None)'
        WHERE [StatementTypeKey] = 0;
ELSE
    INSERT INTO [barber].[StatementType] (
            [StatementTypeKey],
            [StatementTypeName])
        SELECT
            0,
            N'(None)';
GO

IF EXISTS (SELECT 1 FROM [barber].[StatementType] WHERE [StatementTypeKey] = 1)
    UPDATE [barber].[StatementType]
        SET
            [StatementTypeName] = N'Custom'
        WHERE [StatementTypeKey] = 1;
ELSE
    INSERT INTO [barber].[StatementType] (
            [StatementTypeKey],
            [StatementTypeName])
        SELECT
            1,
            N'Custom';
GO

IF EXISTS (SELECT 1 FROM [barber].[StatementType] WHERE [StatementTypeKey] = 2)
    UPDATE [barber].[StatementType]
        SET
            [StatementTypeName] = N'Insert'
        WHERE [StatementTypeKey] = 2;
ELSE
    INSERT INTO [barber].[StatementType] (
            [StatementTypeKey],
            [StatementTypeName])
        SELECT
            2,
            N'Insert';
GO

IF EXISTS (SELECT 1 FROM [barber].[StatementType] WHERE [StatementTypeKey] = 3)
    UPDATE [barber].[StatementType]
        SET
            [StatementTypeName] = N'Update'
        WHERE [StatementTypeKey] = 3;
ELSE
    INSERT INTO [barber].[StatementType] (
            [StatementTypeKey],
            [StatementTypeName])
        SELECT
            3,
            N'Update';
GO

IF EXISTS (SELECT 1 FROM [barber].[StatementType] WHERE [StatementTypeKey] = 4)
    UPDATE [barber].[StatementType]
        SET
            [StatementTypeName] = N'Delete'
        WHERE [StatementTypeKey] = 4;
ELSE
    INSERT INTO [barber].[StatementType] (
            [StatementTypeKey],
            [StatementTypeName])
        SELECT
            4,
            N'Delete';
GO
