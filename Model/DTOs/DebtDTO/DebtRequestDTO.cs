namespace Debt_Notebook.Model.DTOs.DebtDTO
{
    public class DebtRequestDTO
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public double Prise { get; set; }

        public string Description { get; set; } = String.Empty;
    }
}
