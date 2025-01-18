CREATE OR ALTER PROCEDURE [barber].[Statement_Archive]
    @StatementKey BIGINT,
    @ArchiveByUserName NVARCHAR(128)
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1
            FROM [barber].[Statement]
            WHERE [StatementKey] = @StatementKey)
        THROW 50002, N'StatementKey', 1;

    IF NOT EXISTS (SELECT 1
            FROM [barber].[User]
            WHERE [UserName] = @ArchiveByUserName)
        THROW 50003, N'ArchiveByUserName', 1;

    DELETE [barber].[Statement]
        OUTPUT
                deleted.[StatementKey],
                deleted.[Revision],
                deleted.[EditByUserName],
                deleted.[EditDateTime],
                deleted.[ApproveByUserName],
                deleted.[ApproveDateTime],
                deleted.[Description],
                deleted.[StatementType],
                deleted.[StatementText],
                deleted.[StatementJson],
                deleted.[CheckDatabaseKey],
                @ArchiveByUserName,
                GETUTCDATE()
            INTO [barber].[StatementHistory] (
                [StatementKey],
                [Revision],
                [EditByUserName],
                [EditDateTime],
                [ApproveByUserName],
                [ApproveDateTime],
                [Description],
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
