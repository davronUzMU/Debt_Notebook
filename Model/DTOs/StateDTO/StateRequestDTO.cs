namespace Debt_Notebook.Model.DTOs.StateDTO
{
    public class StateRequestDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = String.Empty;

        public bool IsActive { get; set; }

        public StateRequestDTO(string name, bool isActive)
        {
            Name = name;
            IsActive = isActive;
        }
    }
}
