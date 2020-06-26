using PecanhaBruno.WebBarberShop.Domain.Dto.EntitiesDto.Creating;
using PecanhaBruno.WebBarberShop.Domain.Entities;

namespace Pecanha.WebBarberShopp.Domain.EntryContainers.Updating
{
    public class CompanyContainerUpdating {       

        /// <summary>
        /// Corpo da mensagem
        /// </summary>
        public CreatingCompanyDto CompanyMessage { get; set; }

        /// <summary>
        /// Gera uma instância de Company a partir do container
        /// </summary>
        /// <returns></returns>
        public Company ToEntity() {
            return new Company(CompanyMessage.FantasyName.ToUpper(), CompanyMessage.RealName.ToUpper(), CompanyMessage.Cnpj,
                CompanyMessage.Address.ToUpper(), CompanyMessage.UseQueue, CompanyMessage.Logo, CompanyMessage.ConfirmationNotice, CompanyMessage.UserId);
        }
    }    
}