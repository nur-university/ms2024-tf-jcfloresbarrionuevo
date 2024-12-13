using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NutriCenter.Aplication.Commands;
using NutriCenter.Aplication.Queries;

namespace NutriCenter.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanAlimentarioController : ControllerBase
    {
        private readonly CrearPlanAlimentarioCommandHandler _crearHandler;
        private readonly ObtenerPlanesQueryHandler _obtenerHandler;

        public PlanAlimentarioController(
            CrearPlanAlimentarioCommandHandler crearHandler,
            ObtenerPlanesQueryHandler obtenerHandler)
        {
            _crearHandler = crearHandler;
            _obtenerHandler = obtenerHandler;
        }

        [HttpPost]
        public async Task<IActionResult> CrearPlan([FromBody] CrearPlanAlimentarioCommand command)
        {
            await _crearHandler.Handle(command);
            return Ok("Plan creado exitosamente.");
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerPlanes()
        {
            var planes = await _obtenerHandler.Handle(new ObtenerPlanesQuery());
            return Ok(planes);
        }
    }
}
