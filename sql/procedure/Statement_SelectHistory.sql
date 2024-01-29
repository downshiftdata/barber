CREATE OR ALTER PROCEDURE [barber].[Statement_SelectHistory]
    @StatementKey BIGINT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
            [StatementKey],
            [Revision],
            [EditByUserName],
            [EditDateTime],
            [ApproveByUserName],
            [ApproveDateTime],
            [StatementType],
            [StatementText],
            [StatementJson],
            [CheckDatabaseKey]
        FROM [barber].[Statement]
        WHERE [StatementKey] = @StatementKey
    UNION ALL
    SELECT
            [StatementKey],
            [Revision],
            [EditByUserName],
            [EditDateTime],
            [ApproveByUserName],
            [ApproveDateTime],
            [StatementType],
            [StatementText],
            [StatementJson],
            [CheckDatabaseKey]
        FROM [barber].[StatementHistory]
        WHERE [StatementKey] = @StatementKey
    ORDER BY [Revision];

    RETURN @@ROWCOUNT;
END;
GO
