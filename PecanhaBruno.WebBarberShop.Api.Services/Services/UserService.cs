using PecanhaBruno.WebBarberShop.Domain.Entities;
using PecanhaBruno.WebBarberShop.Domain.Interface.Repository;
using PecanhaBruno.WebBarberShop.Domain.Interface.Service;

namespace PecanhaBruno.WebBarberShop.Service.Services {
    public class UserService : ServiceBase<User>, IUserService {

        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
            : base(repository) {
            _repository = repository;
        }

        public void CreateNewUser(User User) {
            _repository.Add(User);

        }

        public void DeleteUser(int id) {
            _repository.DeleteUser(id);
        }

        public void SoftDeleteUser(User user) {
            _repository.SoftDeleteUser(user);
        }

        /// <summary>
        /// Verifica se o usuário já foi atendido alguma vez.
        /// </summary>
        /// <param name="userId">Id do usuário.</param>
        /// <returns></returns>
        public bool IsThereTransactionsForThisUser(int userId) {
            return _repository.isThereTransactionsForThisUser(userId);
        }

        public bool IsThereAlreadyThisEmail(string email) {
            return _repository.IsThereAlreadyThisEmail(email);
        }
    }
}
