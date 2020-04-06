using System;
using System.Collections.Generic;

namespace SAVNI_CRM.Data.Models
{
    public partial class Listaaccesos
    {
        public Listaaccesos()
        {
            RolLista = new HashSet<RolLista>();
        }

        public int IdListaAcceso { get; set; }
        public string NombreVista { get; set; }

        public virtual ICollection<RolLista> RolLista { get; set; }
    }
}
