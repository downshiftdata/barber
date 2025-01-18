CREATE OR ALTER PROCEDURE [barber].[Statement_SelectApprovedList]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
            s.[StatementKey] AS [ItemKey],
            s.[Description] AS [ItemText]
        FROM [barber].[Statement] AS s
        ORDER BY s.[Description];

    RETURN @@ROWCOUNT;
END;
GO

