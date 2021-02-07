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
    public class EmpleadoController : ControllerBase
    {
        private IEmpleadoServicio _EmpleadoServicio;
        //private readonly IMapper _mapper;
        public EmpleadoController(IEmpleadoServicio EmpleadoServicio, IMapper mapper)
        {
            _EmpleadoServicio = EmpleadoServicio;
            //_mapper = mapper;
        }


        [HttpGet("ObtenerPorId")]
        [AllowAnonymous]
        public async Task<IActionResult> Obtener(string IdEmpleado)
        {
            Guid empleadoId = Guid.Parse(IdEmpleado);
            var empleado = await _EmpleadoServicio.Obtener(empleadoId);
            //var resultado = _mapper.Map<EmpleadoModel>(empleado);
            return Ok(EmpleadoConvert.toEmpleadoModel(empleado));
        }

        [HttpGet("ObtenerTodos")]
        [AllowAnonymous]
        public async Task<IActionResult> ObtenerTodos()
        {
            var listado = await _EmpleadoServicio.ObtenerTodos();
            if (listado.Count() >= 1)
            {
                //var resultado = _mapper.Map<IEnumerator<EmpleadoModel>>(listado);
                return Ok(EmpleadoConvert.toListEmpleadoModel(listado));
            }
            else
            {
                string mensaje = "No hay empleados registrados";
                return Ok(mensaje);
            }

        }

        //Update,Create,Delete solo admin
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]
        [HttpPut("Actualizar")]
        public async Task<IActionResult> Actualizar([FromBody]EmpleadoModel modelo)
        {
            //var empleado = _mapper.Map<Empleado>(modelo);
            var resultado = await _EmpleadoServicio.Actualizar(EmpleadoConvert.toEmpleadoEntity(modelo));
            return Ok(EmpleadoConvert.toEmpleadoModel(resultado));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]
        [HttpPost("Crear")]
        public async Task<IActionResult> Crear([FromBody]EmpleadoModel modelo)
        {
            //Empleado empleado = _mapper.Map<Empleado>(modelo);
            var resultado = await _EmpleadoServicio.Crear(EmpleadoConvert.toEmpleadoEntity(modelo));
            return Ok(EmpleadoConvert.toEmpleadoModel(resultado));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(string EmpleadoId)
        {
            Guid empleadoId = Guid.Parse(EmpleadoId);
            var resultado = await _EmpleadoServicio.Eliminar(empleadoId);
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
                return Ok(res);
            }

        }

    }
}