CREATE OR ALTER PROCEDURE [barber].[Database_Insert]
    @DatabaseKey BIGINT NULL OUTPUT,
    @EditByUserName NVARCHAR(128),
    @EnvironmentType INT,
    @ServerName NVARCHAR(128),
    @DatabaseName NVARCHAR(128),
    @AuthenticationType INT,
    @UserName NVARCHAR(128),
    @PasswordHash NVARCHAR(128)
AS
BEGIN
    SET NOCOUNT ON;

    IF (@DatabaseKey IS NOT NULL)
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

    INSERT INTO [barber].[Database] (
            [Revision],
            [EditByUserName],
            [EditDateTime],
            [EnvironmentType],
            [ServerName],
            [DatabaseName],
            [AuthenticationType],
            [UserName],
            [PasswordHash])
        SELECT
            1,
            @EditByUserName,
            GETUTCDATE(),
            @EnvironmentType,
            @ServerName,
            @DatabaseName,
            @AuthenticationType,
            @UserName,
            @PasswordHash;
    SELECT @DatabaseKey = SCOPE_IDENTITY();

    RETURN @@ROWCOUNT;
END;
GO
