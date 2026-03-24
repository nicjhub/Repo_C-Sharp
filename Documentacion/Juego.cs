namespace SistemaVideojuegos
{
    public class Juego
    {
        public string Nombre { get; set; }
        public string Genero { get; set; }

        public Juego(string nombre, string genero)
        {
            Nombre = nombre;
            Genero = genero;
        }
    }
}