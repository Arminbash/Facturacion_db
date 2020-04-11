using SAVNI_CRM.Application.AutoMapper;
using SAVNI_CRM.Application.IServices;
using SAVNI_CRM.Data.IBase;
using SAVNI_CRM.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SAVNI_CRM.Application.Services
{
    public class ClienteService : IEntityService<Cliente>
    {

        private savniContext _db;

        public ClienteService(savniContext db)
        {
            _db = db;
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Edita los datos del cliente
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Edit(Cliente entity)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(_db))
            {
                var data = unitOfWork.ClienteRepository.FindBy(entity.IdCliente);

                MapperHelper<Cliente, Cliente>.CopyTo(entity, ref data);

                unitOfWork.ClienteRepository.Modified(data);

                return unitOfWork.SaveChanges();
            }
        }
        /// <summary>
        /// Obtiene todos los clientes activos
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Cliente> GetAll()
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(_db))
            {
                return unitOfWork.ClienteRepository.GetEntities(filter: x => x.Estado == 1);
            }
        }
        /// <summary>
        /// Obtiene el clientes por su Id
        /// </summary>
        /// <param name="Id">IdCliente</param>
        /// <returns></returns>
        public Cliente GetById(int Id)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(_db))
            {
                return unitOfWork.ClienteRepository.FindBy(Id);
            }
        }
        /// <summary>
        /// Guarda el nuevo cliente
        /// </summary>
        /// <param name="entity">Cliente</param>
        /// <returns></returns>
            public int Save(Cliente entity)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(_db))
            {
                unitOfWork.ClienteRepository.Add(entity);
                return unitOfWork.SaveChanges();
            }
        }
    }
}
