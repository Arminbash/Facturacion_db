using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SAVNI_CRM.API.ViewModel
{
    public class ProveedorContactoViewModel
    {
        public int IdContacto { get; set; }
        public int? IdProveedor { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Telefono { get; set; }
        public ulong? Estado { get; set; }

    }
}
