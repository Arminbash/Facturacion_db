using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SAVNI_CRM.API.ViewModel
{
    public class SucursalViewModel
    {
        public int IdSucursal { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public int? IdEncargado { get; set; }
        public int? IdEmpresa { get; set; }
    }
}
