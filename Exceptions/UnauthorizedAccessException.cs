namespace Debt_Notebook.Exceptions
{
    public class UnauthorizedAccessException : Exception
    {
        // Ushbu sinf foydalanuvchi tizimga kirishga yetarli ruxsatga ega bo'lmaganda ishlatish uchun
        public UnauthorizedAccessException()
        {
        }

        public UnauthorizedAccessException(string message)
            : base(message)
        {
        }

        public UnauthorizedAccessException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
