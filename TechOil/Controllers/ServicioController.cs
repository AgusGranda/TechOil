using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechOil.Modelos;
using TechOil.Repository;

namespace TechOil.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ServicioController : ControllerBase
    {
        private readonly IServicioRepository _servicioRepository;
        public ServicioController(IServicioRepository servicioRepository)
        {
            _servicioRepository = servicioRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var servicio = await _servicioRepository.GetAllServicios();
            return Ok(servicio);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var servicio = await _servicioRepository.GetServicioById(id);
            if (servicio != null)
            {
                return Ok(servicio);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Post(Servicio servicio)
        {
            await _servicioRepository.AddServicio(servicio);
            return CreatedAtAction(nameof(servicio), new { id = servicio.CodServicio }, servicio);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Servicio servicio, int id)
        {
            var servicioNuevo = await _servicioRepository.GetServicioById(id);
            if (servicioNuevo != null)
            {
                await _servicioRepository.UpdateServicio(servicioNuevo);
                return NoContent();
            }
            return BadRequest();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var servicioABorrar = await _servicioRepository.GetServicioById(id);
            if (servicioABorrar != null)
            {
                await _servicioRepository.DeleteServicioById(id);
                return NoContent();
            }
            return BadRequest();
        }
    }
}
