using IfxApi.Models;
using IfxData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IfxApi.Converts
{
    public static class EntidadConvert
    {
        public static Entidad toEntity(EntidadModel input)
        {
            Entidad output = new Entidad();
            output.Empleados = input.Empleados != null ? output.Empleados = EmpleadoConvert.toListEntity(input.Empleados);
            output.Id = input.Id != null ? output.Id = Guid.Parse(input.Id) : output.Id = Guid.NewGuid();
            output.RazonSocial = input.RazonSocial != null ? output.RazonSocial = input.RazonSocial : output.RazonSocial = "";
            output.Telefono = input.Telefono != null ? output.Telefono = input.RazonSocial : output.Telefono = "";
            return output;
        }

        public static EntidadModel toModel(Entidad input)
        {
            EntidadModel output = new EntidadModel();
            output.Empleados = input.Empleados != null ? output.Empleados = EmpleadoConvert.toListEmpleadoModel(input.Empleados) : output.Empleados = null;
            output.Id = input.Id != null ? output.Id = input.Id.ToString() : output.Id = "-o-";
            output.RazonSocial = input.RazonSocial != null ? output.RazonSocial = input.RazonSocial : output.RazonSocial = "-0-";
            output.Telefono = input.Telefono != null ? output.Telefono = input.Telefono : output.Telefono = "-0-";
            return output;
        }

        public static List<EntidadModel> toListModel(List<Entidad> input)
        {
            return input.Select(c => toModel(c)).ToList();
        }
    }
}
