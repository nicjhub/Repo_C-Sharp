using System;
using System.Collections.Generic;

namespace SistemaVideojuegos
{
    // Clase derivada
    public class Jugador : Usuario
    {
        public List<Juego> Biblioteca { get; set; } = new List<Juego>();

        public override void MostrarMenu()
        {
            Console.WriteLine("Menú de jugador");
        }
    }
}