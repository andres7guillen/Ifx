using System;
using System.Collections.Generic;
using System.Text;

namespace IfxData.Entities
{
    public class Empleado
    {
        public Guid Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public Guid EntidadId { get; set; }
        public Entidad Entidad { get; set; }
    }
}
