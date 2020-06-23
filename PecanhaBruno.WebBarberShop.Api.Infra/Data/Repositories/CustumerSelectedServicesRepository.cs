using Microsoft.EntityFrameworkCore;
using PecanhaBruno.WebBarberShop.Domain.Entities;
using PecanhaBruno.WebBarberShop.Domain.Interface.Repository;
using PecanhaBruno.WebBarberShop.Infra.Context;
using System.Collections.Generic;
using System.Linq;

namespace PecanhaBruno.WebBarberShop.Infra.Data.Repositories 
{
    public class CustumerSelectedServicesRepository : RepositoryBase<CustumerXServices>, ICustumerSelectedServicesRepository
    {
        private IWebBarberShoppContext _dbContext { get; }
        public CustumerSelectedServicesRepository(IWebBarberShoppContext context)
        {
            _dbContext = context;
        }

        public List<CustumerXServices> GetAllSelectedCustomerServices(int customerId)
        {
            return _dbContext.CustumerSelectedServices
                             .Include(x => x.Custumer)
                             .Where(x => x.Custumer.Id == customerId)
                             .ToList();
        }
    }
}
