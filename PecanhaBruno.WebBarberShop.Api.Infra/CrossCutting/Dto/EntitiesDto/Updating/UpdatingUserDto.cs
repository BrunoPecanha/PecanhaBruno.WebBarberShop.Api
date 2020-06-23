using System.ComponentModel.DataAnnotations;

namespace PecanhaBruno.WebBarberShop.CrossCutting.EntitiesDto.Updating {
    public class UpdatingUserDto {
        
        /// <summary>
        /// Id do usuário
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Id")]
        public int Id { get; set; }

        /// <summary>
        /// Nome do usuário
        /// </summary>
        [Display(Name = "Name")]
        public string Name { get; set; }

        /// <summary>
        /// Sobrenome do usuário
        /// </summary>
        [Display(Name = "LastName")]
        public string LastName { get; set; }

        //TODO - Ver como enviar e gravar imagens no BD
        /// <summary>
        /// Foto do usuário
        /// </summary>
        [Display(Name = "Picture")]
        public string Picture { get; set; }
        
        /// <summary>
        /// Email do usuário
        /// </summary>       
        [Display(Name = "Email")]
        public string Email { get; set; }       
        /// <summary>
        /// Senha do usuário
        /// </summary>
        [Display(Name = "PassWord")]
        public string PassWord { get; set; }
              
        /// <summary>
        /// Id da empresa
        /// </summary>
        [Display(Name = "CompanyId")]
        public int CompanyId { get; set; }
    }
}