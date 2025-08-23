IF (OBJECT_ID(N'barber.Statement') IS NULL)
BEGIN
    CREATE TABLE [barber].[Statement] (
        [StatementKey] BIGINT NOT NULL IDENTITY(1,1),
        [Revision] INT NOT NULL,
        [EditByUserName] NVARCHAR(128) NOT NULL,
        [EditDateTime] DATETIME NOT NULL,
        [ValidateByUserName] NVARCHAR(128) NULL,
        [ValidateDateTime] DATETIME NULL,
        [ApproveByUserName] NVARCHAR(128) NULL,
        [ApproveDateTime] DATETIME NULL,
        [Description] NVARCHAR(128) NOT NULL,
        [StatementType] INT NOT NULL,
        [SchemaName] NVARCHAR(128) NULL,
        [TableName] NVARCHAR(128) NULL,
        [StatementText] NVARCHAR(MAX) NULL,
        [StatementDetailJson] NVARCHAR(MAX) NULL,
        [CheckDatabaseKey] BIGINT NOT NULL,
        CONSTRAINT [pk_barber_Statement] PRIMARY KEY ([StatementKey]),
        CONSTRAINT [uc_barber_Statement_Description] UNIQUE ([Description]))
        WITH (DATA_COMPRESSION = NONE);
END;
GO
