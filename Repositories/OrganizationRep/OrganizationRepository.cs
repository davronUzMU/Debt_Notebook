using Debt_Notebook.Data;
using Debt_Notebook.Model.DoMain;
using Microsoft.EntityFrameworkCore;

namespace Debt_Notebook.Repositories.OrganizationRep
{
    public class OrganizationRepository : IOrganizationRepository
    {
        private readonly AppDbContext _appDbContext;
        public OrganizationRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public Organization AddOrganization(Organization organization)
        {
            _appDbContext.Organizations.Add(organization);
            _appDbContext.SaveChanges();
            return organization;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Organization EditOrganization(Organization organization)
        {
            _appDbContext.Organizations.Update(organization);
            _appDbContext.SaveChanges();
            return organization;
        }

        public List<Organization> GetOrganizationAll()
        {
            return _appDbContext.Organizations.
                Include(p => p.State).
                Include(k => k.Customers).
                ToList();
        }

        public Organization GetOrganizationById(int id)
        {
            return _appDbContext.Organizations.Include(h => h.State).
                Include(k => k.Customers).
                FirstOrDefault(l => l.Id == id);
        }
    }
}
