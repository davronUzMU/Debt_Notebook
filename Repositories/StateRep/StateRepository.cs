using Debt_Notebook.Data;
using Debt_Notebook.Model.DoMain;

namespace Debt_Notebook.Repositories.StateRep
{
    public class StateRepository : IStateRepository
    {
        private readonly AppDbContext _appDbContext;

        public StateRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public State AddState(State state)
        {
            _appDbContext.State.Add(state);
            _appDbContext.SaveChanges();
            return state;
        }

        public void Delete(int id)
        {
            var state = _appDbContext.State.Find(id);
            if (state != null)
            {
                _appDbContext.State.Remove(state);
                _appDbContext.SaveChanges();
            }
        }

        public State EditState(State state)
        {
            _appDbContext.State.Update(state);
            _appDbContext.SaveChanges();
            return state;
        }

        public List<State> GetStateAll()
        {
            return _appDbContext.State.ToList();
        }

        public State GetStateById(int id)
        {
            return _appDbContext.State.Find(id);
        }
    }
}
