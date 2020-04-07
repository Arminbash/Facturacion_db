using System.Collections.Generic;

namespace SAVNI_CRM.Application.IServices
{
    public interface IEntityService<TEntity> where TEntity : class
    {
        TEntity GetById(int Id);
        IEnumerable<TEntity> GetAll();
        int Save(TEntity entity);
        int Edit(TEntity entity);
        int Delete(int id);
    }
}
