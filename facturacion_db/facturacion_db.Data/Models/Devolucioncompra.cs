using System;
using System.Collections.Generic;

namespace facturacion_db.Data.Models
{
    public partial class Devolucioncompra
    {
        public Devolucioncompra()
        {
            Detalledevolucioncompra = new HashSet<Detalledevolucioncompra>();
        }

        public int IdDevolucionCompra { get; set; }
        public string Consecutivo { get; set; }
        public int? IdCompra { get; set; }
        public string Motivo { get; set; }
        public DateTime? Fecha { get; set; }
        public int? IdSerie { get; set; }
        public string SerieConsecutivo { get; set; }
        public string Tipo { get; set; }

        public virtual Compra IdCompraNavigation { get; set; }
        public virtual ICollection<Detalledevolucioncompra> Detalledevolucioncompra { get; set; }
    }
}
