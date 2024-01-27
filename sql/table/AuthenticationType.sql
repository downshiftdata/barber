IF (OBJECT_ID(N'barber.AuthenticationType') IS NULL)
BEGIN
    CREATE TABLE [barber].[AuthenticationType] (
        [AuthenticationTypeKey] INT NOT NULL,
        [AuthenticationTypeName] NVARCHAR(128) NOT NULL,
        CONSTRAINT [pk_barber_AuthenticationType] PRIMARY KEY ([AuthenticationTypeKey]))
        WITH (DATA_COMPRESSION = NONE);
END;
GO
