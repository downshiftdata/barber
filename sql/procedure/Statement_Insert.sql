CREATE OR ALTER PROCEDURE [barber].[Statement_Insert]
    @StatementKey BIGINT OUTPUT,
    @EditByUserName NVARCHAR(128),
    @StatementType INT,
    @StatementText NVARCHAR(MAX),
    @StatementJson NVARCHAR(MAX),
    @CheckDatabaseKey BIGINT
AS
BEGIN
    SET NOCOUNT ON;

    IF (@StatementKey IS NOT NULL)
        THROW 50002, N'StatementKey', 1;

    IF NOT EXISTS (SELECT 1
            FROM [barber].[StatementType]
            WHERE [StatementTypeKey] = @StatementType)
        THROW 50001, N'StatementType', 1;

    IF NOT EXISTS (SELECT 1
            FROM [barber].[User]
            WHERE [UserName] = @EditByUserName)
        THROW 50003, N'EditByUserName', 1;

    IF NOT EXISTS (SELECT 1
            FROM [barber].[Database]
            WHERE [DatabaseKey] = @CheckDatabaseKey)
        THROW 50003, N'CheckDatabaseKey', 2;

    INSERT INTO [barber].[Statement] (
            [Revision],
            [EditByUserName],
            [EditDateTime],
            [ApproveByUserName],
            [ApproveDateTime],
            [StatementType],
            [StatementText],
            [StatementJson],
            [CheckDatabaseKey])
        SELECT
            1,
            @EditByUserName,
            GETUTCDATE(),
            NULL,
            NULL,
            @StatementType,
            @StatementText,
            @StatementJson,
            @CheckDatabaseKey;
    SELECT @StatementKey = SCOPE_IDENTITY();

    RETURN @@ROWCOUNT;
END;
GO
