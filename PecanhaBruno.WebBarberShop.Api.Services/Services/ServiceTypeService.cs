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

        private IWebBarberShoppContext _context { get; }
        private IServiceTypeRepository _serviceRepository { get; }

        public ServiceTypeService(IServiceTypeRepository repository, IWebBarberShoppContext context)
            : base(repository) {
            _serviceRepository = repository;
            _context = context;
        }

        public ICollection<ServiceType> GetAllServicesType(int companyId, int page, int qtd) {
            int skip = (page - 1) * qtd;

            return _context.ServiceType
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
            _serviceRepository.Update(serviceType);
        }

        public void TryHardDelete(int id) {

            bool wasServiceUsed = _context.CustumerSelectedServices
                                                .Include(x => x.Service)
                                                .Any(x => x.ServiceId == id);

            var service = _serviceRepository.GetById(id);
            if (wasServiceUsed) {
                service.UpdataServiceStatus(false);
                _serviceRepository.Update(service);
            } else {
                _serviceRepository.Remove(service);
            }
        }

        public ServiceType GetServiceById(int id) {
            ServiceType service = _context.ServiceType
                           .AsNoTracking()
                           .FirstOrDefault(x => x.Id == id && x.Activated);
            if (service is null)
                throw new Exception(Resources.mNoServiceWasFound);
            return service;
        }

        public void CreateNewService(ServiceType serviceDto) {
            _serviceRepository.Add(serviceDto);
        }

        public ICollection<ServiceType> GetServicesByCustomer(int customerId)
        {
            return _context.CustumerSelectedServices
                           .Include(x => x.Custumer)
                           .AsNoTracking()
                           .Where(x => x.Custumer.Id == customerId)
                           .Select(x => x.Service)
                           .ToList();                           
        }       
    }
}
