using NutriCenter.Domain.Entities;

namespace NutriCenter.Infraestructure.Interfaces
{
    public interface IPlanAlimentarioRepositorio
    {
        Task AgregarPlanAsync(PlanAlimentario plan);
        Task<List<PlanAlimentario>> ObtenerPlanesAsync();
    }
}
