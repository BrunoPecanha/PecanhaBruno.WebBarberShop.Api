using Microsoft.EntityFrameworkCore;
using Pecanha.WebBaberShopp.Infra.Context;
using PecanhaBruno.WebBarberShop.Domain.Interface.Repository;
using System.Collections.Generic;
using System.Linq;

namespace PecanhaBruno.WebBarberShop.Infra.Data.Repositories {
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class {

        // Cria uma instância de acesso ao BD.
        protected WebBarberShoppContext Db = new WebBarberShoppContext(new DbContextOptions<WebBarberShoppContext>());

        public void Add(TEntity obj) {

            Db.Set<TEntity>().Add(obj);
            Db.SaveChanges();
        }

        public void Dispose() {
            Db.Dispose();
        }

        public IList<TEntity> GetAll() {
            return Db.Set<TEntity>().ToList();
        }

        public TEntity GetById(int id) {
            return Db.Set<TEntity>().Find(id) ;
        }

        public void Remove(TEntity obj) {
            Db.Set<TEntity>().Remove(obj);
            Db.SaveChanges();
        }

        public void Update(TEntity obj) {
            Db.Entry(obj).State = EntityState.Modified;
            Db.SaveChanges();
        }
    }
}
