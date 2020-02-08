using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IfxApi.Models
{
    public class EntidadModel
    {
        public string Id { get; set; }
        public string RazonSocial { get; set; }
        public List<EmpleadoModel> Empleados { get; set; }
        public string Telefono { get; set; }
    }
}
