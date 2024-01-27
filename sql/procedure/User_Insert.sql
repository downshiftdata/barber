CREATE OR ALTER PROCEDURE [barber].[User_Insert]
    @UserName NVARCHAR(128),
    @EditByUserName NVARCHAR(128),
    @PasswordHash NVARCHAR(128),
    @IsAdmin BIT,
    @IsEditor BIT,
    @IsApprover BIT,
    @IsExecutor BIT
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (SELECT 1
            FROM [barber].[User]
            WHERE [UserName] = @UserName)
        THROW 50002, N'UserName', 1;

    IF NOT EXISTS (SELECT 1
            FROM [barber].[User]
            WHERE [UserName] = @EditByUserName)
    BEGIN
        IF (@UserName != @EditByUserName)
                OR EXISTS (SELECT 1 FROM [barber].[User])
            THROW 50003, N'EditByUserName', 1;
    END;

    INSERT INTO [barber].[User] (
            [UserName],
            [Revision],
            [EditByUserName],
            [EditDateTime],
            [PasswordHash],
            [IsAdmin],
            [IsEditor],
            [IsApprover],
            [IsExecutor])
        SELECT
            @UserName,
            1,
            @EditByUserName,
            GETUTCDATE(),
            @PasswordHash,
            @IsAdmin,
            @IsEditor,
            @IsApprover,
            @IsExecutor;

    RETURN @@ROWCOUNT;
END;
GO
