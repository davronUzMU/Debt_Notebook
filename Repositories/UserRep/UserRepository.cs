using Debt_Notebook.Data;
using Debt_Notebook.Model.DoMain;
using Microsoft.EntityFrameworkCore;

namespace Debt_Notebook.Repositories.UserRep
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _appDbContext;
        public UserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public User AddUser(User user)
        {
            _appDbContext.users.Add(user);
            _appDbContext.SaveChanges();
            return user;
        }

        public void Delete(int id)
        {
            var user = _appDbContext.users.Find(id);
            if (user != null)
            {
                _appDbContext.users.Remove(user);
                _appDbContext.SaveChanges();
            }
        }

        public User EditUser(User user)
        {
            _appDbContext.Update(user);
            _appDbContext.SaveChanges(true);
            return user;
        }

        public List<User> GetUserAll()
        {
            return _appDbContext.users.
                Include(k => k.organization).
                Include(j => j.UserState).
                Include(l => l.Debts).ToList();
        }

        public User GetUserById(int id)
        {
            return _appDbContext.users.
                Include(k => k.organization).
                Include(j => j.UserState).
                Include(l => l.Debts).
                FirstOrDefault(p => p.Id == id);
        }
    }
}
