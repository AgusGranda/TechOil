using Microsoft.AspNetCore.Mvc;
using TechOil.Modelos;
using TechOil.Repository;

namespace TechOil.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class TrabajoController : ControllerBase
    {

        private readonly ITrabajoRepository _trabajoRepository;

        public TrabajoController(ITrabajoRepository trabajoRepository)
        {
            _trabajoRepository = trabajoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var trabajos = await _trabajoRepository.GetAllTrabajos();
            return Ok(trabajos);
        }
        [HttpGet("{estado}")]
        public async Task<IActionResult>GetByEstado(int estado)
        {
            var trabajos = await _trabajoRepository.GetTrabajoByEstado(estado);
            return Ok(trabajos);
        }
        

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var trabajo = await _trabajoRepository.GetTrabajoById(id);
            return Ok(trabajo);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Trabajo trabajo)
        {
            await _trabajoRepository.AddTrabajo(trabajo);
            return CreatedAtAction(nameof(Trabajo), new { id = trabajo.CodTrabajo }, trabajo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Trabajo trabajo, int id)
        {
            var trabajoAEditar = await _trabajoRepository.GetTrabajoById(id);
            if (trabajoAEditar != null)
            {
                trabajoAEditar.Fecha = trabajo.Fecha;
                trabajoAEditar.CodProyecto = trabajo.CodProyecto;
                trabajoAEditar.CodServicio = trabajo.CodServicio;
                trabajoAEditar.CantHora = trabajo.CantHora;
                trabajoAEditar.ValorHora = trabajo.ValorHora;
                trabajoAEditar.Costo = trabajo.Costo;
                await _trabajoRepository.UpdateTrabajo(trabajoAEditar);
                return NoContent();

            }
            return NotFound();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var trabajoAEliminar = await _trabajoRepository.GetTrabajoById(id);
            if (trabajoAEliminar != null)
            {
                await _trabajoRepository.DeleteTrabajo(id);
                return NoContent();
            }
            return NotFound();  
        }
    }
}
