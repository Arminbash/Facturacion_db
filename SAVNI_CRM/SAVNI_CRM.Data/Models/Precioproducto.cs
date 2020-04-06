using System;
using System.Collections.Generic;

namespace SAVNI_CRM.Data.Models
{
    public partial class Precioproducto
    {
        public int IdPrecioProducto { get; set; }
        public string Moneda { get; set; }
        public DateTime? Fecha { get; set; }
        public string TipoValor { get; set; }
        public decimal? PrecioMaximo { get; set; }
        public decimal? PrecioMinimo { get; set; }
        public int? IdProducto { get; set; }

        public virtual Producto IdProductoNavigation { get; set; }
    }
}
