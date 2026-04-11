using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaVideojuegos
{
    class Program
    {
        static List<Juego> catalogo = new List<Juego>();
        static Jugador jugador = new Jugador();

        static void Main()
        {
            InicializarDatos();

            // Usuario básico
            jugador.Username = "Invitado";
            jugador.Password = "1234";

            MostrarMenu();
        }

        static void InicializarDatos()
        {
            catalogo.Add(new Juego("FIFA", "Deportes"));
            catalogo.Add(new Juego("Minecraft", "Sandbox"));
            catalogo.Add(new Juego("Call of Duty", "Acción"));
        }

        static void MostrarMenu()
        {
            bool salir = false;

            while (!salir)
            {
                Console.WriteLine("\n--- MENÚ ---");
                Console.WriteLine("1. Ver catálogo");
                Console.WriteLine("2. Agregar juego");
                Console.WriteLine("3. Buscar juego");
                Console.WriteLine("4. Agregar a mi biblioteca");
                Console.WriteLine("5. Ver mi biblioteca");
                Console.WriteLine("6. Salir");

                if (!int.TryParse(Console.ReadLine(), out int opcion))
                {
                    Console.WriteLine("Ingrese un número válido.");
                    continue;
                }

                switch (opcion)
                {
                    case 1:
                        VerCatalogo();
                        break;

                    case 2:
                        AgregarJuego();
                        break;

                    case 3:
                        BuscarJuego();
                        break;

                    case 4:
                        AgregarABiblioteca();
                        break;

                    case 5:
                        VerBiblioteca();
                        break;

                    case 6:
                        salir = true;
                        break;

                    default:
                        Console.WriteLine("Opción inválida");
                        break;
                }
            }
        }

        static void VerCatalogo()
        {
            Console.WriteLine("\nCatálogo de juegos:");

            if (catalogo.Count == 0)
            {
                Console.WriteLine("No hay juegos registrados.");
                return;
            }

            foreach (var juego in catalogo)
            {
                Console.WriteLine($"- {juego.Nombre} ({juego.Genero})");
            }
        }

        static void AgregarJuego()
        {
            Console.Write("\nNombre del juego: ");
            string nombre = Console.ReadLine() ?? "";

            Console.Write("Género: ");
            string genero = Console.ReadLine() ?? "";

            catalogo.Add(new Juego(nombre, genero));
            Console.WriteLine("Juego agregado correctamente.");
        }

        // 🔍 LINQ
        static void BuscarJuego()
        {
            Console.Write("\nIngrese el nombre a buscar: ");
            string nombre = Console.ReadLine() ?? "";

            var resultados = catalogo
                .Where(j => j.Nombre.Contains(nombre, StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (resultados.Count == 0)
            {
                Console.WriteLine("Juego no encontrado.");
                return;
            }

            resultados.ForEach(j =>
                Console.WriteLine($"- {j.Nombre} ({j.Genero})"));
        }

        static void AgregarABiblioteca()
        {
            Console.Write("\nNombre del juego: ");
            string nombre = Console.ReadLine() ?? "";

            var juego = catalogo
                .FirstOrDefault(j => j.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));

            if (juego != null)
            {
                jugador.Biblioteca.Add(juego);
                Console.WriteLine("Juego agregado a tu biblioteca.");
            }
            else
            {
                Console.WriteLine("Juego no encontrado.");
            }
        }

        static void VerBiblioteca()
        {
            Console.WriteLine("\nTu biblioteca:");

            if (jugador.Biblioteca.Count == 0)
            {
                Console.WriteLine("No tienes juegos.");
                return;
            }

            jugador.Biblioteca.ForEach(j =>
                Console.WriteLine($"- {j.Nombre} ({j.Genero})"));
        }
    }
}