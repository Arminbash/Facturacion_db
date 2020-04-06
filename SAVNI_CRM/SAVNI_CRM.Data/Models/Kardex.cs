using System;
using System.Collections.Generic;

namespace SAVNI_CRM.Data.Models
{
    public partial class Kardex
    {
        public Kardex()
        {
            Lotekardex = new HashSet<Lotekardex>();
        }

        public int IdKardex { get; set; }
        public int? IdProducto { get; set; }
        public decimal? CantidadEntrada { get; set; }
        public decimal? CantidadSalida { get; set; }
        public decimal? CantidadDisponible { get; set; }
        public int? IdMovimiento { get; set; }
        public string Movimiento { get; set; }
        public int? IdUnidadMedida { get; set; }
        public decimal? CostoPonderado { get; set; }
        public decimal? CostoSimple { get; set; }
        public int? IdBodega { get; set; }

        public virtual ICollection<Lotekardex> Lotekardex { get; set; }
    }
}
