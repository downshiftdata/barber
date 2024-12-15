SET NOCOUNT ON;
GO

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
            N'XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=',
            1,
            0,
            0,
            0,
            0;
END;
GO
