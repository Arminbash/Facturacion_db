using System;
using System.Collections.Generic;

namespace facturacion_db.Data.Models
{
    public partial class Sucursal
    {
        public Sucursal()
        {
            Bodega = new HashSet<Bodega>();
            Compra = new HashSet<Compra>();
            Factura = new HashSet<Factura>();
            Serie = new HashSet<Serie>();
            Sucursalempleado = new HashSet<Sucursalempleado>();
        }

        public int IdSucursal { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public int? IdEncargado { get; set; }
        public int? IdEmpresa { get; set; }

        public virtual Empresa IdEmpresaNavigation { get; set; }
        public virtual ICollection<Bodega> Bodega { get; set; }
        public virtual ICollection<Compra> Compra { get; set; }
        public virtual ICollection<Factura> Factura { get; set; }
        public virtual ICollection<Serie> Serie { get; set; }
        public virtual ICollection<Sucursalempleado> Sucursalempleado { get; set; }
    }
}
