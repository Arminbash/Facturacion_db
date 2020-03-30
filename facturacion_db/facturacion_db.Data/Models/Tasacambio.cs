using System;
using System.Collections.Generic;

namespace facturacion_db.Data.Models
{
    public partial class Tasacambio
    {
        public int IdTasaCambio { get; set; }
        public DateTime? FechaTasa { get; set; }
        public string Moneda { get; set; }
        public decimal? Monto { get; set; }
    }
}
