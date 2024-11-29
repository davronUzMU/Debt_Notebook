namespace Debt_Notebook.Model.DTOs.StateDTO
{
    public class StateResponseDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = String.Empty;

        public bool IsActive { get; set; }

        public StateResponseDTO(int id,string name,bool isActive) {
            Id = id;
            Name = name;
            IsActive = isActive;
        }
    }
}
