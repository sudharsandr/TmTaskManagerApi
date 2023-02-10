namespace TmTaskManagerApi.HttpHelpers
{
    public static class ValidationHelper
    {
        public static bool IsNullOrEmptyOrWhiteSpace(this string value)
        {
            return (value == String.Empty || String.IsNullOrWhiteSpace(value));
        }

        public static bool IsZero(this int value)
        {
            return (value == 0);
        }
    }
}
