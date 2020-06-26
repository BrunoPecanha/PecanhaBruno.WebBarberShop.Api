using Microsoft.EntityFrameworkCore;
using PecanhaBruno.WebBarberShop.Domain.Entities;
using PecanhaBruno.WebBarberShop.Domain.Interface.Repository;
using PecanhaBruno.WebBarberShop.Infra.Context;
using System.Collections.Generic;
using System.Linq;

namespace PecanhaBruno.WebBarberShop.Infra.Data.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository {
        private IWebBarberShoppContext _dbContext { get; }

        public UserRepository(IWebBarberShoppContext context) {
            _dbContext = context;
           
        }
        public void DeleteUser(int userId) {
            User user = _dbContext.User
                      .Include(x => x.Company)
                      .FirstOrDefault(x => x.Id == userId);
            _dbContext.User.Remove(user);        
        }

        public bool isThereTransactionsForThisUser(int userId) {
            return _dbContext.Custumer
                             .Any(x => x.UserId == userId);
        }

        public void SoftDeleteUser(User user) {
            _dbContext.User.Update(user);
        }

        public bool IsThereAlreadyThisEmail(string email) {
            return _dbContext.User
                             .Any(x => x.Email.Equals(email));
        }

        public User GetUserById(int id) {
            return _dbContext.User
                             .FirstOrDefault(x => x.Id == id);
        }

        public IReadOnlyCollection<User> GetAllUsers(int companyId) {
            return _dbContext.User
                             .Where(x => x.CompanyId == companyId)
                             .ToArray();
        }
    }
}
