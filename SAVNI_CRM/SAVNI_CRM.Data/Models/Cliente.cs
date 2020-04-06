using System;
using System.Collections.Generic;

namespace SAVNI_CRM.Data.Models
{
    public partial class Cliente
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

        public virtual Empresa IdEmpresaNavigation { get; set; }
    }
}
