IF (OBJECT_ID(N'barber.Statement') IS NULL)
BEGIN
    CREATE TABLE [barber].[Statement] (
        [StatementKey] BIGINT NOT NULL IDENTITY(1,1),
        [Revision] INT NOT NULL,
        [EditByUserName] NVARCHAR(128) NOT NULL,
        [EditDateTime] DATETIME NOT NULL,
        [ApproveByUserName] NVARCHAR(128) NULL,
        [ApproveDateTime] DATETIME NULL,
        [StatementType] INT NOT NULL,
        [StatementText] NVARCHAR(MAX) NULL,
        [StatementJson] NVARCHAR(MAX) NULL,
        [CheckDatabaseKey] BIGINT NOT NULL,
        CONSTRAINT [pk_barber_Statement] PRIMARY KEY ([StatementKey]))
        WITH (DATA_COMPRESSION = NONE);
END;
GO
