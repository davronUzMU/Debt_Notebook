using Debt_Notebook.Model.DoMain;

namespace Debt_Notebook.Repositories.DebtRep
{
    public interface IDebtRepository
    {
        List<Debt> GetDebtAll();
        Debt GetDebtById(int id);
        Debt AddDebt(Debt debt);
        Debt Edit(Debt debt);
        void Delete(int id);
    }
}
