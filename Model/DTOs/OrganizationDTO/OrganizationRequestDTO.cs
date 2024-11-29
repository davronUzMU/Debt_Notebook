namespace Debt_Notebook.Model.DTOs.OrganizationDTO
{
    public class OrganizationRequestDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = String.Empty;

        public string Description { get; set; } = String.Empty;

        public string Phone_nummer { get; set; } = String.Empty;
        public List<int> Customers { get; set; }
    }
}
