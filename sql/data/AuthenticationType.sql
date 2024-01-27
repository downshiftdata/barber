SET NOCOUNT ON;
GO

IF EXISTS (SELECT 1 FROM [barber].[AuthenticationType] WHERE [AuthenticationTypeKey] = 0)
    UPDATE [barber].[AuthenticationType]
        SET
            [AuthenticationTypeName] = N'(None)'
        WHERE [AuthenticationTypeKey] = 0;
ELSE
    INSERT INTO [barber].[AuthenticationType] (
            [AuthenticationTypeKey],
            [AuthenticationTypeName])
        SELECT
            0,
            N'(None)';
GO

IF EXISTS (SELECT 1 FROM [barber].[AuthenticationType] WHERE [AuthenticationTypeKey] = 1)
    UPDATE [barber].[AuthenticationType]
        SET
            [AuthenticationTypeName] = N'Windows'
        WHERE [AuthenticationTypeKey] = 1;
ELSE
    INSERT INTO [barber].[AuthenticationType] (
            [AuthenticationTypeKey],
            [AuthenticationTypeName])
        SELECT
            1,
            N'Windows';
GO

IF EXISTS (SELECT 1 FROM [barber].[AuthenticationType] WHERE [AuthenticationTypeKey] = 2)
    UPDATE [barber].[AuthenticationType]
        SET
            [AuthenticationTypeName] = N'SqlServer'
        WHERE [AuthenticationTypeKey] = 2;
ELSE
    INSERT INTO [barber].[AuthenticationType] (
            [AuthenticationTypeKey],
            [AuthenticationTypeName])
        SELECT
            2,
            N'SqlServer';
GO
