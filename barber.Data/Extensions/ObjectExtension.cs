namespace barber.Data.Extensions
{
    public static class ObjectExtension
    {
        public static System.DateTime? DbNullToDateTime(this object? value)
        {
            return value is System.DBNull ? null : (System.DateTime?)value;
        }

        public static string? DbNullToString(this object? value)
        {
            return value is System.DBNull ? null : value?.ToString();
        }
    }
}