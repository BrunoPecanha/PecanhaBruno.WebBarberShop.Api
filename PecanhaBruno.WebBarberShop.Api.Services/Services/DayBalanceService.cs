using PecanhaBruno.WebBarberShop.Domain.Entities;
using PecanhaBruno.WebBarberShop.Domain.Interface.Repository;
using PecanhaBruno.WebBarberShop.Domain.Interface.Service;
using PecanhaBruno.WebBarberShop.Service.Properties;
using System;
using System.Collections.Generic;

namespace PecanhaBruno.WebBarberShop.Service.Services {
    public class DayBalanceService : ServiceBase<DayBalance>, IDayBalanceService
    {
        private readonly IDayBalanceRepository _dayBalanceRepositoy;

        public DayBalanceService(IDayBalanceRepository repository)
            : base(repository)
        {
            _dayBalanceRepositoy = repository;
        }

        public decimal DayAmount(int companyId)
        {
            return _dayBalanceRepositoy.DayAmount(companyId);
        }

        public DayBalance GetDayBalanceById(int companyId, int queueId)
        {
            return _dayBalanceRepositoy.GetDayBalanceById(companyId, queueId);
        }
    }
}
