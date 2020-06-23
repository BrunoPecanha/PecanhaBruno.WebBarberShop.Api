using System.ComponentModel.DataAnnotations;

namespace PecanhaBruno.WebBarberShop.CrossCutting.EntitiesDto.Updating {
    public class UpdatingCustumerDto
    {
        /// <summary>
        /// Id do cliente
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo obrigatório")]
        [Display(Name = "CustumerId")]
        public int CustumerId { get; set; }

        /// <summary>
        /// Lista de serviços escolhidos pelo usuário.
        /// </summary>        
        [Display(Name = "ServiceList")]
        public int[] ServiceList { get; set; }

        /// <summary>
        /// Objeto usuário que será atribuído o serviço.
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Comment")]
        public string Comment { get; set; }
    }
}