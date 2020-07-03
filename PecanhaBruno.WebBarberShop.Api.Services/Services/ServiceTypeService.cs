using Microsoft.EntityFrameworkCore;
using PecanhaBruno.WebBarberShop.Domain.Entities;
using PecanhaBruno.WebBarberShop.Domain.Interface.Repository;
using PecanhaBruno.WebBarberShop.Domain.Interface.Service;
using PecanhaBruno.WebBarberShop.Infra.Context;
using PecanhaBruno.WebBarberShop.Service.Properties;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PecanhaBruno.WebBarberShop.Service.Services {
    public class ServiceTypeService : ServiceBase<ServiceType>, IServiceTypeService
    {

        private IWebBarberShoppContext _Context { get; }
        private IServiceTypeRepository _ServiceRepository { get; }

        public ServiceTypeService(IServiceTypeRepository repository, IWebBarberShoppContext context)
            : base(repository) {
            _ServiceRepository = repository;
            _Context = context;
        }

        public ICollection<ServiceType> GetAllServicesType(int companyId, int page, int qtd) {
            int skip = (page - 1) * qtd;

            return _Context.ServiceType
                              .Where(x => x.CompanyId == companyId && x.Activated)
                              .AsNoTracking()
                              .Where(x => x.Activated)
                              .Skip(skip)
                              .Take(qtd)
                              .ToArray();
        }

        public void UpdateService(ServiceType serviceType) {
            if (serviceType is null) {
                throw new Exception(Resources.mNoServiceWasFound);
            }

            serviceType.Validate();
            _ServiceRepository.Update(serviceType);
        }

        public void TryHardDelete(int id) {

            bool wasServiceUsed = _Context.CustumerSelectedServices
                                                .Include(x => x.Service)
                                                .Any(x => x.ServiceId == id);

            var service = _ServiceRepository.GetById(id);
            if (wasServiceUsed) {
                service.UpdataServiceStatus(false);
                _ServiceRepository.Update(service);
            } else {
                _ServiceRepository.Remove(service);
            }
        }

        public ServiceType GetServiceById(int companyId, int id) {
            return _Context.ServiceType
                           .AsNoTracking()
                           .FirstOrDefault(x => x.CompanyId == companyId && x.Id == id && x.Activated);
        }

        public void CreateNewService(ServiceType serviceDto) {
            _ServiceRepository.Add(serviceDto);
        }

        public ICollection<ServiceType> GetServicesByCustomer(int customerId)
        {
            return _Context.CustumerSelectedServices
                           .Include(x => x.Custumer)
                           .AsNoTracking()
                           .Where(x => x.Custumer.Id == customerId)
                           .Select(x => x.Service)
                           .ToList();                           
        }       
    }
}
