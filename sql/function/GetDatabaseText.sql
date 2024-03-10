CREATE OR ALTER FUNCTION [barber].[GetDatabaseText] (
    @DatabaseKey BIGINT)
    RETURNS NVARCHAR(128)
AS
BEGIN
    DECLARE @result NVARCHAR(128);
    SELECT @result = LEFT(ISNULL(d.[Description], N'[' + et.[EnvironmentTypeName] + N'] ' + d.[ServerName] + N' - ' + d.[DatabaseName]), 128)
        FROM [barber].[Database] AS d
            INNER JOIN [barber].[EnvironmentType] AS et
                ON d.[DatabaseKey] = @DatabaseKey
                AND d.[EnvironmentType] = et.[EnvironmentTypeKey];
    RETURN @result;
END;
GO