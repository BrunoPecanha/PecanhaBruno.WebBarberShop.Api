using PecanhaBruno.WebBarberShop.Domain.Dto;
using PecanhaBruno.WebBarberShop.Domain.Entities;

namespace PecanhaBruno.WebBarberShop.Domain.Interface.Service {
    public interface IUserService : IServiceBase<User> {
        DefaultOutPutContainer CreateNewUser(User user);
        DefaultOutPutContainer UpdateUser(User user);
        DefaultOutPutContainer DeleteUser(int userId);       
    }
}
