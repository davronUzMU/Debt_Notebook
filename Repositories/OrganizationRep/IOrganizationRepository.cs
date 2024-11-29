using Debt_Notebook.Model.DoMain;

namespace Debt_Notebook.Repositories.OrganizationRep
{
    public interface IOrganizationRepository
    {
        List<Organization> GetOrganizationAll();
        Organization GetOrganizationById(int id);
        Organization AddOrganization(Organization organization);
        Organization EditOrganization(Organization organization);
        void Delete(int id);
    }
}
