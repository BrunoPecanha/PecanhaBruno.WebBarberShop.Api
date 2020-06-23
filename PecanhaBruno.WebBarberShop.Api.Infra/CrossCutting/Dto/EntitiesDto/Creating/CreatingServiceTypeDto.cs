using System.ComponentModel.DataAnnotations;

namespace PecanhaBruno.WebBarberShop.CrossCutting.EntitiesDto.Creating {
    public class CreatingServiceTypeDto
    {
        /// <summary>
        /// Id da empresa dona do serviço.
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo obrigatório")]
        [Display(Name = "CompanyId")]
        public int CompanyId { get; set; }
        /// <summary>
        /// Nome do serviço.
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        /// <summary>
        /// Tempo médio de cada serviço
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo obrigatório")]
        [Display(Name = "MediumTime")]
        public int MediumTime { get; set; }

        /// <summary>
        /// Preço do serviço.
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Price")]
        public decimal Price { get; set; }
    }
}