using System;
using System.Collections.Generic;

namespace SistemaVideojuegos
{
    class Program
    {
        static List<Juego> catalogo = new List<Juego>();

        static void Main()
        {
            InicializarDatos();
            MostrarMenu();
        }

        // 🔹 DATOS INICIALES
        static void InicializarDatos()
        {
            catalogo.Add(new Juego("FIFA", "Deportes"));
            catalogo.Add(new Juego("Minecraft", "Sandbox"));
        }

        //MENÚ PRINCIPAL
        static void MostrarMenu()
        {
            bool salir = false;

            while (!salir)
            {
                Console.WriteLine("\n--- MENÚ ---");
                Console.WriteLine("1. Ver catálogo");
                Console.WriteLine("2. Agregar juego");
                Console.WriteLine("3. Buscar juego");
                Console.WriteLine("4. Salir");

                int opcion = int.Parse(Console.ReadLine() ?? "0");

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
                        salir = true;
                        break;

                    default:
                        Console.WriteLine("Opción inválida");
                        break;
                }
            }
        }

        //FUNCIÓN: VER CATÁLOGO
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

        //FUNCIÓN: AGREGAR JUEGO
        static void AgregarJuego()
        {
            Console.Write("\nNombre del juego: ");
            string nombre = Console.ReadLine() ?? "";

            Console.Write("Género: ");
            string genero = Console.ReadLine() ?? "";

            catalogo.Add(new Juego(nombre, genero));

            Console.WriteLine("Juego agregado correctamente.");
        }

        //FUNCIÓN: BUSCAR JUEGO
        static void BuscarJuego()
        {
            Console.Write("\nIngrese el nombre a buscar: ");
            string nombre = Console.ReadLine() ?? "";

            bool encontrado = false;

            foreach (var juego in catalogo)
            {
                if (juego.Nombre.ToLower().Contains(nombre.ToLower()))
                {
                    Console.WriteLine($" {juego.Nombre} ({juego.Genero})");
                    encontrado = true;
                }
            }

            if (!encontrado)
            {
                Console.WriteLine("Juego no encontrado.");
            }
        }
    }
}