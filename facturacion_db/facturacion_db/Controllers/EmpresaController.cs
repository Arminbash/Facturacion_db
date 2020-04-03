using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using facturacion_db.Application.Services;
using facturacion_db.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace facturacion_db.Controllers
{
    [ApiController]
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
        public IActionResult Get()
        {
            return Ok(_serv.ObtenerEmpresa(1));
        }
    }
}