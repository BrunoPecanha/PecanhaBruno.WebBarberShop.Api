using PecanhaBruno.WebBarberShop.CrossCutting.EntryContainers;
using PecanhaBruno.WebBarberShop.Domain.Entities;
using PecanhaBruno.WebBarberShop.Domain.Interface.Repository;
using PecanhaBruno.WebBarberShop.Domain.Interface.Service;
using PecanhaBruno.WebBarberShop.Service.Properties;
using System;
using System.Collections.Generic;

namespace PecanhaBruno.WebBarberShop.Service.Services {
    public class CurrentQueueService : ServiceBase<CurrentQueue>, ICurrentQueueService {
        private ICurrentQueueRepository _currentRepositoy { get; }
        private ICompanyRepository _companyRepository { get; }
        private ICustumerService _customerService { get; }

        public CurrentQueueService(ICurrentQueueRepository currentRepositoy, ICompanyRepository companyRepository, ICustumerService customerService)
            : base(currentRepositoy) {
            _currentRepositoy = currentRepositoy;
            _companyRepository = companyRepository;
            _customerService = customerService;
        }

        /// <summary>
        /// Finaliza a fila para aquele dia e encerra todos os cliente que estiverem em aberto.
        /// </summary>
        /// <param name="companyId">Id da empresa.</param>
        public CurrentQueue FinishQueue(int companyId) {
            CurrentQueue queue = _currentRepositoy.GetCurrentQueue(companyId);

            _customerService.EndAllCustomerServicesInQueue(companyId);
            queue.EndQueue();

            _currentRepositoy.Update(queue);
            return queue;
        }

        public ICollection<CurrentQueue> GetAllCurrentQueues(int page, int qtd) {
            return _currentRepositoy.GetAllCurrentQueues(page, qtd);
        }

        /// <summary>
        /// Inicia a fila para a empresa.
        /// </summary>
        /// <param name="queue">Fila a ser inicializada.</param>
        /// <returns></returns>
        public CurrentQueue StartQueue(CurrentQueue queue) {
            if (_currentRepositoy.IsThereQueueStarted(queue.CompanyId))
                throw new Exception(Resources.mQueueAlreadyStarted);

            var company = _companyRepository.GetById(queue.CompanyId);

            queue.UpdateCompany(company.Id);
            _currentRepositoy.Add(queue);
            company.UpdateQueue(queue.Id);
            _companyRepository.Update(company);

            return queue;
        }

        /// <summary>
        /// Recupera todos os cliente da fila atual
        /// </summary>
        /// <param name="companyId">Id da empresa</param>
        /// <returns></returns>
        public ICollection<User> GetAllCustumersInCurrentQueue(int companyId) {
            return _currentRepositoy.GetAllUsersInCurrentQueue(companyId);
        }

        public User GetLastInCurrentQueue(int companyId) {
            var isThereQueueStarted = _currentRepositoy.IsThereQueueStarted(companyId);
            if (!isThereQueueStarted)
                throw new Exception(Resources.mNoQueueWasFound);

            return _currentRepositoy.GetLastInCurrentQueue(companyId);
        }

        public bool IsThereQueueStarted(int companyId) {
           return  _currentRepositoy.IsThereQueueStarted(companyId);           
        }

        public CurrentQueue GetCurrentQueue(int companyId) {
            return _currentRepositoy.GetCurrentQueue(companyId);
        }

        public void FinishQueue(int companyId, int userId) {
            var queue = _currentRepositoy.GetById(companyId);

            if (queue is null) {
                throw new Exception(string.Format(Resources.mNoQueueWasFound, companyId));
            }

            if (queue.Company.User.Id != userId)
                throw new Exception(Resources.mCompanyNotAssociatedToThisUser);
           
            queue.EndQueue();
            _currentRepositoy.Update(queue);

        }
    }
}