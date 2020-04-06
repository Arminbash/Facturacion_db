using System;
using System.Collections.Generic;
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
        IEnumerable<T> GetEntities();
        IEnumerable<T> GetRequestQuery();
    }
}
