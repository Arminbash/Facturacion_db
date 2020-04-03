using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace facturacion_db.Data.IRepository
{
    public partial class Repository<T> : IRepository<T> where T : class
    {
        #region("Variables Globales")
        internal DbContext _context;
        internal DbSet<T> _dbset;
        #endregion
        #region("Constructor")
        public Repository(DbContext dbContext)
        {
            _context = dbContext;
            _dbset = dbContext.Set<T>();
        }
        #endregion
        #region("Implementacion Interfaz")
        public void Add(T entity)
        {
            _dbset.Add(entity);
        }

        public void DeleteEntity(int? id)
        {
            var entity = _dbset.Find(id);
            _dbset.Remove(entity);
        }

        public T FindBy(int? id)
        {
            return _dbset.Find(id);
        }

        public IEnumerable<T> GetEntities()
        {
            return _dbset;
        }

        public IEnumerable<T> GetRequestQuery()
        {
            throw new NotImplementedException();
        }

        public void Modified(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
        #endregion
    }
}
