using System.ComponentModel.DataAnnotations;

namespace PecanhaBruno.WebBarberShop.Domain.Dto.EntitiesDto.Creating
{
    public class CreatingCustumerDto
    {
        /// <summary>
        /// Id da empresa a qual será associado o usuário.
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo obrigatório")]
        [Display(Name = "CompanyId")]
        public int CompanyId { get; set; }

        /// <summary>
        /// Id da fila que o usuário ser inserido.
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo obrigatório")]
        [Display(Name = "QueueId")]
        public int QueueId { get; set; }

        /// <summary>
        /// Objeto usuário que será atribuído o serviço.
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo obrigatório")]
        [Display(Name = "UserId")]
        public int UserId { get; set; }

        /// <summary>
        /// Objeto usuário que será atribuído o serviço.
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Comment")]
        public string Comment { get; set; }

        /// <summary>
        /// Lista de serviços escolhidos pelo usuário.
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo obrigatório")]
        [Display(Name = "ServiceList")]
        public int[] ServiceList { get; set; }
    }
}