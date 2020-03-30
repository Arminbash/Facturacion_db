using System;
using System.Collections.Generic;

namespace facturacion_db.Data.Models
{
    public partial class Detallepagofactura
    {
        public int IdDetallePagoFactura { get; set; }
        public int? IdFactura { get; set; }
        public string TipoPago { get; set; }
        public decimal? Monto { get; set; }
        public string Moneda { get; set; }

        public virtual Factura IdFacturaNavigation { get; set; }
    }
}
