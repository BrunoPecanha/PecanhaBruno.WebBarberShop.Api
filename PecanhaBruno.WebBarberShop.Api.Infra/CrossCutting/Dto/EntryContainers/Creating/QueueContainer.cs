using PecanhaBruno.WebBarberShop.CrossCutting.EntitiesDto.Creating;
using PecanhaBruno.WebBarberShop.Domain.Entities;

namespace Pecanha.WebBarberShopp.CrossCutting.EntryContainers.Creating {
    public class QueueContainer {        
        /// <summary>
        /// Mensagem de entrada para criação de uma nova fila
        /// </summary>
        public CreatingQueueDto QueueMessage { get; set; }

        public CurrentQueue ToEntity() {
            return new CurrentQueue(QueueMessage.CompanyId, true);
        }
    }
}