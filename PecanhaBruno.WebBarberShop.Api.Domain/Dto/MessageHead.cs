using System.ComponentModel.DataAnnotations;

namespace PecanhaBruno.WebBarberShop.Domain.Dto {

    /// <summary>
    /// Cabeçalho padrão para mensagens de entrada.
    /// </summary>
    public class MessageHead
    {
        /// <summary>
        /// Informações do aparelho.
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo obrigatório")]
        [Display(Name = "MobileInfo")]
        public string MobileInfo { get; set; }
    }
}