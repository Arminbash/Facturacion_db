using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAVNI_CRM.Data.IBase;
using SAVNI_CRM.Data.Models;
using Microsoft.EntityFrameworkCore;
using SAVNI_CRM.Application.AutoMapper;
using SAVNI_CRM.Application.IServices;

namespace SAVNI_CRM.Application.Services
{
    public class EmpresaService : IEntityService<Empresa>
    {
        private savniContext _db;
        public EmpresaService(savniContext db)
        {
            _db = db;
        }
        /// <summary>
        /// Este metodo obtiene la primera empresa.
        /// </summary>
        /// <param name="Id"> Id de la empresa a retornar</param>
        /// <returns></returns>
        public Empresa GetById(int Id)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(_db))
            {
                return unitOfWork.EmpresaRepository.FindBy(Id);
            }
        }

        /// <summary>
        /// Obtener todas las empresas
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Empresa> GetAll()
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(_db))
            {
                return unitOfWork.EmpresaRepository.GetEntities().ToList();
            }
        }

        /// <summary>
        /// Guardar una empresa nueva
        /// </summary>
        /// <param name="entity">Empresa a guardar</param>
        /// <returns></returns>
        public int Save(Empresa entity)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(_db))
            {
                unitOfWork.EmpresaRepository.Add(entity);
                return unitOfWork.SaveChanges();
            }
        }

        /// <summary>
        /// Este metodo edita la empresa 
        /// </summary>
        /// <param name="entity">Objeto con los valores a modificar</param>
        /// <returns></returns>
        public int Edit(Empresa entity)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(_db))
            {
                var data = unitOfWork.EmpresaRepository.FindBy(entity.IdEmpresa);

                MapperHelper<Empresa, Empresa>.CopyTo(entity, ref data);

                unitOfWork.EmpresaRepository.Modified(data);

                return unitOfWork.SaveChanges();
            }
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }
    }

}
