namespace barber.Extensions
{
    public static class ObjectExtension
    {
        public static T ToEnum<T>(this object? value, T defaultValue) where T : struct, System.Enum
        {
            if (value is string stringValue && System.Enum.TryParse<T>(stringValue, out var parsedValue))
            {
                return parsedValue;
            }
            else
            {
                return defaultValue;
            }
        }
    }
}