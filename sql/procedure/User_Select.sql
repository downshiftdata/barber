CREATE OR ALTER PROCEDURE [barber].[User_Select]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
            u.[UserName],
            u.[Revision],
            u.[EditByUserName],
            u.[EditDateTime],
            u.[PasswordHash],
            u.[IsAdmin],
            u.[IsEditor],
            u.[IsApprover],
            u.[IsExecutor],
            u.[AllowCustom]
        FROM [barber].[User] AS u
        ORDER BY u.[UserName];

    RETURN @@ROWCOUNT;
END;
GO
