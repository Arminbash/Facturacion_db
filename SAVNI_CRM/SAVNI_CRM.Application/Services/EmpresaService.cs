using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAVNI_CRM.Data.IBase;
using SAVNI_CRM.Data.Models;
using Microsoft.EntityFrameworkCore;
using SAVNI_CRM.Application.AutoMapper;

namespace SAVNI_CRM.Application.Services
{
    public class EmpresaService
    {
        private savniContext _db;
        public EmpresaService(savniContext db)
        {
            _db = db;
        }
        /// <summary>
        /// Este metodo obtiene la primera empresa.
        /// </summary>
        /// <param name="id"> Id de la empresa a retornar</param>
        /// /// <param name="idEmpresa"> IdEmpresa</param>
        /// <returns></returns>
        public Empresa ObtenerEmpresa(int idEmpresa)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(_db))
            {
                return unitOfWork.EmpresaRepository.FindBy(idEmpresa);
            }
        }

        public IEnumerable<Empresa> ObtenerTodasEmpresa()
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(_db))
            {
                return unitOfWork.EmpresaRepository.GetEntities().ToList();
            }

        }

        /// <summary>
        /// Este metodo guarda la empresa
        /// </summary>
        /// <param name="empresa">El objeto empresa con sus datos</param>
        /// <returns></returns>
        public int SaveEmpresa(Empresa empresa)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(_db))
            {
                unitOfWork.EmpresaRepository.Add(empresa);
                return unitOfWork.SaveChanges();
            }
        }
        /// <summary>
        /// Este metodo edita la empresa 
        /// </summary>
        /// <param name="empresa">Objeto con los valores a modificar</param>
        /// <returns></returns>
        public int EditEmpresa(Empresa empresa)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(_db))
            {
                var entity = unitOfWork.EmpresaRepository.FindBy(empresa.IdEmpresa);

                MapperHelper<Empresa, Empresa>.CopyTo(empresa,ref entity);

                unitOfWork.EmpresaRepository.Modified(entity);

                return unitOfWork.SaveChanges();
            }
        }

    }

}
