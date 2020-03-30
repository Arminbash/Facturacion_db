using System;
using System.Collections.Generic;

namespace facturacion_db.Data.Models
{
    public partial class Bitacora
    {
        public int IdBitacora { get; set; }
        public string Accion { get; set; }
        public DateTime? HoraFecha { get; set; }
        public int? IdEmpleado { get; set; }
        public string TablaAfectada { get; set; }
        public int? IdRegistoAfectado { get; set; }
        public int? IdSucursal { get; set; }
    }
}
