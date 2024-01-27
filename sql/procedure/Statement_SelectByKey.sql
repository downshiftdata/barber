CREATE OR ALTER PROCEDURE [barber].[Statement_SelectByKey]
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
        WHERE [StatementKey] = @StatementKey;

    RETURN @@ROWCOUNT;
END;
GO
