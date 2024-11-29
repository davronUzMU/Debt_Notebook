using Debt_Notebook.Model.Enums;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Text.Json.Serialization;

namespace Debt_Notebook.Model.DoMain
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; } = String.Empty;

        [Required]
        public string Phone_nummer { get; set; } = String.Empty;
        public int OrganizationId { get; set; }
        [JsonIgnore]
        public Organization organization { get; set; }
        public int StateId { get; set; }
        public State UserState { get; set; }
        public List<Debt> Debts { get; set; }=new List<Debt>();
        public Role Role { get; set; }
        public DateTime DateTime { get; set; }
    }
}
