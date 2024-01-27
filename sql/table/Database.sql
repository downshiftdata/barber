IF (OBJECT_ID(N'barber.Database') IS NULL)
BEGIN
    CREATE TABLE [barber].[Database] (
        [DatabaseKey] BIGINT NOT NULL IDENTITY(1,1),
        [Revision] INT NOT NULL,
        [EditByUserName] NVARCHAR(128) NOT NULL,
        [EditDateTime] DATETIME NOT NULL,
        [EnvironmentType] INT NOT NULL,
        [ServerName] NVARCHAR(128) NOT NULL,
        [DatabaseName] NVARCHAR(128) NOT NULL,
        [AuthenticationType] INT NOT NULL,
        [UserName] NVARCHAR(128) NULL,
        [PasswordHash] NVARCHAR(128) NULL,
        CONSTRAINT [pk_barber_Database] PRIMARY KEY ([DatabaseKey]))
        WITH (DATA_COMPRESSION = NONE);
END;
GO
