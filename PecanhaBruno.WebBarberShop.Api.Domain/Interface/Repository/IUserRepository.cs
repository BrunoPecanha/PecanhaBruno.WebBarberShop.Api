using PecanhaBruno.WebBarberShop.Domain.Entities;

namespace PecanhaBruno.WebBarberShop.Domain.Interface.Repository {
    public interface IUserRepository : IRepositoryBase<User> {
        void DeleteUser(int userId);
        void SoftDeleteUser(User user);
        bool isThereTransactionsForThisUser(int userId);
        bool IsThereAlreadyThisEmail(string email);
    }
}
