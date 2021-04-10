using Microsoft.AspNetCore.Http;
using PecanhaBruno.WebBarberShop.Domain.Entities;
using PecanhaBruno.WebBarberShop.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace PecanhaBruno.WebBarberShop.Service.Dto.EntitiesDto.Updating {
    public class UpdatingUserDto
    {
        /// <summary>
        /// Informações do aparelho.
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo obrigatório")]
        [Display(Name = "MobileInfo")]
        public int MobileInfo { get; set; }

        /// <summary>
        /// Nome do usuário
        /// </summary>   
        public string Name { get; set; }

        /// <summary>
        /// Sobrenome do usuário
        /// </summary>       
        public string LastName { get; set; }

        //TODO - Ver como enviar e gravar imagens no BD
        /// <summary>
        /// Foto do usuário
        /// </summary>      
        public IFormFile Picture { get; set; }
        /// <summary>
        /// Email do usuário
        /// </summary>        
        public string Email { get; set; }

        //  public string Login { get; set; }
        /// <summary>
        /// Senha do usuário
        /// </summary>        
        public string PassWord { get; set; }
        /// <summary>
        /// Indica se o usuário é o proprietário.
        /// </summary>       
        public bool Owner { get; set; }

        /// <summary>
        /// Gera uma instância de User a partir do container
        /// </summary>
        /// <returns></returns>
        public User ToEntity() {
            return new User(Name, LastName, Email, PassWord, Owner, Picture, (MobileEnum)MobileInfo);
        }
    }
}