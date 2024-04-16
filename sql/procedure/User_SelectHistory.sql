CREATE OR ALTER PROCEDURE [barber].[User_SelectHistory]
    @UserName NVARCHAR(128)
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
        WHERE u.[UserName] = @UserName
    UNION ALL
    SELECT
            uh.[UserName],
            uh.[Revision],
            uh.[EditByUserName],
            uh.[EditDateTime],
            uh.[PasswordHash],
            uh.[IsAdmin],
            uh.[IsEditor],
            uh.[IsApprover],
            uh.[IsExecutor],
            uh.[AllowCustom]
        FROM [barber].[UserHistory] AS uh
        WHERE uh.[UserName] = @UserName
    ORDER BY [Revision];

    RETURN @@ROWCOUNT;
END;
GO
