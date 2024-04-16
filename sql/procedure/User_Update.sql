CREATE OR ALTER PROCEDURE [barber].[User_Update]
    @UserName NVARCHAR(128),
    @EditByUserName NVARCHAR(128),
    @PasswordHash NVARCHAR(128),
    @IsAdmin BIT,
    @IsEditor BIT,
    @IsApprover BIT,
    @IsExecutor BIT,
    @AllowCustom BIT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @revision INT;

    SELECT @revision = [Revision]
        FROM [barber].[User]
        WHERE [UserName] = @UserName;

    IF (@revision IS NULL)
        THROW 50002, N'UserName', 1;

    IF NOT EXISTS (SELECT 1
            FROM [barber].[User]
            WHERE [UserName] = @EditByUserName)
        THROW 50003, N'EditByUserName', 1;

    UPDATE [barber].[User]
        SET
            [UserName] = @UserName,
            [Revision] = @revision + 1,
            [EditByUserName] = @EditByUserName,
            [EditDateTime] = GETUTCDATE(),
            [PasswordHash] = @PasswordHash,
            [IsAdmin] = @IsAdmin,
            [IsEditor] = @IsEditor,
            [IsApprover] = @IsApprover,
            [IsExecutor] = @IsExecutor,
            [AllowCustom] = @AllowCustom
        OUTPUT
                deleted.[UserName],
                deleted.[Revision],
                deleted.[EditByUserName],
                deleted.[EditDateTime],
                deleted.[PasswordHash],
                deleted.[IsAdmin],
                deleted.[IsEditor],
                deleted.[IsApprover],
                deleted.[IsExecutor],
                deleted.[AllowCustom]
            INTO [barber].[UserHistory] (
                [UserName],
                [Revision],
                [EditByUserName],
                [EditDateTime],
                [PasswordHash],
                [IsAdmin],
                [IsEditor],
                [IsApprover],
                [IsExecutor],
                [AllowCustom])
        WHERE [UserName] = @UserName;

    RETURN @@ROWCOUNT;
END;
GO
