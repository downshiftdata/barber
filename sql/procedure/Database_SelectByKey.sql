CREATE OR ALTER PROCEDURE [barber].[Database_SelectByKey]
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
            [PasswordHash]
        FROM [barber].[Database]
        WHERE [DatabaseKey] = @DatabaseKey;

    RETURN @@ROWCOUNT;
END;
GO
