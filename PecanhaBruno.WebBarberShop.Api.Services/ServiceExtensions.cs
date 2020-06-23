using Microsoft.Extensions.DependencyInjection;
using Pecanha.WebBaberShopp.Infra.Context;
//using PecanhaBruno.WebBarberShop.Application.AppService;
//using PecanhaBruno.WebBarberShop.Application.Interface;
using PecanhaBruno.WebBarberShop.Domain.Interface.Repository;
using PecanhaBruno.WebBarberShop.Domain.Interface.Service;
using PecanhaBruno.WebBarberShop.Infra.Context;
using PecanhaBruno.WebBarberShop.Infra.Data.Repositories;
using PecanhaBruno.WebBarberShop.Service.Services;

namespace PecanhaBruno.WebBarberShop.Service {
    public static class ServiceExtensions
    {
         public static IServiceCollection RegisterServices(this IServiceCollection services, string connectionString) {
            
          //  services.AddDbContext<WebBarberShoppContext>(o => o.UseSqlServer(connectionString));

            services.AddTransient<ICompanyService, CompanyService>();
            services.AddTransient<ICompanyRepository, CompanyRepository>();
        //    services.AddTransient<ICompanyAppService, CompanyServiceApp>();

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IUserRepository, UserRepository>();
         //   services.AddTransient<IUserAppService, UserServiceApp>();            

          //  services.AddTransient<IQueueAppService, QueueServiceApp>();
            services.AddTransient<ICurrentQueueRepository, CurrentQueueRepository>();
            services.AddTransient<ICurrentQueueService, CurrentQueueService>();

         //   services.AddTransient<IServiceTypeAppService, ServiceTypeServiceApp>();
            services.AddTransient<IServiceTypeRepository, ServiceTypeRepository>();
            services.AddTransient<IServiceTypeService, ServiceTypeService>();

         //   services.AddTransient<ICustumerAppService, CustumerServiceApp>();
            services.AddTransient<ICustumerRepository, CustumerRepository>();
            services.AddTransient<ICustumerService, CustumerService>();

         //   services.AddTransient<IDayBalanceAppService, DayBalanceServiceApp>();
            services.AddTransient<IDayBalanceRepository, DayBalanceRepository>();
            services.AddTransient<IDayBalanceService, DayBalanceService>();

            services.AddTransient<ICustumerSelectedServicesRepository, CustumerSelectedServicesRepository>();
            services.AddTransient<IWebBarberShoppContext, WebBarberShoppContext>();

            return services;
        }
    }
}
