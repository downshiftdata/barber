CREATE OR ALTER PROCEDURE [barber].[Statement_SelectApprovedList]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
            s.[StatementKey] AS [ItemKey],
            N'[' + st.[StatementTypeName] + N'] ' + s.[StatementText] AS [ItemText]
        FROM [barber].[Statement] AS s
            INNER JOIN [barber].[StatementType] AS st
                ON s.[StatementType] = st.[StatementTypeKey]
                AND s.[ApproveByUserName] IS NOT NULL
                AND s.[ApproveDateTime] IS NOT NULL
        ORDER BY s.[StatementKey];

    RETURN @@ROWCOUNT;
END;
GO

