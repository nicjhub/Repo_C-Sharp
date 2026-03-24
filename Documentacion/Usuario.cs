using System;

namespace SistemaVideojuegos
{
    // Clase base
    public class Usuario
    {
        // Encapsulación
        public string Username { get; set; }
        public string Password { get; set; }

        // Método virtual (Polimorfismo)
        public virtual void MostrarMenu()
        {
            Console.WriteLine("Menú de usuario");
        }
    }
}