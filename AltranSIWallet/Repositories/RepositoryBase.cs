using AltranSIWallet.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace AltranSIWallet.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected AltranSIWalletContext db { get; set; }
        public RepositoryBase(AltranSIWalletContext altranSIWalletContext)
        {
            this.db = altranSIWalletContext;
        }

        public IQueryable<T> FindAll()
        {
            return this.db.Set<T>();
        }
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.db.Set<T>().Where(expression);
        }

        public void Create(T entity)
        {
            this.db.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            this.db.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            this.db.Set<T>().Remove(entity);
        }
    }
}