using PecanhaBruno.WebBarberShop.Domain.Entities;
using PecanhaBruno.WebBarberShop.Domain.Interface.Repository;
using PecanhaBruno.WebBarberShop.Domain.Interface.Service;

namespace PecanhaBruno.WebBarberShop.Service.Services {
    public class ScheduleDayService : ServiceBase<ScheduleDay>, IScheduleDayService {

        private readonly IScheduleDayRepository _repositoy;
        public ScheduleDayService(IScheduleDayRepository repository) 
            : base(repository) {
            _repositoy = repository;
        }       
    }
}
