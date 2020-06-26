using PecanhaBruno.WebBarberShop.Domain.Entities;
using System.Collections.Generic;

namespace PecanhaBruno.WebBarberShop.Domain.Interface.Repository
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        bool isThereTransactionsForThisUser(int userId);
        bool IsThereAlreadyThisEmail(string email);
        User GetUserById(int id);
        IReadOnlyCollection<User> GetAllUsers(int companyId);
    }
}
