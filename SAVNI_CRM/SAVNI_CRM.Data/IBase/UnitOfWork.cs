﻿using SAVNI_CRM.Data.IRepository;
using SAVNI_CRM.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace SAVNI_CRM.Data.IBase
{
    public partial class UnitOfWork : IUnitOfWork
    {
        private Repository<Empresa> _empresa; private Repository<Usuario> _usuario; private Repository<Sucursal> _sucursal;
        private Repository<Cliente> _cliente; private Repository<Proveedor> _proveedor; private Repository<Proveedorcontacto> _proveedorContacto;
        private Repository<Empleado> _empleado; private Repository<Sucursalempleado> _sucursalEmpleado;

        private readonly DbContext dbContext;
        #region("Constructor")
        public UnitOfWork(DbContext context)
        {
            dbContext = context;
        }
        #endregion

        public IRepository<Sucursal> SucursalRepository
        {
            get { return _sucursal ?? (_sucursal = new Repository<Sucursal>(dbContext)); }
        }

        public IRepository<Empresa> EmpresaRepository
        {
            get { return _empresa ?? (_empresa = new Repository<Empresa>(dbContext)); }
        }

        public IRepository<Usuario> UsuarioRepository
        {
            get { return _usuario ?? (_usuario = new Repository<Usuario>(dbContext)); }
        }

        public IRepository<Cliente> ClienteRepository
        {
            get { return _cliente ?? (_cliente = new Repository<Cliente>(dbContext)); }
        }

        public IRepository<Proveedor> ProveedorRepository
        {
            get { return _proveedor ?? (_proveedor = new Repository<Proveedor>(dbContext)); }
        }

        public IRepository<Proveedorcontacto> ProveedorContactoRepository
        {
            get { return _proveedorContacto ?? (_proveedorContacto = new Repository<Proveedorcontacto>(dbContext)); }
        }

        public IRepository<Empleado> EmpleadoRepository
        {
            get { return _empleado ?? (_empleado = new Repository<Empleado>(dbContext)); }
        }

        public IRepository<Sucursalempleado> SucursalempleadoRepository
        {
            get { return _sucursalEmpleado ?? (_sucursalEmpleado = new Repository<Sucursalempleado>(dbContext)); }
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
