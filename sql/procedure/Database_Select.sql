CREATE OR ALTER PROCEDURE [barber].[Database_Select]
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
        ORDER BY [DatabaseKey];

    RETURN @@ROWCOUNT;
END;
GO
