namespace Debt_Notebook.Model.DTOs
{
    public class InformationDTO
    {
        public InformationDTO(string infor) {
            this.informationMessage = infor;
        }
        public string informationMessage {  get; set; }

    }
}
