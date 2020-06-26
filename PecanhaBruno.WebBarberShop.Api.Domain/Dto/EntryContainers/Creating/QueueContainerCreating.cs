using PecanhaBruno.WebBarberShop.Domain.Dto.EntitiesDto.Creating;
using PecanhaBruno.WebBarberShop.Domain.Entities;

namespace Pecanha.WebBarberShopp.Domain.EntryContainers.Creating
{
    public class QueueContainerCreating {        
        /// <summary>
        /// Mensagem de entrada para criação de uma nova fila
        /// </summary>
        public CreatingQueueDto QueueMessage { get; set; }

        public CurrentQueue ToEntity() {
            return new CurrentQueue(QueueMessage.CompanyId, true);
        }
    }
}