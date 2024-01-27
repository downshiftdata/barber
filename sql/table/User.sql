IF (OBJECT_ID(N'barber.User') IS NULL)
BEGIN
    CREATE TABLE [barber].[User] (
        [UserName] NVARCHAR(128) NOT NULL,
        [Revision] INT NOT NULL,
        [EditByUserName] NVARCHAR(128) NOT NULL,
        [EditDateTime] DATETIME NOT NULL,
        [PasswordHash] NVARCHAR(128) NOT NULL,
        [IsAdmin] BIT NOT NULL,
        [IsEditor] BIT NOT NULL,
        [IsApprover] BIT NOT NULL,
        [IsExecutor] BIT NOT NULL,
        CONSTRAINT [pk_barber_User] PRIMARY KEY ([UserName]))
        WITH (DATA_COMPRESSION = NONE);
END;
GO
