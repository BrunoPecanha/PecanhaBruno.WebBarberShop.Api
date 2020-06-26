using PecanhaBruno.WebBarberShop.Domain.Dto.EntitiesDto.Creating;
using PecanhaBruno.WebBarberShop.Domain.Entities;

namespace Pecanha.WebBarberShopp.Domain.EntryContainers.Updating
{
    public class CustumerContainerUpdating {
        /// <summary>
        /// Corpo da mensagem
        /// </summary>
        public CreatingCustumerDto CustumerMessage { get; set; }

        public Custumer ToEntity() {
            return new Custumer(CustumerMessage.UserId, CustumerMessage.QueueId, CustumerMessage.Comment, 0);
        }
    }
}