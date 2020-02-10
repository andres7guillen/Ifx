using IfxData.Entities;
using IfxDomain.Servicio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EmpleadoTest
{
    [TestClass]
    public class EmpleadoTests
    {
        private readonly IEmpleadoServicio _servicio;

        public EmpleadoTests(IEmpleadoServicio servicio)
        {
            _servicio = servicio;
        }

        [TestMethod]
        public async void TestEmpleadoServicio()
        {
            //PREPARACION       
            Empleado empleadoCreado;
            Empleado empleadoActualizado;

            var empleado = new Empleado()
            {
                Apellidos = "Vasquez Hernandez",
                Celular = "311 362 2747",
                Email = "email.prueba@gmail.com",
                EntidadId = Guid.Parse("1E5A11E0-9D71-426A-87BD-062A0DEA58EA"),
                Nombres = "Juliana"
            };


            //PRUEBA
            try
            {
                empleadoCreado = await _servicio.Crear(empleado);
                empleadoCreado.Nombres = "Juliana Actualizado";
                empleadoActualizado = await _servicio.Actualizar(empleadoCreado);
            }
            catch (Exception e)
            {
                throw e;
            }

            //VERIFICACION
            Assert.IsNotNull(empleadoCreado);
            Assert.AreEqual(empleado.Nombres, empleadoActualizado.Nombres);
            



        }
    }
}
