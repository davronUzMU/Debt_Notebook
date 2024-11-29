using Debt_Notebook.Model.Enums;

namespace Debt_Notebook.Model.DTOs.UserDTO
{
    public class UserRequestDTO
    {
        public int Id { get; set; }

        public string FullName { get; set; } = String.Empty;
        public string Phone_nummer { get; set; } = String.Empty;
        public int OrganizationId { get; set; }
        public List<int> Debts { get; set; }
    }
}
