using PecanhaBruno.WebBarberShop.Domain.Entities;
using System.Collections.Generic;

namespace PecanhaBruno.WebBarberShop.Domain.Interface.Repository {
    public interface ICustumerRepository : IRepositoryBase<Customer> {       
        bool IsCustomerAlreadyInQueue(int userId);
        Customer CallNextCustomerInQueue(int queueId);
        IList<Customer> GetCustomerByName(string name);
    }
}
