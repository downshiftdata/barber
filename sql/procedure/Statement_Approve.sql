CREATE OR ALTER PROCEDURE [barber].[Statement_Approve]
    @StatementKey BIGINT,
    @ApproveByUserName NVARCHAR(128)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @revision INT;

    SELECT @revision = [Revision]
        FROM [barber].[Statement]
        WHERE [StatementKey] = @StatementKey
            AND [ApproveByUserName] IS NULL
            AND [StatementText] IS NOT NULL;

    IF (@revision IS NULL)
        THROW 50002, N'StatementKey', 1;

    IF NOT EXISTS (SELECT 1
            FROM [barber].[User]
            WHERE [UserName] = @ApproveByUserName)
        THROW 50003, N'ApproveByUserName', 1;

    UPDATE [barber].[Statement]
        SET
            [Revision] = @revision + 1,
            [ApproveByUserName] = @ApproveByUserName,
            [ApproveDateTime] = GETUTCDATE()
        OUTPUT
                deleted.[StatementKey],
                deleted.[Revision],
                deleted.[EditByUserName],
                deleted.[EditDateTime],
                deleted.[ApproveByUserName],
                deleted.[ApproveDateTime],
                deleted.[StatementType],
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
                [StatementText],
                [StatementJson],
                [CheckDatabaseKey],
                [ArchiveByUserName],
                [ArchiveDateTime])
        WHERE [StatementKey] = @StatementKey;

    RETURN @@ROWCOUNT;
END;
GO
