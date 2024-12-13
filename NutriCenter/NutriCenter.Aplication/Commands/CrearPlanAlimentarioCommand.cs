using Newtonsoft.Json;
using NutriCenter.Aplication.Utilities;
using NutriCenter.Domain.Entities;

namespace NutriCenter.Aplication.Commands;

public record CrearPlanAlimentarioCommand(
        string Nombre,
        int DuracionDias,
        decimal CostoMonto,
        string CostoMoneda,
        List<string> Recetas,        
        string IngredientesReceta,
        List<TiempoComida> TiemposComida
        //[JsonConverter(typeof(TimeSpanConverter))]
        //List<(string Nombre, TimeSpan Hora)> TiemposComida
 );