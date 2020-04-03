using facturacion_db.Data.IRepository;
using facturacion_db.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace facturacion_db.Data.IBase
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Empresa> EmpresaRepository { get; }
        IRepository<Usuario> UsuarioRepository { get; }
        int SaveChanges();
    }
}
