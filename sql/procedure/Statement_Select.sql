CREATE OR ALTER PROCEDURE [barber].[Statement_Select]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
            s.[StatementKey],
            s.[Revision],
            s.[EditByUserName],
            s.[EditDateTime],
            s.[ApproveByUserName],
            s.[ApproveDateTime],
            s.[Description],
            s.[StatementType],
            s.[SchemaName],
            s.[TableName],
            s.[StatementText],
            s.[StatementJson],
            s.[CheckDatabaseKey],
            [barber].[GetDatabaseText](s.[CheckDatabaseKey]) AS [CheckDatabaseText]
        FROM [barber].[Statement] AS s
        ORDER BY s.[StatementKey];

    RETURN @@ROWCOUNT;
END;
GO
