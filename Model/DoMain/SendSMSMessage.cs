using System.ComponentModel.DataAnnotations;

namespace Debt_Notebook.Model.DoMain
{
    public class SendSMSMessage
    {
        [Key]
        public int Id { get; set; }
        public string RecipientPhoneNumber { get; set; } = string.Empty; 
        public int userId { get; set; } 
        public string Message { get; set; } = string.Empty;
    }
}
