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
            [IsExecutor])
        SELECT
            N'default',
            1,
            N'default',
            GETUTCDATE(),
            N'password',
            1,
            1,
            1,
            1;
END;
GO
