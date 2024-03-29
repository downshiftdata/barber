IF (OBJECT_ID(N'barber.StatementHistory') IS NULL)
BEGIN
    CREATE TABLE [barber].[StatementHistory] (
        [StatementKey] BIGINT NOT NULL,
        [Revision] INT NOT NULL,
        [EditByUserName] NVARCHAR(128) NOT NULL,
        [EditDateTime] DATETIME NOT NULL,
        [ApproveByUserName] NVARCHAR(128) NULL,
        [ApproveDateTime] DATETIME NULL,
        [StatementType] INT NOT NULL,
        [StatementText] NVARCHAR(MAX) NULL,
        [StatementJson] NVARCHAR(MAX) NULL,
        [CheckDatabaseKey] BIGINT NOT NULL,
        [ArchiveByUserName] NVARCHAR(128) NULL,
        [ArchiveDateTime] DATETIME NULL,
        CONSTRAINT [pk_barber_StatementHistory] PRIMARY KEY ([StatementKey], [Revision]))
        WITH (DATA_COMPRESSION = NONE);
END;
GO
