using System;
using System.Collections.Generic;

namespace facturacion_db.Data.Models
{
    public partial class Empresa
    {
        public Empresa()
        {
            Cliente = new HashSet<Cliente>();
            Configuracion = new HashSet<Configuracion>();
            Empleado = new HashSet<Empleado>();
            Proveedor = new HashSet<Proveedor>();
            Roles = new HashSet<Roles>();
            Sucursal = new HashSet<Sucursal>();
        }

        public int IdEmpresa { get; set; }
        public string Nombre { get; set; }
        public string Ruc { get; set; }
        public string Direccion { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }

        public virtual ICollection<Cliente> Cliente { get; set; }
        public virtual ICollection<Configuracion> Configuracion { get; set; }
        public virtual ICollection<Empleado> Empleado { get; set; }
        public virtual ICollection<Proveedor> Proveedor { get; set; }
        public virtual ICollection<Roles> Roles { get; set; }
        public virtual ICollection<Sucursal> Sucursal { get; set; }
    }
}
