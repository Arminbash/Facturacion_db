using System;
using System.Collections.Generic;

namespace facturacion_db.Data.Models
{
    public partial class Equivalenciaproducto
    {
        public int IdEquivalencia { get; set; }
        public int? IdEquivalenciaPrimaria { get; set; }
        public int? IdEquivalenciaSecundaria { get; set; }
        public decimal? CantidadSecundaria { get; set; }
        public int? IdEquivalenciaTercera { get; set; }
        public decimal? CantidadTercera { get; set; }
        public int? IdProducto { get; set; }
        public ulong? Estado { get; set; }

        public virtual Producto IdProductoNavigation { get; set; }
    }
}
