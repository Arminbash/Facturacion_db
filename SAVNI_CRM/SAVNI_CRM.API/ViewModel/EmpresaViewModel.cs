using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SAVNI_CRM.API.ViewModel
{
    public class EmpresaViewModel
    {
        public int IdEmpresa { get; set; }
        public string Nombre { get; set; }
        public string Ruc { get; set; }
        public string Direccion { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
    }
}
