using SAVNI_CRM.Data.IRepository;
using SAVNI_CRM.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SAVNI_CRM.Data.IBase
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Empresa> EmpresaRepository { get; }
        IRepository<Usuario> UsuarioRepository { get; }
        IRepository<Sucursal> SucursalRepository { get; }
        IRepository<Cliente> ClienteRepository { get; }
        IRepository<Proveedor> ProveedorRepository { get; }
        IRepository<Proveedorcontacto> ProveedorContactoRepository { get; }
        IRepository<Empleado> EmpleadoRepository { get; }
        IRepository<Sucursalempleado> SucursalempleadoRepository { get; }

        int SaveChanges();
    }
}
