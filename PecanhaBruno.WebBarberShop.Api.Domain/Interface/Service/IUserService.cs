using PecanhaBruno.WebBarberShop.Domain.Entities;

namespace PecanhaBruno.WebBarberShop.Domain.Interface.Service {
    public interface IUserService : IServiceBase<User> {
        void CreateNewUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int userId);       
    }
}
