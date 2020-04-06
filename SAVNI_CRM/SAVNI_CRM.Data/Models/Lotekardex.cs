using System;
using System.Collections.Generic;

namespace SAVNI_CRM.Data.Models
{
    public partial class Lotekardex
    {
        public int IdLoteKardex { get; set; }
        public int? IdKardex { get; set; }
        public int? IdLote { get; set; }
        public decimal? Cantidad { get; set; }

        public virtual Kardex IdKardexNavigation { get; set; }
        public virtual Lote IdLoteNavigation { get; set; }
    }
}
