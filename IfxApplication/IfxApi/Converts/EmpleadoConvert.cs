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
            output.Entidad = input.Entidad != null ?  input.Entidad.RazonSocial : "Sin Entidad";
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
            Empleado output = new Empleado();
            output.Apellidos = input.Apellidos != null ? output.Apellidos = input.Apellidos : "-O-";
            output.Celular = input.Celular != null ? output.Celular = input.Celular : "-O-";
            output.Email = input.Email != null ? output.Email = input.Email : "-O-";
            output.EntidadId = input.EntidadId != null ? output.EntidadId = Guid.Parse(input.EntidadId) : Guid.Empty;
            output.Nombres = input.Nombres != null ? output.Nombres = input.Nombres : "-O-";
            output.Id = input.Id != null ? output.Id = Guid.Parse(input.Id) : Guid.Empty;
            return output;
        }

        public static List<Empleado> toListEntity(List<EmpleadoModel> input)
        {
            return input.Select(e => toEmpleadoEntity(e)).ToList();
        }

    }
}
