CREATE OR ALTER PROCEDURE [barber].[Statement_Select]
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
        ORDER BY [StatementKey];

    RETURN @@ROWCOUNT;
END;
GO
