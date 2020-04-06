using System;
using System.Collections.Generic;

namespace SAVNI_CRM.Data.Models
{
    public partial class Factura
    {
        public Factura()
        {
            Detallefactura = new HashSet<Detallefactura>();
            Detallepagofactura = new HashSet<Detallepagofactura>();
            Devolucionfactura = new HashSet<Devolucionfactura>();
        }

        public int IdFactura { get; set; }
        public string Consecutivo { get; set; }
        public DateTime? Fecha { get; set; }
        public string Moneda { get; set; }
        public int? IdCliente { get; set; }
        public string TipoPago { get; set; }
        public int? IdVendedor { get; set; }
        public int? IdSerie { get; set; }
        public int? IdSucursal { get; set; }
        public ulong? Estado { get; set; }
        public string SerieConsecutivo { get; set; }

        public virtual Sucursal IdSucursalNavigation { get; set; }
        public virtual ICollection<Detallefactura> Detallefactura { get; set; }
        public virtual ICollection<Detallepagofactura> Detallepagofactura { get; set; }
        public virtual ICollection<Devolucionfactura> Devolucionfactura { get; set; }
    }
}
