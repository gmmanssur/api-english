namespace ApiEnglish.Application.Helper.Exceptions
{
    public class ExceptionHelper
    {
        private ExceptionHelper() { }
        public static string FilterExceptionMessage(string message)
        {
            return message.Replace("Validation failed: \n -- Username: ", "")
                .Replace("Validation failed: \n -- Password: ", "")
                .Replace("Validation failed: \n -- Email: ", "")
                .Replace(". Severity: Error", "");
        }
    }
}