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
    public class ClienteController : ControllerBase
    {
        ClienteService _serv;
        public ClienteController(ClienteService serv)
        {
            _serv = serv;
        }
        /// <summary>
        /// Cliente obtener por id
        /// </summary>
        /// <param name="IdCliente">id del cliente</param>
        /// <returns>retorna un cliente con el id especifico</returns>
        [HttpGet]
        [Route("getCliente")]
        public IActionResult get(int IdCliente)
        {
            return Ok(_serv.GetById(IdCliente));
        }
        [HttpGet]
        [Route("getAllCliente")]
        public IActionResult GetAll()
        {
            return Ok(_serv.GetAll());
        }
        [HttpPost]
        [Route("saveCliente")]
        public IActionResult save([FromBody] ClienteViewModel clienteViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var client = MapperHelper<ClienteViewModel, Cliente>.ObjectTo(clienteViewModel);
                    _serv.Save(client);
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
        [Route("EditCliente")]
        public IActionResult Edit([FromBody] ClienteViewModel clienteViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var client = MapperHelper<ClienteViewModel, Cliente>.ObjectTo(clienteViewModel);
                    _serv.Edit(client);
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