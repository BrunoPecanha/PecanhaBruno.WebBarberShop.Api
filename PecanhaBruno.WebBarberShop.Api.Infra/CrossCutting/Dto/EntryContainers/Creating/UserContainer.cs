using PecanhaBruno.WebBarberShop.CrossCutting.EntitiesDto.Creating;
using PecanhaBruno.WebBarberShop.CrossCutting.EntryContainers;
using PecanhaBruno.WebBarberShop.Domain.Entities;

namespace Pecanha.WebBarberShopp.CrossCutting.EntryContainers.Creating
{
    public class UserContainer
    {
        /// <summary>
        /// Cabecalho da mensagem
        /// </summary>
        public MessageHead Head { get; set; }
        /// <summary>
        /// Corpo da mensagem
        /// </summary>
        public CreatingUserDto UserMessage { get; set; }

        /// <summary>
        /// Gera uma instância de User a partir do container
        /// </summary>
        /// <returns></returns>
        public User ToEntity() {
            return new User(UserMessage.Name, UserMessage.LastName, UserMessage.Picture, UserMessage.Email,
                UserMessage.PassWord, UserMessage.Owner, Head.MobileInfo);
        }
    }
}