using PecanhaBruno.WebBarberShop.Domain.Entities;

namespace PecanhaBruno.WebBarberShop.Domain.Interface.Repository {
    public interface IDayBalanceRepository : IRepositoryBase<DayBalance>
    {
        decimal DayAmount(int companyId);
        DayBalance GetDayBalanceById(int companyId, int queueId);
    }
}
