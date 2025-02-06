CREATE OR ALTER PROCEDURE [barber].[Statement_Update]
    @StatementKey BIGINT,
    @EditByUserName NVARCHAR(128),
    @Description NVARCHAR(128),
    @StatementType INT,
    @SchemaName NVARCHAR(128),
    @TableName NVARCHAR(128),
    @StatementText NVARCHAR(MAX),
    @StatementJson NVARCHAR(MAX),
    @CheckDatabaseKey BIGINT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @revision INT;

    SELECT @revision = [Revision]
        FROM [barber].[Statement]
        WHERE [StatementKey] = @StatementKey;

    IF (@revision IS NULL)
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

    IF EXISTS (SELECT 1
            FROM [barber].[Statement]
            WHERE [StatementKey] != @StatementKey
                AND [Description] = @Description)
        THROW 50001, N'Description', 2;

    UPDATE [barber].[Statement]
        SET
            [Revision] = @revision + 1,
            [EditByUserName] = @EditByUserName,
            [EditDateTime] = GETUTCDATE(),
            [ApproveByUserName] = NULL,
            [ApproveDateTime] = NULL,
            [Description] = @Description,
            [StatementType] = @StatementType,
            [SchemaName] = @SchemaName,
            [TableName] = @TableName,
            [StatementText] = @StatementText,
            [StatementJson] = @StatementJson,
            [CheckDatabaseKey] = @CheckDatabaseKey
        OUTPUT
                deleted.[StatementKey],
                deleted.[Revision],
                deleted.[EditByUserName],
                deleted.[EditDateTime],
                deleted.[ApproveByUserName],
                deleted.[ApproveDateTime],
                deleted.[StatementType],
                deleted.[SchemaName],
                deleted.[TableName],
                deleted.[StatementText],
                deleted.[StatementJson],
                deleted.[CheckDatabaseKey],
                NULL,
                NULL
            INTO [barber].[StatementHistory] (
                [StatementKey],
                [Revision],
                [EditByUserName],
                [EditDateTime],
                [ApproveByUserName],
                [ApproveDateTime],
                [StatementType],
                [SchemaName],
                [TableName],
                [StatementText],
                [StatementJson],
                [CheckDatabaseKey],
                [ArchiveByUserName],
                [ArchiveDateTime])
        WHERE [StatementKey] = @StatementKey;

    RETURN @@ROWCOUNT;
END;
GO
