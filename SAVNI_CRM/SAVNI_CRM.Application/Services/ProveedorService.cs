using System.Collections.Generic;
using SAVNI_CRM.Application.AutoMapper;
using SAVNI_CRM.Application.IServices;
using SAVNI_CRM.Data.IBase;
using SAVNI_CRM.Data.Models;

namespace SAVNI_CRM.Application.Services
{
    public class ProveedorService: IEntityService<Proveedor>
    {
        private savniContext _db;

        public ProveedorService(savniContext db)
        {
            _db = db;
        }
        /// <summary>
        /// Obtiene al proveedor por su Id
        /// </summary>
        /// <param name="Id">Id del Cliente</param>
        /// <returns></returns>
        public Proveedor GetById(int Id)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(_db))
            {
                return unitOfWork.ProveedorRepository.FindBy(Id);
            }
        }
        /// <summary>
        /// Obtiene todos los proveedores activos
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Proveedor> GetAll()
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(_db))
            {
                return unitOfWork.ProveedorRepository.GetEntities(filter: x => x.Estado == 1);
            }
        }

        /// <summary>
        /// Guarda el objeto de tipo proveedor
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Save(Proveedor entity)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(_db))
            {
                unitOfWork.ProveedorRepository.Add(entity);
                return unitOfWork.SaveChanges();
            }
        }

        /// <summary>
        /// Edita el objeto de tipo proveedor
        /// </summary>
        /// <param name="entity">Objeto proveedor</param>
        /// <returns></returns>
        public int Edit(Proveedor entity)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(_db))
            {
                var data = unitOfWork.ProveedorRepository.FindBy(entity.IdProveedor);

                MapperHelper<Proveedor, Proveedor>.CopyTo(entity, ref data);

                unitOfWork.ProveedorRepository.Modified(data);

                return unitOfWork.SaveChanges();
            }
        }

        public int Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}