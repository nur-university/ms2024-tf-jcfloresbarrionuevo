using NutriCenter.Domain.DTOs;
using NutriCenter.Infraestructure.Interfaces;

namespace NutriCenter.Aplication.Queries
{
    public class ObtenerPlanesQueryHandler
    {
        private readonly IPlanAlimentarioRepositorio _repositorio;

        public ObtenerPlanesQueryHandler(IPlanAlimentarioRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<List<PlanAlimentarioDTO>> Handle(ObtenerPlanesQuery query)
        {
            var planes = await _repositorio.ObtenerPlanesAsync();
            return planes.Select(plan => new PlanAlimentarioDTO
            {
                Id = plan.Id,
                Nombre = plan.Nombre,
                DuracionDias = plan.DuracionDias,
                Costo = $"{plan.Costo.Monto} {plan.Costo.Moneda}"
            }).ToList();
        }
    }
}
