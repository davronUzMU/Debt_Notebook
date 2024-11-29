using Debt_Notebook.Model.DoMain;

namespace Debt_Notebook.Repositories.MessageRep
{
    public interface ISendSMSMessage
    {
        List<SendSMSMessage> GetMessageAll();
        SendSMSMessage GetMessageById(int id);
        SendSMSMessage AddMessage(SendSMSMessage message);
        SendSMSMessage Edit(SendSMSMessage message);
        void Delete(int id);
    }
}
