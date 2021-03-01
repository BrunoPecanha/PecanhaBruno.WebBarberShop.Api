using PecanhaBruno.WebBarberShop.Domain.Entities;
using System.Collections.Generic;

namespace PecanhaBruno.WebBarberShop.Domain.Interface.Service {
    public interface IServiceTypeService : IServiceBase<ServiceType> {
        ICollection<ServiceType> GetAllServicesType(int companyId, int page, int qtd);
        void UpdateService(ServiceType serviceType);
        void TryHardDelete(int id);
        void CreateNewService(ServiceType serviceDto);
        ServiceType GetServiceById( int id);
        ICollection<ServiceType> GetServicesByCustomer(int userId);
    }
}
