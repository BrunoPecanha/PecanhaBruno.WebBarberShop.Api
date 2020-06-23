using Microsoft.EntityFrameworkCore;
using PecanhaBruno.WebBarberShop.Domain.Entities;

namespace PecanhaBruno.WebBarberShop.Infra.Context {
    public interface IWebBarberShoppContext
    {
        DbSet<Custumer> Custumer { get; }
        DbSet<CurrentQueue> Queue { get; }
        DbSet<ScheduleDay> ScheduleDay { get; }
        DbSet<ServiceType> ServiceType { get; }
        DbSet<Company> Company { get; }
        DbSet<User> User { get; }
        DbSet<CustumerXServices> CustumerSelectedServices { get; }
        DbSet<ScheduleDayXCustumers> ScheduleDayCustumers { get; }
        DbSet<DayBalance> DayBalance { get; }
    }
}
