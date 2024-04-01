using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TechOil.Modelos;

namespace TechOil.Controllers
{

    [ApiController]
    [Route("/api/[controller]")]
    public class ProyectoController : ControllerBase
    {

        private readonly IProyectoRepository _proyectoRepository;
        public ProyectoController(IProyectoRepository proyectoRepository)
        {
            _proyectoRepository = proyectoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var proyectos = await _proyectoRepository.GetAllProyectos();
            return Ok(proyectos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var proyecto = await _proyectoRepository.GetProyectoById(id);
            return Ok(proyecto);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Proyecto proyecto)
        {
            if (proyecto != null)
            {
                await _proyectoRepository.AddProyecto(proyecto);
                return CreatedAtAction(nameof(proyecto), new { id = proyecto.CodProyecto }, proyecto);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Proyecto proyecto, int id)
        {
            var proyectoToEdit = await _proyectoRepository.GetProyectoById(id);
            if (proyectoToEdit != null)
            {
                proyectoToEdit.Nombre = proyecto.Nombre;
                proyectoToEdit.Direccion = proyecto.Direccion;
                proyectoToEdit.Estado = proyecto.Estado;
                await _proyectoRepository.UpdateProyecto(proyectoToEdit);

            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var proyectoToDelete = await _proyectoRepository.GetProyectoById(id);
            if (proyectoToDelete != null)
            {
                await _proyectoRepository.DeleteProyecto(id);
            }
            return NotFound();
        }
    }
}