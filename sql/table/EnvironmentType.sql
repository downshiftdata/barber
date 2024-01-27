IF (OBJECT_ID(N'barber.EnvironmentType') IS NULL)
BEGIN
    CREATE TABLE [barber].[EnvironmentType] (
        [EnvironmentTypeKey] INT NOT NULL,
        [EnvironmentTypeName] NVARCHAR(128) NOT NULL,
        CONSTRAINT [pk_barber_EnvironmentType] PRIMARY KEY ([EnvironmentTypeKey]))
        WITH (DATA_COMPRESSION = NONE);
END;
GO
