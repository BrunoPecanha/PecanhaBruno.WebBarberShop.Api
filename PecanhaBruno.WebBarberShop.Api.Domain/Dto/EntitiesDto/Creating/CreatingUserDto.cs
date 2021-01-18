﻿using PecanhaBruno.WebBarberShop.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace PecanhaBruno.WebBarberShop.Domain.Dto.EntitiesDto.Creating {
    public class CreatingUserDto
    {
        /// <summary>
        /// Informações do aparelho.
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo obrigatório")]
        [Display(Name = "MobileInfo")]
        public string MobileInfo { get; set; }

        /// <summary>
        /// Nome do usuário
        /// </summary>   
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        /// <summary>
        /// Sobrenome do usuário
        /// </summary>     
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo obrigatório")]
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
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        //  public string Login { get; set; }
        /// <summary>
        /// Senha do usuário
        /// </summary>     
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo obrigatório")]
        [Display(Name = "PassWord")]
        public string PassWord { get; set; }

        /// <summary>
        /// Indica se o usuário é o proprietário.
        /// </summary>       
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Owner")]
        public bool Owner { get; set; } = false;

        /// <summary>
        /// Id da empresa
        /// </summary>     
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo obrigatório")]
        [Display(Name = "CompanyId")]
        public int CompanyId { get; set; }

        /// <summary>
        /// Gera uma instância de User a partir do container
        /// </summary>
        /// <returns></returns>
        public User ToEntity() {
            return new User(Name, LastName, Picture, Email, PassWord, Owner, MobileInfo);
        }
    }
}