using System.ComponentModel.DataAnnotations;

namespace PecanhaBruno.WebBarberShop.Domain.Dto.EntitiesDto.Creating
{
    public class CreatingScheduleDayDto {
        /// <summary>
        /// Nome fanatasia da empresa.
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo obrigatório")]
        [Display(Name = "FantasyName")]
        public string FantasyName { get; set; }
    }
}