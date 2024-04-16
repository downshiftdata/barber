SET NOCOUNT ON;
GO

/* HACK: Change when proper security is added. */
IF NOT EXISTS (SELECT 1 FROM [barber].[User])
BEGIN
    INSERT INTO [barber].[User] (
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
        SELECT
            N'default',
            1,
            N'default',
            GETUTCDATE(),
            N'5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8',
            1,
            0,
            0,
            0,
            0;
END;
GO
