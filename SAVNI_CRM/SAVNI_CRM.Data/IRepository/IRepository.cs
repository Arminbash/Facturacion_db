using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace SAVNI_CRM.Data.IRepository
{
    public interface IRepository<T> where T : class
    {
        // void AddOrUpdateEntity(T entity);
        void Add(T entity);
        void Modified(T entity);
        void DeleteEntity(int? id);
        T FindBy(int? id);
        IEnumerable<T> GetEntities( Expression<Func<T, bool>> filter = null,
                                    Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                    string includeProperties = "");
        IEnumerable<T> GetRequestQuery();
    }
}
