using System;
using System.Collections.Generic;

namespace SAVNI_CRM.Data.Models
{
    public partial class Bodega
    {
        public int IdBodega { get; set; }
        public string CodigoBodega { get; set; }
        public string NombreBodega { get; set; }
        public int? IdSucursal { get; set; }

        public virtual Sucursal IdSucursalNavigation { get; set; }
    }
}
