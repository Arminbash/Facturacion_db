using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SAVNI_CRM.API.ViewModel
{
    public class ClienteViewModel
    {
        public int IdCliente { get; set; }
        public string CodigoCliente { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string CedulaRuc { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public ulong? Estado { get; set; }
        public int? IdEmpresa { get; set; }
    }
}
