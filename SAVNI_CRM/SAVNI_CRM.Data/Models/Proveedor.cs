using System;
using System.Collections.Generic;

namespace SAVNI_CRM.Data.Models
{
    public partial class Proveedor
    {
        public Proveedor()
        {
            Proveedorcontacto = new HashSet<Proveedorcontacto>();
        }

        public int IdProveedor { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string TipoProducto { get; set; }
        public string Direccion { get; set; }
        public int? IdEmpresa { get; set; }
        public ulong? Estado { get; set; }

        public virtual Empresa IdEmpresaNavigation { get; set; }
        public virtual ICollection<Proveedorcontacto> Proveedorcontacto { get; set; }
    }
}
