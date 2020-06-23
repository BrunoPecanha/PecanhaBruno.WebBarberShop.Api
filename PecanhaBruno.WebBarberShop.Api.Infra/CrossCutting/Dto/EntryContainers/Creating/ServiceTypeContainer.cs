using PecanhaBruno.WebBarberShop.CrossCutting.EntitiesDto.Creating;
using PecanhaBruno.WebBarberShop.Domain.Entities;

namespace Pecanha.WebBarberShopp.CrossCutting.EntryContainers.Creating
{
    public class ServiceTypeContainer {       
        /// <summary>
        /// Corpo da mensagem
        /// </summary>
        public CreatingServiceTypeDto ServiceTypeMessage { get; set; }

        public ServiceType ToEntity() {
            return new ServiceType(ServiceTypeMessage.Name, ServiceTypeMessage.MediumTime, ServiceTypeMessage.Price, ServiceTypeMessage.CompanyId);
        } 
    }
}