using System;

namespace SistemaVideojuegos
{
    public class Usuario
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public virtual void MostrarMenu()
        {
            Console.WriteLine("Menú de usuario");
        }
    }
}