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
    THROW 60001, N'barber.Database_Insert_1', 1;
BEGIN TRANSACTION;

/* Act */
EXEC [barber].[Database_Insert]
    @DatabaseKey = @databaseKey OUT,
    @EditByUserName = @userName,
    @EnvironmentType = 0,
    @ServerName = N'ServerName',
    @DatabaseName = N'DatabaseName',
    @AuthenticationType = 0,
    @UserName = NULL,
    @PasswordHash = NULL,
    @Description = NULL;

/* Assert */
IF NOT EXISTS (SELECT 1
        FROM [barber].[Database]
        WHERE [DatabaseKey] = @databaseKey
            AND [Revision] = 1
            AND [EditByUserName] = @userName
            AND [EditDateTime] >= @now
            AND [EnvironmentType] = 0
            AND [ServerName] = N'ServerName'
            AND [DatabaseName] = N'DatabaseName'
            AND [AuthenticationType] = 0
            AND [UserName] IS NULL
            AND [PasswordHash] IS NULL
            AND [Description] IS NULL)
    THROW 60002, N'barber.Database_Insert_1', 1;
ROLLBACK TRANSACTION;
GO
