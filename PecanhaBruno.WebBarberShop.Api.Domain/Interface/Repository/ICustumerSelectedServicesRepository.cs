using PecanhaBruno.WebBarberShop.Domain.Entities;
using System.Collections.Generic;

namespace PecanhaBruno.WebBarberShop.Domain.Interface.Repository {
    public interface ICustumerSelectedServicesRepository : IRepositoryBase<CustumerXServices> {
        List<CustumerXServices> GetAllSelectedCustomerServices(int customerId);
        
    }
}
