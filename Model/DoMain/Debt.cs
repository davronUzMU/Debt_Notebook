using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Debt_Notebook.Model.DoMain
{
    public class Debt
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }
        [JsonIgnore]
        public User User { get; set; }

        [Required]
        public double Prise { get; set; }

        public string Description { get; set; } = String.Empty;

        public DateTime CreateTime { get; set; }
    }
}
