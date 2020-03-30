using System;
using System.Collections.Generic;

namespace facturacion_db.Data.Models
{
    public partial class Sucursalempleado
    {
        public int IdSucursalempleado { get; set; }
        public int? IdEmpleado { get; set; }
        public int? IdSucursal { get; set; }
        public ulong? Estado { get; set; }

        public virtual Empleado IdEmpleadoNavigation { get; set; }
        public virtual Sucursal IdSucursalNavigation { get; set; }
    }
}
