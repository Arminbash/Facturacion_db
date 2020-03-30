using System;
using System.Collections.Generic;

namespace facturacion_db.Data.Models
{
    public partial class Proveedorcontacto
    {
        public int IdContacto { get; set; }
        public int? IdProveedor { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Telefono { get; set; }
        public ulong? Estado { get; set; }

        public virtual Proveedor IdProveedorNavigation { get; set; }
    }
}
