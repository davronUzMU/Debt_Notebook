using Debt_Notebook.Model.DoMain;

namespace Debt_Notebook.Model.DTOs.OrganizationDTO
{
    public class OrganizationResponseDTO
    {
        public OrganizationResponseDTO(int id,string name,string dec,string phone_nummer,int stateId,State state,List<User> customer,DateTime 
            dateTime) {
            this.Id = id;
            this.Name = name;
            this.Description = dec;
            this.Phone_nummer = phone_nummer;
            this.StateId = stateId;
            this.State = state;
            this.Customers = customer;
            this.CreateTime = dateTime;
        }
        public int Id { get; set; }

        public string Name { get; set; } = String.Empty;

        public string Description { get; set; } = String.Empty;

        public string Phone_nummer { get; set; } = String.Empty;

        public int StateId { get; set; }
        public State State { get; set; }

        public List<User> Customers { get; set; }

        public DateTime CreateTime { get; set; }

       
    }
}
