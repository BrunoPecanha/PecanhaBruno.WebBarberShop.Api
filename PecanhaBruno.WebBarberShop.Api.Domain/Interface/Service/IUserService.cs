using PecanhaBruno.WebBarberShop.Domain.Entities;

namespace PecanhaBruno.WebBarberShop.Domain.Interface.Service {
    public interface IUserService : IServiceBase<User> {
        void CreateNewUser(User User);
        void DeleteUser(int id);
        void SoftDeleteUser(User user);
        bool IsThereTransactionsForThisUser(int userId);
        bool IsThereAlreadyThisEmail(string email);
    }
}
