using System;
using System.Collections.Generic;

namespace facturacion_db.Data.Models
{
    public partial class Roles
    {
        public Roles()
        {
            RolLista = new HashSet<RolLista>();
            Usuario = new HashSet<Usuario>();
        }

        public int IdRol { get; set; }
        public string NombreRol { get; set; }
        public int? IdEmpresa { get; set; }

        public virtual Empresa IdEmpresaNavigation { get; set; }
        public virtual ICollection<RolLista> RolLista { get; set; }
        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
