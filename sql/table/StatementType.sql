IF (OBJECT_ID(N'barber.StatementType') IS NULL)
BEGIN
    CREATE TABLE [barber].[StatementType] (
        [StatementTypeKey] INT NOT NULL,
        [StatementTypeName] NVARCHAR(128) NOT NULL,
        CONSTRAINT [pk_barber_StatementType] PRIMARY KEY ([StatementTypeKey]))
        WITH (DATA_COMPRESSION = NONE);
END;
GO
