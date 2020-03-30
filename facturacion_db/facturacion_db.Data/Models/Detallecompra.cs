using System;
using System.Collections.Generic;

namespace facturacion_db.Data.Models
{
    public partial class Detallecompra
    {
        public int IdDetalleCompra { get; set; }
        public int? IdCompra { get; set; }
        public int? IdProducto { get; set; }
        public int? IdUnidadMedida { get; set; }
        public decimal? Cantidad { get; set; }
        public decimal? Costo { get; set; }
        public decimal? Importe { get; set; }
        public decimal? Descuento { get; set; }

        public virtual Compra IdCompraNavigation { get; set; }
        public virtual Producto IdProductoNavigation { get; set; }
    }
}
