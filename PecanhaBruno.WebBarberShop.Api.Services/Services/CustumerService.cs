using PecanhaBruno.WebBarberShop.Domain.Entities;
using PecanhaBruno.WebBarberShop.Domain.Interface.Repository;
using PecanhaBruno.WebBarberShop.Domain.Interface.Service;
using PecanhaBruno.WebBarberShop.Service.Properties;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace PecanhaBruno.WebBarberShop.Service.Services {
    public class CustumerService : ServiceBase<Custumer>, ICustumerService {

        private readonly ICustumerRepository _repositoy;
        private readonly ICustumerSelectedServicesRepository _customerRepository;
        private readonly ICurrentQueueRepository _currentQueueRepository;
        public CustumerService(ICustumerRepository repository, ICustumerSelectedServicesRepository customer, ICurrentQueueRepository currentQueueRepository)
            : base(repository) {
            _repositoy = repository;
            _customerRepository = customer;
           _currentQueueRepository = currentQueueRepository;
        }

        /// <summary>
        /// Inseri um novo cliente e o retorna.
        /// </summary>
        /// <param name="customer">Objeto cliente recebido</param>
        /// <returns></returns>
        public Custumer AddWithReturn(Custumer customer) {
            _repositoy.Add(customer);
            return customer;
        }


        /// <summary>
        /// Recupera os seviços selecionados pelo usuário que gerou o cliente.
        /// </summary>
        /// <param name="customerId">Id do cliente.</param>
        /// <returns></returns>
        public List<CustumerXServices> GetAllSelectedCustomerServices(int customerId) {
            return _customerRepository.GetAllSelectedCustomerServices(customerId);
        }

        /// <summary>
        /// Finaliza todos os cliente da fila aberta para empresa.
        /// </summary>
        /// <param name="companyId">Id da empresa</param>
        public void EndAllCustomerServicesInQueue(int companyId) {
            ICollection<Custumer> allcustomersInQueue = _currentQueueRepository.GetAllCustumersInCurrentQueue(companyId);

            foreach (var customer in allcustomersInQueue) {
                customer.UpdateServiceStatus();
                _repositoy.Update(customer);
            }
        }       

        /// <summary>
        /// Verifica se o cliente já está na fila.
        /// </summary>
        /// <param name="userId">Id do usuário.</param>
        /// <returns></returns>
        public bool IsCustomerAlreadyInQueue(int userId) {
            return _repositoy.IsCustomerAlreadyInQueue(userId);
        }

        public string ElapsedTime(int customerId) {
            Custumer customer = _repositoy.GetById(customerId);

            if (customer is null)
                return null;

           TimeSpan diff = DateTime.Now - customer.RegisteringDate;
           return string.Format(
                           CultureInfo.CurrentCulture,
                           "{0}h:{1}m",
                           diff.Hours,
                           diff.Minutes
                           );
                     
        }

        /// <summary>
        /// Chama o próximo da fila
        /// </summary>
        public bool CallNextCustomerInQueue(int queueId) {
           var newCurrentCustomer = _repositoy.CallNextCustomerInQueue(queueId);
            if (newCurrentCustomer is null)
                return false;
            newCurrentCustomer.CurrentCustomerInService = true;
            _repositoy.Update(newCurrentCustomer);
            return true;
        }

        /// <summary>
        /// Recupera o cliente pelo nome
        /// </summary>
        /// <param name="name">Nome do cliente.</param>
        /// <returns>Retorna a lista com os cliente que batem com a descrição.</returns>
        public IList<Custumer> GetCustomerByName(string name) {
            return _repositoy.GetCustomerByName(name);
        }

        public void SaveCustumerSelectedServices(Custumer custumer, int[] serviceList) {
            bool isThereQueStarted = _QueueRepository.IsThereQueueStarted(custumerDto.CustumerMessage.CompanyId);
            bool isCustomerAlreadyInQueue = _CustumerService.IsCustomerAlreadyInQueue(custumerDto.CustumerMessage.UserId);

            if (!isThereQueStarted) {
                return new DefaultOutPutContainer()
                {
                    Valid = false,
                    Message = Resources.mNoQueueWasFound
                };
            } else if (isCustomerAlreadyInQueue) {
                return new DefaultOutPutContainer()
                {
                    Valid = false,
                    Message = Resources.mCustomerAlreadyInQueue
                };
            }

            User user = _UserService.GetById(custumerDto.CustumerMessage.UserId);
            CurrentQueue currentQueue = _QueueRepository.GetCurrentQueue(custumerDto.CustumerMessage.CompanyId);

            if (user is null) {
                throw new Exception(string.Format(Resources.mNoUserWasFoundWithId, custumerDto.CustumerMessage.UserId));
            } else if (currentQueue is null) {
                throw new Exception(string.Format(Resources.mNoQueueWasFound));
            }

            int position = _QueueRepository.GetNextPositionInQueue(custumerDto.CustumerMessage.CompanyId, currentQueue.Id);
            var customer = new Custumer(user.Id, currentQueue.Id, custumerDto.CustumerMessage.Comment, position);

            _CustumerService.Add(customer);

            foreach (int serviceId in custumerDto.CustumerMessage.ServiceList) {
                ServiceType service = _ServiceTypeServices.GetServiceById(custumerDto.CustumerMessage.CompanyId, serviceId);

                if (service != null) {
                    _CustumerSelectedServicesRepository.Add(new CustumerXServices(service, customer));
                }
            }
        }
    }
}
