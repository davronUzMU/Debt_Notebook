namespace Debt_Notebook.Model.DTOs.MessageDTO
{
    public class MessageResponseDTO
    {
        public int Id { get; set; }
        public string RecipientPhoneNumber { get; set; } = string.Empty;
        public int userId { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
