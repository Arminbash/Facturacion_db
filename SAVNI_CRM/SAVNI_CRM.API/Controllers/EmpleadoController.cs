using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SAVNI_CRM.API.ViewModel;
using SAVNI_CRM.Application.AutoMapper;
using SAVNI_CRM.Application.Services;
using SAVNI_CRM.Data.Models;

namespace SAVNI_CRM.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class EmpleadoController : ControllerBase
    {
        EmpleadoService _serv;

        public EmpleadoController(EmpleadoService serv)
        {
            _serv = serv;
        }

        [HttpPost]
        [Route("saveEmpleado")]
        public IActionResult Save([FromBody] EmpleadoViewModel empViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var emp = MapperHelper<EmpleadoViewModel, Empleado>.ObjectTo(empViewModel);
                    emp.Estado = 1;
                    var ValidarEmpleado = _serv.getEmpleadoByNombre(emp.Nombres, emp.Apellidos);
                    if (ValidarEmpleado == null)
                    {
                        _serv.Save(emp, empViewModel.IdSucursal);
                    }
                    else
                    {
                        return BadRequest("Empleado existente");
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return BadRequest();
            }

            return Ok(true);
        }

        [HttpPost]
        [Route("EditEmpleado")]
        public IActionResult Edit([FromBody] EmpleadoViewModel empViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var emp = MapperHelper<EmpleadoViewModel, Empleado>.ObjectTo(empViewModel);

                    var ValidarEmpleado = _serv.getEmpleadoByNombre(emp.Nombres, emp.Apellidos, emp.IdEmpleado);
                    if (ValidarEmpleado == null)
                    {
                        _serv.Edit(emp, empViewModel.IdSucursal);                        
                    }
                    else
                    {
                        return BadRequest("Empleado existente");
                    }
                                   
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return BadRequest();
            }

            return Ok(true);
        }

    }
}