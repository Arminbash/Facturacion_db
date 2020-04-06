using System;
using System.Collections.Generic;

namespace SAVNI_CRM.Data.Models
{
    public partial class Producto
    {
        public Producto()
        {
            Detallecompra = new HashSet<Detallecompra>();
            Detallefactura = new HashSet<Detallefactura>();
            Equivalenciaproducto = new HashSet<Equivalenciaproducto>();
            Precioproducto = new HashSet<Precioproducto>();
        }

        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int? IdMarca { get; set; }
        public int? IdUnidadMedida { get; set; }
        public decimal? Iva { get; set; }
        public ulong? Estado { get; set; }
        public ulong? TrabajaLote { get; set; }

        public virtual Marca IdMarcaNavigation { get; set; }
        public virtual ICollection<Detallecompra> Detallecompra { get; set; }
        public virtual ICollection<Detallefactura> Detallefactura { get; set; }
        public virtual ICollection<Equivalenciaproducto> Equivalenciaproducto { get; set; }
        public virtual ICollection<Precioproducto> Precioproducto { get; set; }
    }
}
