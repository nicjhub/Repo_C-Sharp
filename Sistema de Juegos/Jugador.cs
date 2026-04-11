using System;
using System.Collections.Generic;

namespace SistemaVideojuegos
{
    public class Jugador : Usuario
    {
        public List<Juego> Biblioteca { get; set; } = new List<Juego>();

        public override void MostrarMenu()
        {
            Console.WriteLine($"Bienvenido {Username}");
        }
    }
}