using PecanhaBruno.WebBarberShop.Domain.Entities;
using System.Collections.Generic;

namespace PecanhaBruno.WebBarberShop.Domain.Interface.Service {
    public interface ICustumerService : IServiceBase<Customer> {
        Customer AddWithReturn(Customer customer);
        List<CustumerXServices> GetAllSelectedCustomerServices(int customerId);      
        void EndAllCustomerServicesInQueue(int companyId);
        bool IsCustomerAlreadyInQueue(int userId);
        string ElapsedTime(int customerId);
        bool CallNextCustomerInQueue(int queueId);
        IList<Customer> GetCustomerByName(string name);
        void SaveCustumerSelectedServices(int companyId, Customer custumer, int[] serviceList);
        void DeleteFromQueue(int customerId);
        void UpdateCustomer(int companyId, int customerId, int[] serviceList, string comment);
        void EndCustomerService(int customerId, int companyId);
    }
}
