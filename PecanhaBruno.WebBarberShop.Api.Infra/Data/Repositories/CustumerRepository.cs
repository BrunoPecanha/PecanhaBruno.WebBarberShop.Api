using Microsoft.EntityFrameworkCore;
using PecanhaBruno.WebBarberShop.Domain.Entities;
using PecanhaBruno.WebBarberShop.Domain.Interface.Repository;
using PecanhaBruno.WebBarberShop.Infra.Context;
using System.Collections.Generic;
using System.Linq;

namespace PecanhaBruno.WebBarberShop.Infra.Data.Repositories {
    public class CustumerRepository : RepositoryBase<Custumer>, ICustumerRepository {
        private IWebBarberShoppContext _dbContext { get; }

        public CustumerRepository(IWebBarberShoppContext context) {
            _dbContext = context;
        }

        /// <summary>
        /// Verifica se um cliente já está inserido numa fila.
        /// </summary>
        /// <param name="userId">Id do usuário.</param>
        /// <returns></returns>
        // TODO - MELHORAR A BUSCA COM O ID COMPANY
        public bool IsCustomerAlreadyInQueue(int userId) {
            return _dbContext.Custumer
                             .Any(x => x.UserId == userId && !x.IsServiceDone);
        }

        /// <summary>
        /// Recupera o atual cliente em atendimento
        /// </summary>
        /// <param name="companyId">Id da empresa para localizar a fila.</param>
        /// <returns></returns>
        public Custumer CallNextCustomerInQueue(int queueId) {
            return _dbContext.Custumer
                             .OrderBy(x => x.QueuePosition)
                             .FirstOrDefault(x => x.QueueId == queueId && !x.IsServiceDone);
        }

        /// <summary>
        /// Recupera os cliente que batem com a string passada 
        /// </summary>
        /// <param name="name">Parte do nome ou nome do usuário procurado.</param>
        /// <returns>Lista com todos os usuários que batem com a pesquisa.</returns>
        public IList<Custumer> GetCustomerByName(string name) {
            return _dbContext.Custumer
                             .Include(x => x.User)
                             .Where(x => x.User.Name.Contains(name))
                             .GroupBy(x => x.User)
                             .Select(x => x.First())
                             .ToArray();
        }
    }
}

