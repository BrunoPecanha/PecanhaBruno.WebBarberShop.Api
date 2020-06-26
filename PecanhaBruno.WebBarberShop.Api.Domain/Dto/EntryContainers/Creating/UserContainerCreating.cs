using PecanhaBruno.WebBarberShop.Domain.Dto;
using PecanhaBruno.WebBarberShop.Domain.Entities;

namespace Pecanha.WebBarberShopp.Domain.EntryContainers.Creating
{
    public class UserContainerCreating
    {
        /// <summary>
        /// Cabecalho da mensagem
        /// </summary>
        public MessageHead Head { get; set; }

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
        public string Picture { get; set; }
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
        /// Id da empresa
        /// </summary>       
        public int CompanyId { get; set; }

        /// <summary>
        /// Gera uma instância de User a partir do container
        /// </summary>
        /// <returns></returns>
        public User ToEntity() {
            return new User(Name, LastName, Picture, Email, PassWord, Owner, Head.MobileInfo);
        }
    }
}