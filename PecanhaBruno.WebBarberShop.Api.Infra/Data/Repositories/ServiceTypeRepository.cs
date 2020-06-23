using Microsoft.EntityFrameworkCore;
using PecanhaBruno.WebBarberShop.Domain.Entities;
using PecanhaBruno.WebBarberShop.Domain.Interface.Repository;
using PecanhaBruno.WebBarberShop.Infra.Context;
using System.Collections.Generic;
using System.Linq;

namespace PecanhaBruno.WebBarberShop.Infra.Data.Repositories {
    public class ServiceTypeRepository : RepositoryBase<ServiceType>, IServiceTypeRepository {

        private IWebBarberShoppContext _dbContext { get; }

        public ServiceTypeRepository(IWebBarberShoppContext context)
        {
            _dbContext = context;
        }

        /// <summary>
        /// Recupera todos os serviços de acordo com o array de serviços recebido
        /// </summary>
        /// <param name="ids">Identificador dos serviços.</param>
        /// <returns></returns>
        public ICollection<ServiceType> GetListByIds(int[] ids)
        {
           return  _dbContext.ServiceType
                             .Join(ids, tipoServicoBd => tipoServicoBd.Id, id => id, (tipoServicoBd, id) => tipoServicoBd)
                             .ToArray();
        }
    }
}
