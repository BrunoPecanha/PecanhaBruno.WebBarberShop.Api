using Microsoft.EntityFrameworkCore;
using PecanhaBruno.WebBarberShop.Domain.Entities;
using PecanhaBruno.WebBarberShop.Domain.Interface.Repository;
using PecanhaBruno.WebBarberShop.Infra.Context;
using System.Collections.Generic;
using System.Linq;

namespace PecanhaBruno.WebBarberShop.Infra.Data.Repositories {
    public class ServiceTypeRepository : RepositoryBase<ServiceType>, IServiceTypeRepository {

        private IWebBarberShoppContext _dbContext { get; }

        public ServiceTypeRepository(IWebBarberShoppContext context) {
            _dbContext = context;
        }

        /// <summary>
        /// Recupera todos os serviços de acordo com o array de serviços recebido
        /// </summary>
        /// <param name="ids">Identificador dos serviços.</param>
        /// <returns></returns>
        public ICollection<ServiceType> GetListByIds(int[] ids) {
            return _dbContext.ServiceType
                              .Join(ids, tipoServicoBd => tipoServicoBd.Id, id => id, (tipoServicoBd, id) => tipoServicoBd)
                              .ToArray();
        }

        /// <summary>
        /// Recupera um serviço pelo Id
        /// </summary>
        /// <param name="companyId">Id da empresa</param>
        /// <param name="serviceId">Id do servço.</param>
        /// <returns></returns>
        public ServiceType GetServiceById(int companyId, int serviceId) {
            return _dbContext.ServiceType
                             .Include(x => x.Company)
                             .FirstOrDefault(x => x.Id == serviceId && x.Company.Id == companyId);

        }

        /// <summary>
        /// Recupera a lista de serviços do cliente
        /// </summary>
        /// <param name="customerId">Id do cliente</param>
        /// <returns></returns>
        public IList<ServiceType> GetServicesByCustomer(int customerId) {
            return _dbContext.CustumerSelectedServices
                                          .Include(x => x.Service)
                                          .Include(x => x.Custumer)
                                          .Where(x => x.Custumer.Id == customerId)
                                          .Select(x => x.Service)
                                          .ToArray();

        }
    }
}
