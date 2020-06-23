using PecanhaBruno.WebBarberShop.Domain.Entities;
using System.Collections.Generic;

namespace PecanhaBruno.WebBarberShop.Domain.Interface.Repository {
    public interface IServiceTypeRepository : IRepositoryBase<ServiceType> {
        /// <summary>
        /// Recupera todos os serviços de acordo com o array de serviços recebido
        /// </summary>
        /// <param name="ids">Identificador dos serviços.</param>
        /// <returns></returns>
        ICollection<ServiceType> GetListByIds(int[] ids);
    }
}
