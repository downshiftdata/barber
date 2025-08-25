namespace barber.Core.Extensions
{
    public static class ObjectExtension
    {
        public static T FromJson<T>(this string? value, T defaultValue)
        {
            return string.IsNullOrWhiteSpace(value)
                ? defaultValue
                : System.Text.Json.JsonSerializer.Deserialize<T>(value) ?? defaultValue;
        }

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