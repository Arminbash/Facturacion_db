﻿using System;
using System.Collections.Generic;

namespace facturacion_db.Data.Models
{
    public partial class Empleado
    {
        public Empleado()
        {
            Sucursalempleado = new HashSet<Sucursalempleado>();
            Usuario = new HashSet<Usuario>();
        }

        public int IdEmpleado { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Cedula { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public int? IdEmpresa { get; set; }
        public ulong? Estado { get; set; }

        public virtual Empresa IdEmpresaNavigation { get; set; }
        public virtual ICollection<Sucursalempleado> Sucursalempleado { get; set; }
        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
