using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using IfxApi.Converts;
using IfxApi.Models;
using IfxData.Entities;
using IfxDomain.Servicio;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IfxApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class EntidadController : ControllerBase
    {
        private readonly IEntidadServicio _entidadServicio;
        //private readonly IMapper _mapper;

        public EntidadController(IEntidadServicio entidadServicio, IMapper mapper)
        {
            _entidadServicio = entidadServicio;
            //_mapper = mapper;
        }

        [HttpGet("ObtenerPorId")]
        [AllowAnonymous]
        public async Task<IActionResult> Obtener(string IdEntidad)
        {
            Guid entidadId = Guid.Parse(IdEntidad);
            var entidad = await _entidadServicio.Obtener(entidadId);            
            return Ok(EntidadConvert.toModel(entidad));
        }

        [HttpGet("ObtenerTodas")]
        public async Task<IActionResult> ObtenerTodas()
        {
            var listado = await _entidadServicio.obtenerTodas();
            return Ok(EntidadConvert.toListModel(listado));
        }

        [HttpPost("Crear")]
        public async Task<IActionResult> Crear([FromBody]EntidadModel modelo)
        {
            
            var resultado = await _entidadServicio.Crear(EntidadConvert.toEntity(modelo));
            return Ok(EntidadConvert.toModel(resultado));
        }

        [HttpPut("Actualizar")]
        public async Task<IActionResult> Actualizar([FromBody]EntidadModel modelo)
        {            
            var resultado = await _entidadServicio.Actualizar(EntidadConvert.toEntity(modelo));
            return Ok(EntidadConvert.toModel(resultado));
        }

        [HttpDelete("Eliminar")]
        public async Task<IActionResult> Eliminar(string EntidadId)
        {
            Guid entidadId = Guid.Parse(EntidadId);
            var resultado = await _entidadServicio.Eliminar(entidadId);
            if (resultado)
            {
                ResponseModel res = new ResponseModel()
                {
                    mensaje = "Empleado eliminado.",
                    estado = 200
                };


                return Ok(res);
            }
            else
            {
                ResponseModel res = new ResponseModel()
                {
                    mensaje = "No se pudo eliminar el empleado",
                    estado = 200
                };
                return BadRequest(res);
            }
        }

    }
}