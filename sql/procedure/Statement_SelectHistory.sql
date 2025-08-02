CREATE OR ALTER PROCEDURE [barber].[Statement_SelectHistory]
    @StatementKey BIGINT
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
            s.[StatementDetailJson],
            s.[CheckDatabaseKey],
            [barber].[GetDatabaseText](s.[CheckDatabaseKey]) AS [CheckDatabaseText]
        FROM [barber].[Statement] AS s
        WHERE s.[StatementKey] = @StatementKey
    UNION ALL
    SELECT
            sh.[StatementKey],
            sh.[Revision],
            sh.[EditByUserName],
            sh.[EditDateTime],
            sh.[ApproveByUserName],
            sh.[ApproveDateTime],
            sh.[Description],
            sh.[StatementType],
            sh.[SchemaName],
            sh.[TableName],
            sh.[StatementText],
            sh.[StatementDetailJson],
            sh.[CheckDatabaseKey],
            [barber].[GetDatabaseText](sh.[CheckDatabaseKey]) AS [CheckDatabaseText]
        FROM [barber].[StatementHistory] AS sh
        WHERE sh.[StatementKey] = @StatementKey
    ORDER BY [Revision] DESC;

    RETURN @@ROWCOUNT;
END;
GO
