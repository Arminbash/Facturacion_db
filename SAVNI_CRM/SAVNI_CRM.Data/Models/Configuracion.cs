using System;
using System.Collections.Generic;

namespace SAVNI_CRM.Data.Models
{
    public partial class Configuracion
    {
        public int IdConfiguracion { get; set; }
        public int? IdEmpresa { get; set; }
        public string MonedaPrincipal { get; set; }

        public virtual Empresa IdEmpresaNavigation { get; set; }
    }
}
