IF (OBJECT_ID(N'barber.Execution') IS NULL)
BEGIN
    CREATE TABLE [barber].[Execution] (
        [ExecutionKey] BIGINT NOT NULL IDENTITY(1,1),
        [DatabaseKey] BIGINT NOT NULL,
        [DatabaseRevision] INT NOT NULL,
        [StatementKey] BIGINT NOT NULL,
        [StatementRevision] INT NOT NULL,
        [ExecuteByUserName] NVARCHAR(128) NOT NULL,
        [ExecuteDateTime] DATETIME NOT NULL,
        [ExecuteMs] BIGINT NOT NULL,
        [RowCount] BIGINT NOT NULL,
        CONSTRAINT [pk_barber_Execution] PRIMARY KEY ([ExecutionKey]))
        WITH (DATA_COMPRESSION = NONE);
END;
GO
