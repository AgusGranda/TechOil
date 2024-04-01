using Microsoft.AspNetCore.Mvc;
using TechOil.Modelos;

namespace TechOil.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository ususarioRepository)
        {
            _usuarioRepository = ususarioRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var usuarios = await _usuarioRepository.GetAllUsuarios();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var usuario = await _usuarioRepository.GetUsuarioById(id);
            if (usuario != null)
            {
                return Ok(usuario);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Post(Usuario usuario)
        {
            await _usuarioRepository.AddUsuario(usuario);
            return CreatedAtAction(nameof(usuario), new { id = usuario.CodUsuario }, usuario);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Usuario usuario, int id)
        {
            var usuarioAModificar = await _usuarioRepository.GetUsuarioById(id);
            if (usuarioAModificar != null)
            {
                usuarioAModificar.Nombre = usuario.Nombre;
                usuarioAModificar.Dni = usuario.Dni;
                usuarioAModificar.Contraseña = usuario.Contraseña;
                usuarioAModificar.Tipo = usuario.Tipo;
                await _usuarioRepository.UpdateUsuario(usuarioAModificar);
                return NoContent();
            }
            return NotFound();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var usuarioAEliminar = await _usuarioRepository.GetUsuarioById(id);
            if (usuarioAEliminar != null)
            {
                await _usuarioRepository.DeleteUsuario(id);
                return NoContent();
            }
            return NotFound();
        }

    }
}
