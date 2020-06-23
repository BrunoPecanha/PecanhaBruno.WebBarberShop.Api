using PecanhaBruno.WebBarberShop.Domain.Entities;
using System.Collections.Generic;

namespace PecanhaBruno.WebBarberShop.Domain.Interface.Service {
    public interface ICustumerService : IServiceBase<Custumer> {
        Custumer AddWithReturn(Custumer customer);
        List<CustumerXServices> GetAllSelectedCustomerServices(int customerId);      
        void EndAllCustomerServicesInQueue(int companyId);
        bool IsCustomerAlreadyInQueue(int userId);
        string ElapsedTime(int customerId);
        bool CallNextCustomerInQueue(int queueId);
        IList<Custumer> GetCustomerByName(string name);
        void SaveCustumerSelectedServices(Custumer custumer, int[] serviceList);
    }
}
