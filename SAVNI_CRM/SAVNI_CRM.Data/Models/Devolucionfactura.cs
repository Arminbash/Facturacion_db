using System;
using System.Collections.Generic;

namespace SAVNI_CRM.Data.Models
{
    public partial class Devolucionfactura
    {
        public int IdDevolucionFactura { get; set; }
        public int? IdFactura { get; set; }
        public string Consecutivo { get; set; }
        public string Tipo { get; set; }
        public string Motivo { get; set; }
        public DateTime? Fecha { get; set; }
        public int? IdSerie { get; set; }
        public string SerieConsecutivo { get; set; }

        public virtual Factura IdFacturaNavigation { get; set; }
        public virtual Detalledevolucionfactura Detalledevolucionfactura { get; set; }
    }
}
