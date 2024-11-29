namespace Debt_Notebook.Exceptions
{
    public class BadRequestException : Exception
    {
        //Ushbu sinf foydalanuvchidan noto'g'ri yoki
        //yetarli bo'lmagan ma'lumotlar kelib tushganda foydalanish uchun

        public BadRequestException()
        {
        }

        public BadRequestException(string message)
            : base(message)
        {
        }

        public BadRequestException(string message, Exception inner)
            : base(message, inner)
        {

        }
    }
}
