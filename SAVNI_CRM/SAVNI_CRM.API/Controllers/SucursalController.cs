using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SAVNI_CRM.API.ViewModel;
using SAVNI_CRM.Application.AutoMapper;
using SAVNI_CRM.Application.Services;
using SAVNI_CRM.Data.Models;

namespace SAVNI_CRM.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SucursalController : ControllerBase
    {
        SucursalService _serv;

        public SucursalController(SucursalService serv)
        {
            _serv = serv;
        }

        [HttpGet]
        [Route("getSucursal")]
        public IActionResult get(int IdSucursal)
        {
            return Ok(_serv.GetById(IdSucursal));
        }

        [HttpGet]
        [Route("getAllSucursal")]
        public IActionResult GetAll()
        {
            return Ok(_serv.GetAll());
        }

        [HttpPost]
        [Route("saveSucursal")]
        public IActionResult Save([FromBody] SucursalViewModel sucViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var suc = MapperHelper<SucursalViewModel, Sucursal>.ObjectTo(sucViewModel);
                    _serv.Save(suc);
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
        [Route("EditSucursal")]
        public IActionResult Edit([FromBody] SucursalViewModel sucViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var suc = MapperHelper<SucursalViewModel, Sucursal>.ObjectTo(sucViewModel);
                    _serv.Edit(suc);
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