using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace NutriCenter.Domain.Entities
{
    public class PlanAlimentario
    {
        public int Id { get; private set; }
        public string Nombre { get; private set; }
        public int DuracionDias { get; private set; }
        public List<Receta> Recetas { get; private set; }
        public List<TiempoComida> TiemposComida { get; private set; }
        public Dinero Costo { get; private set; }        

        private PlanAlimentario() { }

        public PlanAlimentario(string nombre, int duracionDias, Dinero costo)
        {
            Nombre = nombre;
            DuracionDias = duracionDias;
            Costo = costo;
            Recetas = new List<Receta>();
            TiemposComida = new List<TiempoComida>();
        }

        public void AgregarReceta(Receta receta)
        {
            if (!Recetas.Contains(receta))
                Recetas.Add(receta);
        }

        public void EliminarReceta(Receta receta)
        {
            Recetas.Remove(receta);
        }

        public void AgregarTiempoComida(TiempoComida tiempo)
        {
            if (!TiemposComida.Contains(tiempo))
                TiemposComida.Add(tiempo);
        }

        public void CalcularCosto()
        {
            // Lógica para calcular el costo basado en las recetas.
            decimal total = 0;
            foreach (var receta in Recetas)
            {
                total += receta.Costo.Monto;
            }

            Costo = new Dinero(total, Costo.Moneda);
        }
    }    
}
