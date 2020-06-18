using SAVNI_CRM.Application.AutoMapper;
using SAVNI_CRM.Application.IServices;
using SAVNI_CRM.Data.IBase;
using SAVNI_CRM.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAVNI_CRM.Application.Services
{
    public class EmpleadoService : IEntityService<Empleado>
    {
        private savniContext _db;

        public EmpleadoService(savniContext db)
        {
            _db = db;
        }
        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public int Edit(Empleado entity, int _IdSucursal)
        {
            _db = new savniContext();
            using (UnitOfWork unitOfWork = new UnitOfWork(_db))
            {
                var data = unitOfWork.EmpleadoRepository.FindBy(entity.IdEmpleado);

                MapperHelper<Empleado, Empleado>.CopyTo(entity, ref data);

                unitOfWork.EmpleadoRepository.Modified(data);

                Sucursalempleado _sucursalempleado = unitOfWork.SucursalempleadoRepository.GetEntities().Where(x => x.IdEmpleado == data.IdEmpleado && x.Estado == 1).FirstOrDefault();

                if (_sucursalempleado.IdSucursal != _IdSucursal)
                {
                    _sucursalempleado.Estado = 0;
                    unitOfWork.SucursalempleadoRepository.Modified(_sucursalempleado);

                    Sucursalempleado _sucursalempleadoSave = new Sucursalempleado();
                    _sucursalempleadoSave.IdSucursal = _IdSucursal;
                    _sucursalempleadoSave.IdEmpleado = data.IdEmpleado;
                    _sucursalempleadoSave.Estado = 1;
                    unitOfWork.SucursalempleadoRepository.Add(_sucursalempleadoSave);
                }
                return unitOfWork.SaveChanges();
            }
        }

        public IEnumerable<Empleado> GetAll()
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(_db))
            {
                return unitOfWork.EmpleadoRepository.GetEntities();
            }
        }

        public Empleado GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public int Save(Empleado entity, int _idsucursal)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(new savniContext()))
            {
                Sucursalempleado _sucursalempleado = new Sucursalempleado();
                _sucursalempleado.IdSucursal = _idsucursal;
                _sucursalempleado.Estado = 1;
                entity.Sucursalempleado.Add(_sucursalempleado);
                unitOfWork.EmpleadoRepository.Add(entity);               
                return unitOfWork.SaveChanges();
            }
        }
        public int SaveEmpleadoSucursal(Empleado entity)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(_db))
            {
                //unitOfWork.SucursalempleadoRepository.Add(entity);
                return unitOfWork.SaveChanges();
            }
        }
        public Empleado getEmpleadoByNombre(String _Nombres, string _Apellidos, int IdEmpleado = 0)
        {
            _db = new savniContext();
            using (UnitOfWork unitOfWork = new UnitOfWork(_db))
            {
                if(IdEmpleado == 0)
                return unitOfWork.EmpleadoRepository.GetEntities(filter: x => x.Nombres == _Nombres && x.Apellidos == _Apellidos).FirstOrDefault();
                else
                return unitOfWork.EmpleadoRepository.GetEntities(filter: x => x.IdEmpleado != IdEmpleado && x.Nombres == _Nombres && x.Apellidos == _Apellidos).FirstOrDefault();
            }
        }

        public int Save(Empleado entity)
        {
            throw new NotImplementedException();
        }

        public int Edit(Empleado entity)
        {
            throw new NotImplementedException();
        }
    }
}
