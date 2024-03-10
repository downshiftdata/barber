CREATE OR ALTER PROCEDURE [barber].[Database_SelectHistory]
    @DatabaseKey BIGINT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
            [DatabaseKey],
            [Revision],
            [EditByUserName],
            [EditDateTime],
            [EnvironmentType],
            [ServerName],
            [DatabaseName],
            [AuthenticationType],
            [UserName],
            [PasswordHash],
            [Description]
        FROM [barber].[Database]
        WHERE [DatabaseKey] = @DatabaseKey
    UNION ALL
    SELECT
            [DatabaseKey],
            [Revision],
            [EditByUserName],
            [EditDateTime],
            [EnvironmentType],
            [ServerName],
            [DatabaseName],
            [AuthenticationType],
            [UserName],
            [PasswordHash],
            [Description]
        FROM [barber].[DatabaseHistory]
        WHERE [DatabaseKey] = @DatabaseKey
    ORDER BY [Revision];

    RETURN @@ROWCOUNT;
END;
GO
