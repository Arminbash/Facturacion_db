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
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class ProveedorController : ControllerBase
    {
        ProveedorService _serv;
        public ProveedorController(ProveedorService serv)
        {
            _serv = serv;
        }
        
        
        [HttpGet]
        [Route("getProveedor")]
        public IActionResult get(int IdProveedor)
        {
            return Ok(_serv.GetById(IdProveedor));
        }
        [HttpGet]
        [Route("getAllProveedor")]
        public IActionResult GetAll()
        {
            return Ok(_serv.GetAll());
        }
        [HttpPost]
        [Route("saveProveedor")]
        public IActionResult save([FromBody] ProveedorViewModel proveedorViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var proveedor = MapperHelper<ProveedorViewModel, Proveedor>.ObjectTo(proveedorViewModel);
                    _serv.Save(proveedor);
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
        [Route("EditProveedor")]
        public IActionResult Edit([FromBody] ProveedorViewModel proveedorViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var proveedor = MapperHelper<ProveedorViewModel, Proveedor>.ObjectTo(proveedorViewModel);
                    _serv.Edit(proveedor);
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