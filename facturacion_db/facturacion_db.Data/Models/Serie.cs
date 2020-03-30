using System;
using System.Collections.Generic;

namespace facturacion_db.Data.Models
{
    public partial class Serie
    {
        public int IdSerie { get; set; }
        public string Prefijo { get; set; }
        public int? NumConsecutivo { get; set; }
        public string NombreDocumento { get; set; }
        public int? IdSucursal { get; set; }

        public virtual Sucursal IdSucursalNavigation { get; set; }
    }
}
