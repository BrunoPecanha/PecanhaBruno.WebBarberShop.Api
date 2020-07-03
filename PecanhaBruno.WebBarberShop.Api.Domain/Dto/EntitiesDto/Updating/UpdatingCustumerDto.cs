using System.ComponentModel.DataAnnotations;

namespace PecanhaBruno.WebBarberShop.Domain.Dto.EntitiesDto.Updating {
    public class UpdatingCustumerDto {
        /// <summary>
        /// Id do cliente
        /// </summary>
        public int CustumerId { get; set; }

        // <summary>
        /// Id da empresa
        /// </summary>
        public int CompanyId { get; set; }

        /// <summary>
        /// Lista de serviços escolhidos pelo usuário.
        /// </summary>        
        [Display(Name = "ServiceList")]
        public int[] ServiceList { get; set; }

        /// <summary>
        /// Objeto usuário que será atribuído o serviço.
        /// </summary>
        public string Comment { get; set; }
    }
}