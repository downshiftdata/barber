IF (OBJECT_ID(N'barber.UserHistory') IS NULL)
BEGIN
    CREATE TABLE [barber].[UserHistory] (
        [UserName] NVARCHAR(128) NOT NULL,
        [Revision] INT NOT NULL,
        [EditByUserName] NVARCHAR(128) NOT NULL,
        [EditDateTime] DATETIME NOT NULL,
        [PasswordHash] NVARCHAR(128) NOT NULL,
        [IsAdmin] BIT NOT NULL,
        [IsEditor] BIT NOT NULL,
        [IsApprover] BIT NOT NULL,
        [IsExecutor] BIT NOT NULL,
        [AllowCustom] BIT NOT NULL,
        CONSTRAINT [pk_barber_UserHistory] PRIMARY KEY ([UserName], [Revision]))
        WITH (DATA_COMPRESSION = NONE);
END;
GO
