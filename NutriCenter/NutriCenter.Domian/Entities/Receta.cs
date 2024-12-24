using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace NutriCenter.Domain.Entities
{
    public class Receta
    {
        public int Id { get; private set; }
        public int PlanAlimentarioId { get; private set; }
        public string Nombre { get; private set; }
        public string Descripcion { get; private set; }
        //public List<Ingrediente> Ingredientes { get; private set; }        
        public string Ingredientes { get; private set; }
        public Dinero Costo { get; private set; }

        private Receta() { }

        public Receta(string nombre, string descripcion,string ingredientes, Dinero costo)
        {
            Nombre = nombre;
            Descripcion = descripcion;
            Ingredientes = ingredientes;
            Costo = costo;
        }

        public void AgregarIngrediente(string ingrediente)
        {
            //if (!Ingredientes.Contains(ingrediente))
            //    Ingredientes.Add(ingrediente);            
            Ingredientes= ingrediente;
        }

        public void EliminarIngrediente()
        {
            //Ingredientes.Remove(ingrediente);            
            Ingredientes = string.Empty;
        }
    }    
}
