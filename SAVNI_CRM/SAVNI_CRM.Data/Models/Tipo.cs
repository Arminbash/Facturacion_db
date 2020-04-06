using System;
using System.Collections.Generic;

namespace SAVNI_CRM.Data.Models
{
    public partial class Tipo
    {
        public Tipo()
        {
            Talla = new HashSet<Talla>();
        }

        public int IdTipo { get; set; }
        public string NombreTipo { get; set; }

        public virtual ICollection<Talla> Talla { get; set; }
    }
}
