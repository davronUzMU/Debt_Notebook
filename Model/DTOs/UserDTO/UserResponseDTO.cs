using Debt_Notebook.Model.DoMain;
using Debt_Notebook.Model.Enums;
using System.Security.Cryptography.X509Certificates;

namespace Debt_Notebook.Model.DTOs.UserDTO
{
    public class UserResponseDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; } = String.Empty;
        public string Phone_nummer { get; set; } = String.Empty;
        public int OrganizationId { get; set; }
        public string organization { get; set; }
        public int StateId { get; set; }
        public string UserState { get; set; }
        public List<Debt> Debts { get; set; }
        public Role role;
        public DateTime dateTime;
        public UserResponseDTO(User user)
        {
            Id = user.Id;
            FullName = user.FullName;
            Phone_nummer = user.Phone_nummer;
            OrganizationId= user.OrganizationId;
            organization = user.organization?.Name;
            StateId = user.StateId;
            UserState = user.UserState?.Name;
            role = user.Role;
            dateTime = user.DateTime;
        }
    }
}
