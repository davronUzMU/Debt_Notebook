using System.ComponentModel.DataAnnotations;

namespace Debt_Notebook.Model.DoMain
{
    public class State
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = String.Empty;

        public bool IsActive { get; set; }
    }
}
