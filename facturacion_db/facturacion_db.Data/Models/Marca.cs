using System;
using System.Collections.Generic;

namespace facturacion_db.Data.Models
{
    public partial class Marca
    {
        public Marca()
        {
            Producto = new HashSet<Producto>();
        }

        public int IdMarca { get; set; }
        public string Nombre { get; set; }
        public int? IdEmpresa { get; set; }

        public virtual ICollection<Producto> Producto { get; set; }
    }
}
