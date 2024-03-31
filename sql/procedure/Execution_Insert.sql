CREATE OR ALTER PROCEDURE [barber].[Execution_Insert]
    @ExecutionKey BIGINT OUT,
    @StatementKey BIGINT,
    @ExecuteByUserName NVARCHAR(128),
    @ExecuteDateTime DATETIME,
    @DatabaseKey BIGINT,
    @ExecuteMs BIGINT,
    @RowCount BIGINT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE
        @statementRevision INT,
        @databaseRevision INT;

    SELECT @statementRevision = [Revision]
        FROM [barber].[Statement]
        WHERE [StatementKey] = @StatementKey
            AND [ApproveByUserName] IS NOT NULL
            AND [ApproveDateTime] IS NOT NULL
            AND [StatementText] IS NOT NULL;

    IF (@statementRevision IS NULL)
        THROW 50002, N'StatementKey', 1;

    SELECT @databaseRevision = [Revision]
        FROM [barber].[Database]
        WHERE [DatabaseKey] = @DatabaseKey;

    IF (@databaseRevision IS NULL)
        THROW 50002, N'DatabaseKey', 2;

    IF NOT EXISTS (SELECT 1
            FROM [barber].[User]
            WHERE [UserName] = @ExecuteByUserName)
        THROW 50003, N'ExecuteByUserName', 1;

    INSERT INTO [barber].[Execution] (
            [DatabaseKey],
            [DatabaseRevision],
            [StatementKey],
            [StatementRevision],
            [ExecuteByUserName],
            [ExecuteDateTime],
            [ExecuteMs],
            [RowCount])
        SELECT
            @DatabaseKey,
            @databaseRevision,
            @StatementKey,
            @statementRevision,
            @ExecuteByUserName,
            ISNULL(@ExecuteDateTime, GETUTCDATE()),
            @ExecuteMs,
            @RowCount;
    SELECT @ExecutionKey = SCOPE_IDENTITY();

    RETURN @@ROWCOUNT;
END;
GO
