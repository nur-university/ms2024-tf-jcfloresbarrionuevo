using Microsoft.EntityFrameworkCore;
using NutriCenter.Domain.Entities;

namespace NutriCenter.Infraestructure.DBContext;

public partial class AppDbContext :  DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<PlanAlimentario> PlanAlimentario { get; set; }
    public virtual DbSet<Receta> Receta { get; set; }
    public virtual DbSet<TiempoComida> TiempoComida { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PlanAlimentario>()
        .HasMany(p => p.Recetas)
        .WithOne()
        .HasForeignKey(r => r.PlanAlimentarioId);

        modelBuilder.Entity<PlanAlimentario>()
        .HasMany(p => p.TiemposComida)
        .WithOne()
        .HasForeignKey(tc => tc.PlanAlimentarioId);
    }
    //
}
