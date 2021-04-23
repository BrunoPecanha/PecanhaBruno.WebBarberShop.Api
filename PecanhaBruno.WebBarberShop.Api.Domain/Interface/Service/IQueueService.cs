using PecanhaBruno.WebBarberShop.Domain.Entities;
using System.Collections.Generic;

namespace PecanhaBruno.WebBarberShop.Domain.Interface.Service {
    public interface ICurrentQueueService : IServiceBase<CurrentQueue> {
        CurrentQueue StartQueue(CurrentQueue queue);
        ICollection<CurrentQueue> GetAllCurrentQueues(int page, int qtd);
        void FinishQueue(int companyId, int userId);
        ICollection<Customer> GetAllCustumersInCurrentQueue(int companyId);
        User GetLastInCurrentQueue(int companyId);
        bool IsThereQueueStarted(int companyId);
        CurrentQueue GetCurrentQueue(int companyId);
    }
}
