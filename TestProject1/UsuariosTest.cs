using Microsoft.AspNetCore.Mvc;
using Moq;
using TechOil.Controllers;
using TechOil.Modelos;
using TechOil.Repository;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task GetAllUsers()
        {
            // Arrange (preparacion)

            var usuarios = new List<Usuario>
            {
                new Usuario{CodUsuario = 1 , Nombre="Agustin", Contraseña="1234", Dni=123513, Tipo=1 },
                new Usuario{ CodUsuario = 2 , Nombre="Kevert", Contraseña="123", Dni=122133, Tipo=0 }
            };


            var mockRepository = new Mock<IUsuarioRepository>();
            mockRepository.Setup(repo => repo.GetAllUsuarios()).ReturnsAsync(usuarios); // llamamos al la interfaz de usuario y le decimos que devuelva la lista creada
            var controller = new UsuarioController(mockRepository.Object);

            // ACT (actuar)

            var result = await controller.Get() as OkObjectResult; // guardamos en una variable la llamada al endpoint como el objeto OK que devuelve dicho endpoint
            var usuariosTestResult = result.Value as IEnumerable<Usuario>; // convertimos el resultado en lo que se espera que el endpoint devuelva.

            // ASSERT  (Puebas)

            Assert.IsNotNull(result);
            Assert.IsNotNull(usuariosTestResult);
            Assert.AreEqual(2, usuariosTestResult.Count());

        }
    }
}