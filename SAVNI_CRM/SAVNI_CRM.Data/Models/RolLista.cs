using System;
using System.Collections.Generic;

namespace SAVNI_CRM.Data.Models
{
    public partial class RolLista
    {
        public int IdRolLista { get; set; }
        public int? IdAcceso { get; set; }
        public int? IdRol { get; set; }
        public ulong? Estado { get; set; }

        public virtual Listaaccesos IdAccesoNavigation { get; set; }
        public virtual Roles IdRolNavigation { get; set; }
    }
}
