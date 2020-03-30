using System;
using System.Collections.Generic;

namespace facturacion_db.Data.Models
{
    public partial class Detalledevolucionfactura
    {
        public int IdDetalleDevolucion { get; set; }
        public int? IdDevolucionFactura { get; set; }
        public int? IdProducto { get; set; }
        public decimal? Cantidad { get; set; }

        public virtual Devolucionfactura IdDetalleDevolucionNavigation { get; set; }
    }
}
