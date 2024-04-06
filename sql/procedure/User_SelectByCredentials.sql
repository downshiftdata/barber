CREATE OR ALTER PROCEDURE [barber].[User_SelectByCredentials]
    @UserName NVARCHAR(128),
    @PasswordHash NVARCHAR(128)
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
            u.[IsExecutor]
        FROM [barber].[User] AS u
        WHERE u.[UserName] = @UserName
            AND u.[PasswordHash] = @PasswordHash;

    RETURN @@ROWCOUNT;
END;
GO
