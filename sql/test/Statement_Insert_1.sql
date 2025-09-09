/* Arrange */
SET NOCOUNT ON;
SET XACT_ABORT ON;
DECLARE
    @databaseKey BIGINT,
    @now DATETIME,
    @statementKey BIGINT,
    @userName NVARCHAR(128);
SELECT @now = GETUTCDATE();
SELECT @userName = [UserName]
    FROM [barber].[User];
IF (@userName IS NULL)
    THROW 60001, N'barber.Statement_Insert_1', 1;
BEGIN TRANSACTION;
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
IF (@databaseKey IS NULL)
    THROW 60001, N'barber.Statement_Insert_1', 2;

/* Act */
EXEC [barber].[Statement_Insert]
    @StatementKey = @statementKey OUT,
    @EditByUserName = @userName,
    @Description = N'Description',
    @StatementType = 0,
    @SchemaName = NULL,
    @TableName = NULL,
    @StatementText = NULL,
    @StatementDetailJson = NULL,
    @CheckDatabaseKey = @databaseKey;

/* Assert */
IF NOT EXISTS (SELECT 1
        FROM [barber].[Statement]
        WHERE [StatementKey] = @statementKey
            AND [Revision] = 1
            AND [EditByUserName] = @userName
            AND [EditDateTime] >= @now
            AND [ValidateByUserName] IS NULL
            AND [ValidateDateTime] IS NULL
            AND [ApproveByUserName] IS NULL
            AND [ApproveDateTime] IS NULL
            AND [Description] = N'Description'
            AND [StatementType] = 0
            AND [SchemaName] IS NULL
            AND [TableName] IS NULL
            AND [StatementText] IS NULL
            AND [StatementDetailJson] IS NULL
            AND [CheckDatabaseKey] = @databaseKey)
    THROW 60002, N'barber.Statement_Insert_1', 1;
ROLLBACK TRANSACTION;
GO
