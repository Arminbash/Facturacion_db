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


        // GET: api/Empresa/getEmpresa/1
        /// <summary>
        /// Obtiene la empresa por su Id.
        /// </summary>
        /// <remarks>
        /// Retorna el objeto de tipo empresa por medio de su Id.
        /// </remarks>
        /// <param name="idempresa">Id (GUID) de la empresa.</param>
        /// <response code="401">Unauthorized. No se ha indicado o es incorrecto el Token JWT de acceso.</response>              
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>        
        [HttpGet]
        [Route("getEmpresa")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Get(int idempresa)
        {
            return Ok(_serv.GetById(idempresa));
        }

        [HttpGet]
        [Route("getAllEmpresa")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetAll()
        {
            return Ok(_serv.GetAll());
        }

        [HttpPost]
        [Route("saveEmpresa")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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