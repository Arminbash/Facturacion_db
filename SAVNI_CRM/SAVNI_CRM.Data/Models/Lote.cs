using System;
using System.Collections.Generic;

namespace SAVNI_CRM.Data.Models
{
    public partial class Lote
    {
        public Lote()
        {
            Lotekardex = new HashSet<Lotekardex>();
        }

        public int IdLote { get; set; }
        public int? IdProducto { get; set; }
        public int? IdTalla { get; set; }

        public virtual Talla IdTallaNavigation { get; set; }
        public virtual ICollection<Lotekardex> Lotekardex { get; set; }
    }
}
