using PecanhaBruno.WebBarberShop.Domain.Dto;
using PecanhaBruno.WebBarberShop.Domain.Entities;

namespace Pecanha.WebBarberShopp.Domain.EntryContainers.Creating
{
    public class CompanyContainerCreating
    {

        public MessageHead Head { get; set; }

        /// <summary>
        /// Corpo da mensagem
        /// </summary>
        /// <summary>
        /// Nome fanatasia da empresa.
        /// </summary>       
        public string FantasyName { get; set; }

        /// <summary>
        /// Razão Social da empresa
        /// </summary>
        public string RealName { get; set; }

        /// <summary>
        /// CNPJ da empresa
        /// </summary>
        public string Cnpj { get; set; }

        /// <summary>
        /// Endereço da empresa
        /// </summary>
        public string Address { get; set; }

        // <summary>
        /// Forma como trabalha ( Agendado ou Fila )
        /// </summary>        
        public bool UseQueue { get; set; }
        /// <summary>
        /// Logo do estabelecimento
        /// </summary>        
        public string Logo { get; set; }
        /// <summary>
        /// Flag que indica se haverá aviso de chamada no App.
        /// </summary>
        public bool ConfirmationNotice { get; set; }
        /// <summary>
        /// Id do usuário proprietário
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gera uma instância de Company a partir do container
        /// </summary>
        /// <returns></returns>
        public Company ToEntity()
        {
            return new Company(FantasyName.ToUpper(), RealName.ToUpper(), Cnpj, Address.ToUpper(), UseQueue, Logo, ConfirmationNotice, UserId);
        }
    }
}