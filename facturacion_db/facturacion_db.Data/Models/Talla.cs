using System;
using System.Collections.Generic;

namespace facturacion_db.Data.Models
{
    public partial class Talla
    {
        public Talla()
        {
            Lote = new HashSet<Lote>();
        }

        public int IdTalla { get; set; }
        public int? IdTipo { get; set; }
        public string Tamanio { get; set; }

        public virtual Tipo IdTipoNavigation { get; set; }
        public virtual ICollection<Lote> Lote { get; set; }
    }
}
