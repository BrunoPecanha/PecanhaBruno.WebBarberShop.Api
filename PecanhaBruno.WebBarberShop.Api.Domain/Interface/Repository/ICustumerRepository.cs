using PecanhaBruno.WebBarberShop.Domain.Entities;
using System.Collections.Generic;

namespace PecanhaBruno.WebBarberShop.Domain.Interface.Repository {
    public interface ICustumerRepository : IRepositoryBase<Custumer> {       
        bool IsCustomerAlreadyInQueue(int userId);
        Custumer CallNextCustomerInQueue(int queueId);
        IList<Custumer> GetCustomerByName(string name);
    }
}
