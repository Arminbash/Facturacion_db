using SAVNI_CRM.Data.IRepository;
using SAVNI_CRM.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace SAVNI_CRM.Data.IBase
{
    public partial class UnitOfWork : IUnitOfWork
    {
        private Repository<Empresa> _empresa; private Repository<Usuario> _usuario;

        private readonly DbContext dbContext;
        #region("Constructor")
        public UnitOfWork(DbContext context)
        {
            dbContext = context;
        }
        #endregion

        public IRepository<Empresa> EmpresaRepository
        {
            get { return _empresa ?? (_empresa = new Repository<Empresa>(dbContext)); }
        }

        public IRepository<Usuario> UsuarioRepository
        {
            get { return _usuario ?? (_usuario = new Repository<Usuario>(dbContext)); }
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }

        public int SaveChanges()
        {
            return dbContext.SaveChanges();
        }
    }

}
