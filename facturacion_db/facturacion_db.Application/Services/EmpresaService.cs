using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using facturacion_db.Data.Models;
namespace facturacion_db.Application.Services
{
    public class EmpresaService
    {
        public Empresa getEmpresas()
        {
            facturaciondb db = new facturaciondb();
            return db.Empresa.FirstOrDefault();
        }
    }
}
