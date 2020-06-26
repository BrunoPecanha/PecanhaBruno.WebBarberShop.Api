using PecanhaBruno.WebBarberShop.Domain.Entities;
using PecanhaBruno.WebBarberShop.Domain.Interface.Repository;
using PecanhaBruno.WebBarberShop.Domain.Interface.Service;
using PecanhaBruno.WebBarberShop.Service.Properties;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace PecanhaBruno.WebBarberShop.Service.Services
{
    public class CustumerService : ServiceBase<Custumer>, ICustumerService
    {
        private readonly ICustumerRepository _customerRepositoy;
        private readonly ICustumerSelectedServicesRepository _customerSelectedServicesRepository;
        private readonly ICurrentQueueRepository _currentQueueRepository;
        private readonly IUserRepository _userRepository;
        private readonly IServiceTypeService _serviceTypeService;
        public CustumerService(IUserRepository userRepository, ICustumerRepository repository, ICustumerSelectedServicesRepository customer, ICurrentQueueRepository currentQueueRepository, IServiceTypeService serviceType)
            : base(repository)
        {
            _customerRepositoy = repository;
            _customerSelectedServicesRepository = customer;
            _currentQueueRepository = currentQueueRepository;
            _userRepository = userRepository;
            _serviceTypeService = serviceType;
        }

        /// <summary>
        /// Inseri um novo cliente e o retorna.
        /// </summary>
        /// <param name="customer">Objeto cliente recebido</param>
        /// <returns></returns>
        public Custumer AddWithReturn(Custumer customer)
        {
            _customerRepositoy.Add(customer);
            return customer;
        }

        /// <summary>
        /// Recupera os seviços selecionados pelo usuário que gerou o cliente.
        /// </summary>
        /// <param name="customerId">Id do cliente.</param>
        /// <returns></returns>
        public List<CustumerXServices> GetAllSelectedCustomerServices(int customerId)
        {
            return _customerSelectedServicesRepository.GetAllSelectedCustomerServices(customerId);
        }

        /// <summary>
        /// Finaliza todos os cliente da fila aberta para empresa.
        /// </summary>
        /// <param name="companyId">Id da empresa</param>
        public void EndAllCustomerServicesInQueue(int companyId)
        {
            ICollection<Custumer> allcustomersInQueue = _currentQueueRepository.GetAllCustumersInCurrentQueue(companyId);

            foreach (var customer in allcustomersInQueue)
            {
                customer.UpdateServiceStatus();
                _customerRepositoy.Update(customer);
            }
        }

        /// <summary>
        /// Verifica se o cliente já está na fila.
        /// </summary>
        /// <param name="userId">Id do usuário.</param>
        /// <returns></returns>
        public bool IsCustomerAlreadyInQueue(int userId)
        {
            return _customerRepositoy.IsCustomerAlreadyInQueue(userId);
        }

        public string ElapsedTime(int customerId)
        {
            Custumer customer = _customerRepositoy.GetById(customerId);

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
        public bool CallNextCustomerInQueue(int queueId)
        {
            var newCurrentCustomer = _customerRepositoy.CallNextCustomerInQueue(queueId);
            if (newCurrentCustomer is null)
                return false;
            newCurrentCustomer.CurrentCustomerInService = true;
            _customerRepositoy.Update(newCurrentCustomer);
            return true;
        }

        /// <summary>
        /// Recupera o cliente pelo nome
        /// </summary>
        /// <param name="name">Nome do cliente.</param>
        /// <returns>Retorna a lista com os cliente que batem com a descrição.</returns>
        public IList<Custumer> GetCustomerByName(string name)
        {
            return _customerRepositoy.GetCustomerByName(name);
        }

        /// <summary>
        /// Salva os serviços selecionados pelo usuário.
        /// </summary>
        /// <param name="companyId">Id da empresa</param>
        /// <param name="custumer">Cliente que será inserido na fila</param>
        /// <param name="serviceList">Lista de serviços do cliente.</param>
        public void SaveCustumerSelectedServices(int companyId, Custumer custumer, int[] serviceList)
        {
            bool isThereQueStarted = _currentQueueRepository.IsThereQueueStarted(companyId);
            bool isCustomerAlreadyInQueue = this.IsCustomerAlreadyInQueue(custumer.Id);

            if (!isThereQueStarted)
                throw new Exception(Resources.mNoQueueWasFound);
            else if (isCustomerAlreadyInQueue) {
                throw new Exception(Resources.mCustomerAlreadyInQueue);
            }

            User user = _userRepository.GetById(custumer.UserId);
            CurrentQueue currentQueue = _currentQueueRepository.GetCurrentQueue(companyId);

            if (user is null)
            {
                throw new Exception(string.Format(Resources.mNoUserWasFoundWithId, custumer.UserId));
            }
            else if (currentQueue is null)
            {
                throw new Exception(string.Format(Resources.mNoQueueWasFound));
            }

            int position = _currentQueueRepository.GetNextPositionInQueue(companyId, currentQueue.Id);
            var customer = new Custumer(user.Id, currentQueue.Id, custumer.Comment, position);

            _customerRepositoy.Add(customer);

            foreach (int serviceId in serviceList)
            {
                ServiceType service = _serviceTypeService.GetServiceById(companyId, serviceId);

                if (service != null)
                {
                    _customerSelectedServicesRepository.Add(new CustumerXServices(service, customer));
                }
            }
        }
    }
}
