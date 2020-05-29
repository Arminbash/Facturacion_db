using SAVNI_CRM.Application.IServices;
using SAVNI_CRM.Data.IBase;
using SAVNI_CRM.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SAVNI_CRM.Application.Services
{
    public class ProveedorContactoService : IEntityService<Proveedorcontacto>
    {
        private savniContext _db;

        public ProveedorContactoService(savniContext db)
        {
            _db = db;
        }

        public int Delete(int id)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(_db))
            {
                var entity = unitOfWork.ProveedorContactoRepository.FindBy(id);
                entity.Estado = 0;
                unitOfWork.ProveedorContactoRepository.Modified(entity);
                return unitOfWork.SaveChanges();
            }
        }

        public int Edit(Proveedorcontacto entity)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(_db))
            {
                unitOfWork.ProveedorContactoRepository.Modified(entity);
                return unitOfWork.SaveChanges();
            }
        }

        public IEnumerable<Proveedorcontacto> GetAll(int id)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(_db))
            {
                return unitOfWork.ProveedorContactoRepository.GetEntities(filter: x => x.Estado == 1 && x.IdProveedor == id); 
            }
        }

        public IEnumerable<Proveedorcontacto> GetAll()
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(_db))
            {
                return unitOfWork.ProveedorContactoRepository.GetEntities(filter: x => x.Estado == 1);
            }
        }

        public Proveedorcontacto GetById(int Id)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(_db))
            {
                return unitOfWork.ProveedorContactoRepository.FindBy(Id);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Save(Proveedorcontacto entity)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(_db))
            {
                unitOfWork.ProveedorContactoRepository.Add(entity);
                return  unitOfWork.SaveChanges();
            }
        }
    }
}
