using SAVNI_CRM.Application.AutoMapper;
using SAVNI_CRM.Application.IServices;
using SAVNI_CRM.Data.IBase;
using SAVNI_CRM.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SAVNI_CRM.Application.Services
{
    public class SucursalService : IEntityService<Sucursal>
    {

        private savniContext _db;

        public SucursalService(savniContext db)
        {
            _db = db;
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Edita los datos de la Sucursal
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Edit(Sucursal entity)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(_db))
            {
                var data = unitOfWork.SucursalRepository.FindBy(entity.IdEmpresa);

                MapperHelper<Sucursal, Sucursal>.CopyTo(entity, ref data);

                unitOfWork.SucursalRepository.Modified(data);

                return unitOfWork.SaveChanges();
            }
        }
        /// <summary>
        /// Obtiene todas las sucursales
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Sucursal> GetAll()
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(_db))
            {
                return unitOfWork.SucursalRepository.GetEntities();
            }
        }
        /// <summary>
        /// Obtiene los datos de la Sucursal por su Id
        /// </summary>
        /// <param name="Id">IdSucursal</param>
        /// <returns></returns>
        public Sucursal GetById(int Id)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(_db))
            {
                return unitOfWork.SucursalRepository.FindBy(Id);
            }
        }
        /// <summary>
        /// Guarda la nueva Sucursal
        /// </summary>
        /// <param name="entity">Sucursal</param>
        /// <returns></returns>
        public int Save(Sucursal entity)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(_db))
            {
                unitOfWork.SucursalRepository.Add(entity);
                return unitOfWork.SaveChanges();
            }
        }
    }
}
