using Debt_Notebook.Model.DoMain;

namespace Debt_Notebook.Model.DTOs.DebtDTO
{
    public class DebtResponseDTO
    {
        public DebtResponseDTO(int id, int userId, User user, double prise, string description, DateTime createTime)
        {
            Id = id;
            UserId = userId;
            User = user;
            Prise = prise;
            Description = description;
            CreateTime = createTime;
        }

        public int Id { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
        public double Prise { get; set; }

        public string Description { get; set; } = String.Empty;

        public DateTime CreateTime { get; set; }
    }
}
