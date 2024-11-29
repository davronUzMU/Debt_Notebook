using Debt_Notebook.Data;
using Debt_Notebook.Model.DoMain;
using Microsoft.EntityFrameworkCore;

namespace Debt_Notebook.Repositories.DebtRep
{
    public class DebtRepository : IDebtRepository
    {
        private readonly AppDbContext _appDbContext;

        public DebtRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public Debt AddDebt(Debt debt)
        {
            _appDbContext.Debts.Add(debt);
            _appDbContext.SaveChanges();
            return debt;
        }

        public void Delete(int id)
        {
            var debt = _appDbContext.Debts.Find(id);
            if (debt != null)
            {
                _appDbContext.Debts.Remove(debt);
                _appDbContext.SaveChanges();
            }
        }

        public Debt Edit(Debt debt)
        {
            _appDbContext.Debts.Update(debt);
            _appDbContext.SaveChanges();
            return debt;
        }

        public List<Debt> GetDebtAll()
        {
            return _appDbContext.Debts.Include(k => k.User).ToList();
        }

        public Debt GetDebtById(int id)
        {
            try
            {
                return _appDbContext.Debts.Include(c => c.User).FirstOrDefault(c => c.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
