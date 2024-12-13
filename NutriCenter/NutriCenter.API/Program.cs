using Microsoft.EntityFrameworkCore;
using NutriCenter.Aplication.Commands;
using NutriCenter.Aplication.Queries;
using NutriCenter.Infraestructure.DBContext;
using NutriCenter.Infraestructure.Implementation;
using NutriCenter.Infraestructure.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbNur"));
});

builder.Services.AddHttpClient();

builder.Services.AddScoped<IPlanAlimentarioRepositorio, PlanAlimentarioRepositorio>();

// Inyección de Handlers
builder.Services.AddScoped<CrearPlanAlimentarioCommandHandler>();
builder.Services.AddScoped<ObtenerPlanesQueryHandler>();

builder.Services.AddCors(options => {
    options.AddPolicy("PoliticaAcceso", app =>
    {
        app.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});
//

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//
app.UseCors("PoliticaAcceso");
//

app.UseAuthorization();

app.MapControllers();

app.Run();
