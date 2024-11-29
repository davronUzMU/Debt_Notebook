using Debt_Notebook.Model.DoMain;

namespace Debt_Notebook.Repositories.UserRep
{
    public interface IUserRepository
    {
        List<User> GetUserAll();
        User GetUserById(int id);
        User AddUser(User user);
        User EditUser(User user);
        void Delete(int id);
    }
}
