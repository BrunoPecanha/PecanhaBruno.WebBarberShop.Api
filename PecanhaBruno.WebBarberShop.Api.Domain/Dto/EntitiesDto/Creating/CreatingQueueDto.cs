using PecanhaBruno.WebBarberShop.Domain.Entities;

namespace PecanhaBruno.WebBarberShop.Domain.Dto.EntitiesDto.Creating {
    public class CreatingQueueDto {       
        /// <summary>
        /// Objeto usuário que iniciará a fila.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Objeto usuário que iniciará a fila.
        /// </summary>
        public int CompanyId { get; set; }

        public CurrentQueue ToEntity() {
            return new CurrentQueue(CompanyId, true);
        }
    }
}