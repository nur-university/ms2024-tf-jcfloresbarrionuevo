using NutriCenter.Domain.Entities;
using NutriCenter.Infraestructure.Interfaces;

namespace NutriCenter.Aplication.Commands
{
    public class CrearPlanAlimentarioCommandHandler
    {
        private readonly IPlanAlimentarioRepositorio _repositorio;

        public CrearPlanAlimentarioCommandHandler(IPlanAlimentarioRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task Handle(CrearPlanAlimentarioCommand command)
        {
            // Crear un nuevo PlanAlimentario
            var costo = new Dinero(command.CostoMonto, command.CostoMoneda);
            var plan = new PlanAlimentario(command.Nombre, command.DuracionDias, costo);

            // Agregar Recetas y Tiempos de Comida
            foreach (var recetaNombre in command.Recetas)
            {
                var receta = new Receta(recetaNombre, "Receta para el Plan Nutricional", command.IngredientesReceta, costo);
                plan.AgregarReceta(receta);
            }

            foreach (var tiempoComida in command.TiemposComida)
            {
                var tiempo = new TiempoComida(tiempoComida.Nombre, tiempoComida.Hora);
                plan.AgregarTiempoComida(tiempo);
            }

            // Guardar en el repositorio
            await _repositorio.AgregarPlanAsync(plan);
        }
        //
    }
}
