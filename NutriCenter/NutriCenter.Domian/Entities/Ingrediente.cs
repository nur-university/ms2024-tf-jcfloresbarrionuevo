using Microsoft.EntityFrameworkCore;

namespace NutriCenter.Domain.Entities
{
    [Owned]
    public class Ingrediente
    {
        public string Nombre { get; private set; }
        public string Cantidad { get; private set; }
        public string Unidad { get; private set; }

        public Ingrediente(string nombre, string cantidad, string unidad)
        {
            Nombre = nombre;
            Cantidad = cantidad;
            Unidad = unidad;
        }

        public override bool Equals(object obj)
        {
            return obj is Ingrediente ingrediente &&
                   Nombre == ingrediente.Nombre &&
                   Cantidad == ingrediente.Cantidad &&
                   Unidad == ingrediente.Unidad;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Nombre, Cantidad, Unidad);
        }
    }
}
