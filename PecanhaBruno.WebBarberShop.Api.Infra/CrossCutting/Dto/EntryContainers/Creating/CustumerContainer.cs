using PecanhaBruno.WebBarberShop.CrossCutting.EntitiesDto.Creating;
using PecanhaBruno.WebBarberShop.Domain.Entities;

namespace PecanhaBruno.WebBarberShop.CrossCutting.EntryContainers.Creating
{
    public class CustumerContainer {
        /// <summary>
        /// Corpo da mensagem
        /// </summary>
        public CreatingCustumerDto CustumerMessage { get; set; }

        public Custumer ToEntity() {
            return new Custumer(CustumerMessage.UserId, CustumerMessage.QueueId, CustumerMessage.Comment, 0);
        }
    }
}