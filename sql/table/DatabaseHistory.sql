IF (OBJECT_ID(N'barber.DatabaseHistory') IS NULL)
BEGIN
    CREATE TABLE [barber].[DatabaseHistory] (
        [DatabaseKey] BIGINT NOT NULL,
        [Revision] INT NOT NULL,
        [EditByUserName] NVARCHAR(128) NOT NULL,
        [EditDateTime] DATETIME NOT NULL,
        [EnvironmentType] INT NOT NULL,
        [ServerName] NVARCHAR(128) NOT NULL,
        [DatabaseName] NVARCHAR(128) NOT NULL,
        [AuthenticationType] INT NOT NULL,
        [UserName] NVARCHAR(128) NULL,
        [PasswordHash] NVARCHAR(128) NULL,
        CONSTRAINT [pk_barber_DatabaseHistory] PRIMARY KEY ([DatabaseKey], [Revision]))
        WITH (DATA_COMPRESSION = NONE);
END;
GO
