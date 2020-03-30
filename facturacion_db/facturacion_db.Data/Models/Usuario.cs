using System;
using System.Collections.Generic;

namespace facturacion_db.Data.Models
{
    public partial class Usuario
    {
        public int IdUsuario { get; set; }
        public int? IdEmpleado { get; set; }
        public string NombreUsuario { get; set; }
        public string Contrasenia { get; set; }
        public ulong? Estado { get; set; }
        public int? IdRol { get; set; }

        public virtual Empleado IdEmpleadoNavigation { get; set; }
        public virtual Roles IdRolNavigation { get; set; }
    }
}
