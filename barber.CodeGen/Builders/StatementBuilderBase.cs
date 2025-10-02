namespace barber.CodeGen.Builders
{
    public abstract class StatementBuilderBase
    {
        protected static string FormatIdentifier(string value)
        {
            return $"[{value}]";
        }

        protected static string FormatValue(string value, System.Data.DbType dbType)
        {
            switch (dbType)
            {
                default:
                    return $"'{value}'";
            }
        }
    }
}