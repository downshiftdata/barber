CREATE OR ALTER PROCEDURE [barber].[Database_SelectList]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
            d.[DatabaseKey] AS [ItemKey],
            N'[' + et.[EnvironmentTypeName] + N'] ' + d.[ServerName] + N' - ' + d.[DatabaseName] AS [ItemText]
        FROM [barber].[Database] AS d
            INNER JOIN [barber].[EnvironmentType] AS et
                ON d.[EnvironmentType] = et.[EnvironmentTypeKey]
        ORDER BY d.[DatabaseKey];

    RETURN @@ROWCOUNT;
END;
GO

