using PecanhaBruno.WebBarberShop.Domain.Entities;
using PecanhaBruno.WebBarberShop.Domain.Interface.Repository;
using PecanhaBruno.WebBarberShop.Infra.Context;
using System.Linq;

namespace PecanhaBruno.WebBarberShop.Infra.Data.Repositories
{
    public class DayBalanceRepository : RepositoryBase<DayBalance>, IDayBalanceRepository
    {
        private IWebBarberShoppContext _dbContext { get; }

        public DayBalanceRepository(IWebBarberShoppContext context)
        {
            _dbContext = context;
        }     

        /// <summary>
        /// Recupera o saldo do dia através do company id recebido
        /// </summary>
        /// <param name="companyId">Identificação da empresa.</param>
        /// <returns></returns>
        public decimal DayAmount(int companyId)
        {
            return _dbContext.DayBalance
                      .FirstOrDefault(x => x.CompanyId == companyId)
                      .Amount;
        }

        public DayBalance GetDayBalanceById(int companyId, int queueId)
        {
            return _dbContext.DayBalance
                      .FirstOrDefault(x => x.CompanyId == companyId && x.QueueId == queueId);                      
        }

    }
}
