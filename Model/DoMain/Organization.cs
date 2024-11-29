using System.ComponentModel.DataAnnotations;

namespace Debt_Notebook.Model.DoMain
{
    public class Organization
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = String.Empty;
        [Required]
        public string Description { get; set; } = String.Empty;
        [Required]
        public string Phone_nummer { get; set; } = String.Empty;
        [Required]
        public int StateId { get; set; }
        public State State { get; set; }

        public List<User> Customers { get; set; }

        public DateTime CreateTime { get; set; }
    }
}
