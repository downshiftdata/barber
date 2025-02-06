CREATE OR ALTER PROCEDURE [barber].[Statement_Insert]
    @StatementKey BIGINT OUTPUT,
    @EditByUserName NVARCHAR(128),
    @Description NVARCHAR(128),
    @StatementType INT,
    @SchemaName NVARCHAR(128),
    @TableName NVARCHAR(128),
    @StatementText NVARCHAR(MAX),
    @SchemaName NVARCHAR(128),
    @TableName NVARCHAR(128),
    @StatementJson NVARCHAR(MAX),
    @CheckDatabaseKey BIGINT
AS
BEGIN
    SET NOCOUNT ON;

    IF (@StatementKey IS NOT NULL)
        THROW 50002, N'StatementKey', 1;

    IF (@Description IS NULL)
        THROW 50001, N'Description', 1;

    IF NOT EXISTS (SELECT 1
            FROM [barber].[StatementType]
            WHERE [StatementTypeKey] = @StatementType)
        THROW 50001, N'StatementType', 2;

    IF NOT EXISTS (SELECT 1
            FROM [barber].[User]
            WHERE [UserName] = @EditByUserName)
        THROW 50003, N'EditByUserName', 1;

    IF NOT EXISTS (SELECT 1
            FROM [barber].[Database]
            WHERE [DatabaseKey] = @CheckDatabaseKey)
        THROW 50003, N'CheckDatabaseKey', 2;

    IF EXISTS (SELECT 1
            FROM [barber].[Statement]
            WHERE [Description] = @Description)
        THROW 50001, N'Description', 3;

    INSERT INTO [barber].[Statement] (
            [Revision],
            [EditByUserName],
            [EditDateTime],
            [ApproveByUserName],
            [ApproveDateTime],
            [Description],
            [StatementType],
            [SchemaName],
            [TableName],
            [StatementText],
            [StatementJson],
            [CheckDatabaseKey])
        SELECT
            1,
            @EditByUserName,
            GETUTCDATE(),
            NULL,
            NULL,
            @Description,
            @StatementType,
            @SchemaName,
            @TableName,
            @StatementText,
            @StatementJson,
            @CheckDatabaseKey;
    SELECT @StatementKey = SCOPE_IDENTITY();

    RETURN @@ROWCOUNT;
END;
GO
