using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public EntidadController(IEntidadServicio entidadServicio, IMapper mapper)
        {
            _entidadServicio = entidadServicio;
            _mapper = mapper;
        }

        [HttpGet("ObtenerTodas")]
        public async Task<IActionResult> ObtenerTodas()
        {
            var listado = await _entidadServicio.obtenerTodas();
            return Ok(_mapper.Map<IEnumerable<EntidadModel>>(listado));
        }

        [HttpPost("Crear")]
        public async Task<IActionResult> Crear([FromBody]EntidadModel modelo)
        {
            var entidad = _mapper.Map<Entidad>(modelo);
            var resultado = await _entidadServicio.Crear(entidad);
            return Ok(_mapper.Map<EntidadModel>(resultado));
        }

    }
}