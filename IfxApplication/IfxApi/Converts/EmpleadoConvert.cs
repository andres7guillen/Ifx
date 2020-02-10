using IfxApi.Models;
using IfxData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IfxApi.Converts
{
    public static class EmpleadoConvert
    {
        public static EmpleadoModel toEmpleadoModel(Empleado input)
        {
            EmpleadoModel output = new EmpleadoModel();

            output.Apellidos = input.Apellidos;
            output.Celular = input.Celular;
            output.Email = input.Email;
            output.Entidad = input.Entidad == null ? "Sin Entidad": input.Entidad.RazonSocial;
            output.Id = input.Id.ToString();
            output.Nombres = input.Nombres;
            output.EntidadId = input.EntidadId.ToString();
            return output;
        }

        public static List<EmpleadoModel> toListEmpleadoModel(List<Empleado> input)
        {
            return input.Select(c => toEmpleadoModel(c)).ToList();
        }

        public static Empleado toEmpleadoEntity(EmpleadoModel input)
        {
            Empleado output = new Empleado()
            {
                Apellidos = input.Apellidos,
                Celular = input.Celular,
                Email = input.Email,
                EntidadId = Guid.Parse(input.EntidadId),
                Nombres = input.Nombres,
                Id = Guid.Parse(input.Id)
            };
            return output;
        }

    }
}
