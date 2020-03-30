using System;
using System.Collections.Generic;

namespace facturacion_db.Data.Models
{
    public partial class Detalledevolucioncompra
    {
        public int IdDetalleDevolucionCompra { get; set; }
        public int? IdDevolucionCompra { get; set; }
        public int? IdProducto { get; set; }
        public decimal? Cantidad { get; set; }

        public virtual Devolucioncompra IdDevolucionCompraNavigation { get; set; }
    }
}
