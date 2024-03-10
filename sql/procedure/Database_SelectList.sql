CREATE OR ALTER PROCEDURE [barber].[Database_SelectList]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
            d.[DatabaseKey] AS [ItemKey],
            [barber].[GetDatabaseText](d.[DatabaseKey]) AS [ItemText]
        FROM [barber].[Database] AS d
            INNER JOIN [barber].[EnvironmentType] AS et
                ON d.[EnvironmentType] = et.[EnvironmentTypeKey]
        ORDER BY d.[DatabaseKey];

    RETURN @@ROWCOUNT;
END;
GO

