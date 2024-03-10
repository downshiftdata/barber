CREATE OR ALTER PROCEDURE [barber].[Database_Update]
    @DatabaseKey BIGINT,
    @EditByUserName NVARCHAR(128),
    @EnvironmentType INT,
    @ServerName NVARCHAR(128),
    @DatabaseName NVARCHAR(128),
    @AuthenticationType INT,
    @UserName NVARCHAR(128),
    @PasswordHash NVARCHAR(128),
    @Description NVARCHAR(128)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @revision INT;

    SELECT @revision = [Revision]
        FROM [barber].[Database]
        WHERE [DatabaseKey] = @DatabaseKey;

    IF (@revision IS NULL)
        THROW 50002, N'DatabaseKey', 1;

    IF NOT EXISTS (SELECT 1
            FROM [barber].[EnvironmentType]
            WHERE [EnvironmentTypeKey] = @EnvironmentType)
        THROW 50001, N'EnvironmentType', 1;

    IF NOT EXISTS (SELECT 1
            FROM [barber].[AuthenticationType]
            WHERE [AuthenticationTypeKey] = @AuthenticationType)
        THROW 50001, N'AuthenticationType', 2;

    IF NOT EXISTS (SELECT 1
            FROM [barber].[User]
            WHERE [UserName] = @EditByUserName)
        THROW 50003, N'EditByUserName', 1;

    UPDATE [barber].[Database]
        SET
            [Revision] = @revision + 1,
            [EditByUserName] = @EditByUserName,
            [EditDateTime] = GETUTCDATE(),
            [EnvironmentType] = @EnvironmentType,
            [ServerName] = @ServerName,
            [DatabaseName] = @DatabaseName,
            [AuthenticationType] = @AuthenticationType,
            [UserName] = @UserName,
            [PasswordHash] = @PasswordHash,
            [Description] = @Description
        OUTPUT
                deleted.[DatabaseKey],
                deleted.[Revision],
                deleted.[EditByUserName],
                deleted.[EditDateTime],
                deleted.[EnvironmentType],
                deleted.[ServerName],
                deleted.[DatabaseName],
                deleted.[AuthenticationType],
                deleted.[UserName],
                deleted.[PasswordHash],
                deleted.[Description]
            INTO [barber].[DatabaseHistory] (
                [DatabaseKey],
                [Revision],
                [EditByUserName],
                [EditDateTime],
                [EnvironmentType],
                [ServerName],
                [DatabaseName],
                [AuthenticationType],
                [UserName],
                [PasswordHash],
                [Description])
        WHERE [DatabaseKey] = @DatabaseKey;

    RETURN @@ROWCOUNT;
END;
GO
