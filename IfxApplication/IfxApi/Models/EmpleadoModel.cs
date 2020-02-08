using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IfxApi.Models
{
    public class EmpleadoModel
    {
        public string Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string EntidadId { get; set; }
        public EntidadModel Entidad { get; set; }
    }
}
