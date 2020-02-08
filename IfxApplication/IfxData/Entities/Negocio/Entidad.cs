using System;
using System.Collections.Generic;
using System.Text;

namespace IfxData.Entities
{
    public class Entidad
    {
        public Guid Id { get; set; }
        public string RazonSocial { get; set; }
        public List<Empleado> Empleados { get; set; }
        public string Telefono { get; set; }
    }
}
