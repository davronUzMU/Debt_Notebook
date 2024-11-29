using Debt_Notebook.Model.DoMain;

namespace Debt_Notebook.Repositories.StateRep
{
    public interface IStateRepository
    {
        List<State> GetStateAll();
        State GetStateById(int id);
        State AddState(State state);
        State EditState(State state);
        void Delete(int id);
    }
}
