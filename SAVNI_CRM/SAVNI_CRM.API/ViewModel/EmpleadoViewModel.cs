using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SAVNI_CRM.API.ViewModel
{
    public class EmpleadoViewModel
    {
        public int IdEmpleado { get; set; }
        public string Codigo { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Cedula { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public ulong? Estado { get; set; }
        public int IdSucursal { get; set; }
    }
}
