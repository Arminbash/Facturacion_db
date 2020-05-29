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
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProveedorContactoController : ControllerBase
    {
        ProveedorContactoService _serv;
        public ProveedorContactoController(ProveedorContactoService serv)
        {
            _serv = serv;
        }
        [HttpGet]
        [Route("getProveedorContacto")]
        public IActionResult get(int IdProveedorContacto)
        {
            return Ok(_serv.GetById(IdProveedorContacto));
        }
        [HttpGet]
        [Route("getAllProveedorContactoXIdProveedor")]
        public IActionResult GetAll(int IdProveedorContacto)
        {
            return Ok(_serv.GetAll(IdProveedorContacto));
        }
        [HttpGet]
        [Route("getAllProveedorContacto")]
        public IActionResult GetAll()
        {
            return Ok(_serv.GetAll());
        }
        [HttpPost]
        [Route("saveProveedorContacto")]
        public IActionResult save([FromBody] ProveedorContactoViewModel proveedorContactoViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var proveedorContacto = MapperHelper<ProveedorContactoViewModel, Proveedorcontacto>.ObjectTo(proveedorContactoViewModel);
                    _serv.Save(proveedorContacto);
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
        [Route("EditProveedorContacto")]
        public IActionResult Edit([FromBody] ProveedorContactoViewModel proveedorContactoViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var proveedorContacto = MapperHelper<ProveedorContactoViewModel, Proveedorcontacto>.ObjectTo(proveedorContactoViewModel);
                    _serv.Edit(proveedorContacto);
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