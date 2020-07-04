using PecanhaBruno.WebBarberShop.Domain.Dto;
using PecanhaBruno.WebBarberShop.Domain.Entities;
using PecanhaBruno.WebBarberShop.Domain.Interface.Repository;
using PecanhaBruno.WebBarberShop.Domain.Interface.Service;
using PecanhaBruno.WebBarberShop.Service.Properties;
using System;

namespace PecanhaBruno.WebBarberShop.Service.Services
{
    public class UserService : ServiceBase<User>, IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
            : base(repository)
        {
            _repository = repository;            
        }

        public DefaultOutPutContainer CreateNewUser(User user)
        {
            if (_repository.IsThereAlreadyThisEmail(user.Email))
                throw new Exception(Resources.mEmailAlreadyInUse);

            _repository.Add(user);

            return new DefaultOutPutContainer()
            {
                Id = user.Id,
                Valid = true,
                Message = Resources.mSucceedCreated
            };
        }

        public DefaultOutPutContainer DeleteUser(int id)
        {

            User user = _repository.GetById(id);

            if (user is null)
            {
                throw new Exception(Resources.mUserNotFound);

            }
            else if (user.Owner)
            {
                throw new Exception(Resources.mCantDeleteOwnerUser);
            }

            bool isThereTransactionsForThisUser = _repository.isThereTransactionsForThisUser(user.Id);

            if (isThereTransactionsForThisUser)
            {
                user.UpdateActivated(false);
                _repository.Update(user);
            }
            else
            {
                _repository.Remove(user);
            }

            return new DefaultOutPutContainer()
            {
                Valid = true,
                Message = Resources.mSuceedDeleted
            };
        }       

        public DefaultOutPutContainer UpdateUser(User user)
        {
            return new DefaultOutPutContainer()
            {
                Valid = true,
                Message = Resources.mSuceedDeleted
            };
        }
    }
}
