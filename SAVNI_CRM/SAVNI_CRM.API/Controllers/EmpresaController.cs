using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SAVNI_CRM.Application.Services;
using SAVNI_CRM.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SAVNI_CRM.API.ViewModel;
using SAVNI_CRM.Application.AutoMapper;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace SAVNI_CRM.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class EmpresaController : ControllerBase
    {
        EmpresaService _serv;

        public EmpresaController(EmpresaService serv)
        {
            _serv = serv;
        }

        [HttpGet]
        [Route("getEmpresa")]
        public IActionResult Get(int idempresa)
        {
            return Ok(_serv.GetById(idempresa));
        }

        [HttpGet]
        [Route("getAllEmpresa")]
        public IActionResult GetAll()
        {
            return Ok(_serv.GetAll());
        }

        [HttpPost]
        [Route("saveEmpresa")]
        public IActionResult Save([FromBody] EmpresaViewModel empViewModel)
        {         
            try
            {
                if (ModelState.IsValid)
                {
                    var emp = MapperHelper<EmpresaViewModel, Empresa>.ObjectTo(empViewModel);
                    _serv.Save(emp);
                }
            }
           catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return BadRequest();
            }

            return Ok(true);
        }

        [HttpPost]
        [Route("EditEmpresa")]
        public IActionResult Edit([FromBody] EmpresaViewModel empViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var emp = MapperHelper<EmpresaViewModel, Empresa>.ObjectTo(empViewModel);
                    _serv.Edit(emp);
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