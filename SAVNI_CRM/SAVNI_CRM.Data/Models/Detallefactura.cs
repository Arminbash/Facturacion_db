using System;
using System.Collections.Generic;

namespace SAVNI_CRM.Data.Models
{
    public partial class Detallefactura
    {
        public int IdDetalleFactura { get; set; }
        public int? IdProducto { get; set; }
        public decimal? Cantidad { get; set; }
        public decimal? Costo { get; set; }
        public decimal? Precio { get; set; }
        public decimal? Descuento { get; set; }
        public decimal? Impuesto { get; set; }
        public int? IdFactura { get; set; }

        public virtual Factura IdFacturaNavigation { get; set; }
        public virtual Producto IdProductoNavigation { get; set; }
    }
}
