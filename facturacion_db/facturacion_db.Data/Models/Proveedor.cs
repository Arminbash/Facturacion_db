using System;
using System.Collections.Generic;

namespace facturacion_db.Data.Models
{
    public partial class Proveedor
    {
        public Proveedor()
        {
            Proveedorcontacto = new HashSet<Proveedorcontacto>();
        }

        public int IdProveedor { get; set; }
        public string Consecutivo { get; set; }
        public string Nombre { get; set; }
        public string TipoProducto { get; set; }
        public string Direccion { get; set; }
        public int? IdSerie { get; set; }
        public int? IdEmpresa { get; set; }
        public string SerieConsecutivo { get; set; }
        public ulong? Estado { get; set; }

        public virtual Empresa IdEmpresaNavigation { get; set; }
        public virtual ICollection<Proveedorcontacto> Proveedorcontacto { get; set; }
    }
}
