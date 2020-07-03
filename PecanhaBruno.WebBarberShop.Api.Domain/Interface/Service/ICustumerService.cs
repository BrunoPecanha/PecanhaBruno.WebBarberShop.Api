﻿using PecanhaBruno.WebBarberShop.Domain.Entities;
using System.Collections.Generic;

namespace PecanhaBruno.WebBarberShop.Domain.Interface.Service {
    public interface ICustumerService : IServiceBase<Custumer> {
        Custumer AddWithReturn(Custumer customer);
        List<CustumerXServices> GetAllSelectedCustomerServices(int customerId);      
        void EndAllCustomerServicesInQueue(int companyId);
        bool IsCustomerAlreadyInQueue(int userId);
        string ElapsedTime(int customerId);
        bool CallNextCustomerInQueue(int queueId);
        IList<Custumer> GetCustomerByName(string name);
        void SaveCustumerSelectedServices(int companyId, Custumer custumer, int[] serviceList);
        void DeleteFromQueue(int customerId);
        void UpdateCustomer(int companyId, int customerId, int[] serviceList, string comment);
        void EndCustomerService(int customerId, int companyId);
    }
}
