using System.ComponentModel.DataAnnotations;

namespace PecanhaBruno.WebBarberShop.CrossCutting.EntitiesDto.Creating {
    public class CreatingQueueDto {       
        /// <summary>
        /// Objeto usuário que iniciará a fila.
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo obrigatório")]
        [Display(Name = "UserId")]
        public int UserId { get; set; }

        /// <summary>
        /// Objeto usuário que iniciará a fila.
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo obrigatório")]
        [Display(Name = "CompanyId")]
        public int CompanyId { get; set; }
    }
}