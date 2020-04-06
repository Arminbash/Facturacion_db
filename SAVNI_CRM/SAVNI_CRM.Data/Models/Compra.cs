using System;
using System.Collections.Generic;

namespace SAVNI_CRM.Data.Models
{
    public partial class Compra
    {
        public Compra()
        {
            Detallecompra = new HashSet<Detallecompra>();
            Devolucioncompra = new HashSet<Devolucioncompra>();
        }

        public int IdCompra { get; set; }
        public string Consecutivo { get; set; }
        public string NumFactura { get; set; }
        public DateTime? FechaCompra { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public decimal? Tasa { get; set; }
        public string Moneda { get; set; }
        public int? IdProveedor { get; set; }
        public int? IdSerie { get; set; }
        public string SerieConsecutivo { get; set; }
        public ulong? Estado { get; set; }
        public int? IdSucursal { get; set; }
        public int? IdBodega { get; set; }

        public virtual Sucursal IdSucursalNavigation { get; set; }
        public virtual ICollection<Detallecompra> Detallecompra { get; set; }
        public virtual ICollection<Devolucioncompra> Devolucioncompra { get; set; }
    }
}
