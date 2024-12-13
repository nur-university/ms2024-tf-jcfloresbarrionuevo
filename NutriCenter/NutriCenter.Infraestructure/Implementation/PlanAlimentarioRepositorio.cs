using Microsoft.EntityFrameworkCore;
using NutriCenter.Domain.Entities;
using NutriCenter.Infraestructure.DBContext;
using NutriCenter.Infraestructure.Interfaces;

namespace NutriCenter.Infraestructure.Implementation
{
    public class PlanAlimentarioRepositorio : IPlanAlimentarioRepositorio
    {
        private readonly AppDbContext _context;

        public PlanAlimentarioRepositorio(AppDbContext context)
        {
            _context = context;
        }

        public async Task AgregarPlanAsync(PlanAlimentario plan)
        {
            await _context.PlanAlimentario.AddAsync(plan);
            await _context.SaveChangesAsync();
        }

        public async Task<List<PlanAlimentario>> ObtenerPlanesAsync()
        {
            try
            {
                return await _context.PlanAlimentario.Include(p => p.Recetas).Include(p => p.TiemposComida).ToListAsync();
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }
    }
}
