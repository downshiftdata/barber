/* Arrange */
SET NOCOUNT ON;
SET XACT_ABORT ON;
DECLARE
    @databaseKey BIGINT,
    @now DATETIME,
    @userName NVARCHAR(128);
SELECT @now = GETUTCDATE();
SELECT @userName = [UserName]
    FROM [barber].[User]
    WHERE [IsAdmin] = 1;
IF (@userName IS NULL)
    THROW 60001, N'barber.Database_Update_1', 1;
BEGIN TRANSACTION;
EXEC [barber].[Database_Insert]
    @DatabaseKey = @databaseKey OUT,
    @EditByUserName = @userName,
    @EnvironmentType = 0,
    @ServerName = N'ServerName1',
    @DatabaseName = N'DatabaseName1',
    @AuthenticationType = 0,
    @UserName = NULL,
    @PasswordHash = NULL,
    @Description = NULL;
IF (@databaseKey IS NULL)
    THROW 60001, N'barber.Database_Update_1', 2;

/* Act */
EXEC [barber].[Database_Update]
    @DatabaseKey = @databaseKey,
    @EditByUserName = @userName,
    @EnvironmentType = 0,
    @ServerName = N'ServerName2',
    @DatabaseName = N'DatabaseName2',
    @AuthenticationType = 0,
    @UserName = NULL,
    @PasswordHash = NULL,
    @Description = NULL;

/* Assert */
IF NOT EXISTS (SELECT 1
        FROM [barber].[Database]
        WHERE [DatabaseKey] = @databaseKey
            AND [Revision] = 2
            AND [EditByUserName] = @userName
            AND [EditDateTime] >= @now
            AND [EnvironmentType] = 0
            AND [ServerName] = N'ServerName2'
            AND [DatabaseName] = N'DatabaseName2'
            AND [AuthenticationType] = 0
            AND [UserName] IS NULL
            AND [PasswordHash] IS NULL
            AND [Description] IS NULL)
    THROW 60002, N'barber.Database_Update_1', 1;
IF NOT EXISTS (SELECT 1
        FROM [barber].[DatabaseHistory]
        WHERE [DatabaseKey] = @databaseKey
            AND [Revision] = 1
            AND [EditByUserName] = @userName
            AND [EditDateTime] >= @now
            AND [EnvironmentType] = 0
            AND [ServerName] = N'ServerName1'
            AND [DatabaseName] = N'DatabaseName1'
            AND [AuthenticationType] = 0
            AND [UserName] IS NULL
            AND [PasswordHash] IS NULL
            AND [Description] IS NULL)
    THROW 60002, N'barber.Database_Update_1', 1;
ROLLBACK TRANSACTION;
GO
