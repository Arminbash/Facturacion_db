using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using facturacion_db.Data.IBase;
using facturacion_db.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace facturacion_db.Application.Services
{
    public class EmpresaService
    {
        private facturaciondb _db;
        public EmpresaService(facturaciondb db)
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
            using(UnitOfWork unitOfWork = new UnitOfWork(_db))
            {
                return unitOfWork.EmpresaRepository.FindBy(idEmpresa);
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
    }
}
