using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace SAVNI_CRM.Data.IRepository
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

        public IEnumerable<T> GetEntities(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<T> query = _dbset;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public IEnumerable<T> GetRequestQuery()
        {
            throw new NotImplementedException();
        }

        public void Modified(T entity)
        {
            _dbset.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
        #endregion
    }

}
