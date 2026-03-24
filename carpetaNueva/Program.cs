using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace poo2
{
    public class Program
    {
        static List<Persona> personas = new List<Persona>();
        static Queue<Persona> colaAtencion = new Queue<Persona>();
        static Stack<Persona> historialAtendidos = new Stack<Persona>();

        static void Main(string[] args)
        {
            bool salir = false;

            while (!salir)
            {
                Console.WriteLine("\n=== MENÚ DE ESTUDIANTES ===");
                Console.WriteLine("1. Agregar estudiante");
                Console.WriteLine("2. Listar estudiantes");
                Console.WriteLine("3. Buscar por cédula");
                Console.WriteLine("4. Filtrar por edad");
                Console.WriteLine("5. Atender estudiante");
                Console.WriteLine("6. Ver historial");
                Console.WriteLine("7. Salir");
                Console.Write("Opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1": AgregarEstudiante(); break;
                    case "2": ListarEstudiantes(); break;
                    case "3": BuscarCedula(); break;
                    case "4": FiltrarEdad(); break;
                    case "5": AtenderEstudiante(); break;
                    case "6": MostrarHistorial(); break;
                    case "7": salir = true; break;
                    default: Console.WriteLine("Opción inválida"); break;
                }
            }
        }

        public static void AgregarEstudiante()
        {
            Console.Write("¿Es becado? (s/n): ");
            string esBecado = Console.ReadLine().ToLower();

            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();

            int edad;
            Console.Write("Edad: ");
            while (!int.TryParse(Console.ReadLine(), out edad))
            {
                Console.Write("Edad válida: ");
            }

            Console.Write("Cédula: ");
            string cedula = Console.ReadLine();

            Console.Write("Carrera: ");
            string carrera = Console.ReadLine();

            Persona nuevo;

            if (esBecado == "s")
            {
                Console.Write("Tipo de beca: ");
                string tipoBeca = Console.ReadLine();

                nuevo = new EstudianteBecado(nombre, edad, cedula, carrera, tipoBeca);
            }
            else
            {
                nuevo = new Estudiante(nombre, edad, cedula, carrera);
            }

            personas.Add(nuevo);
            colaAtencion.Enqueue(nuevo);

            Console.WriteLine("Estudiante agregado correctamente.");
        }

        public static void ListarEstudiantes()
        {
            Console.WriteLine("\nLista de estudiantes:");

            foreach (Persona p in personas)
            {
                Console.WriteLine(p.MostrarInfo());
                Console.WriteLine($"Pago: {p.CalcularPago()}");
            }
        }

        public static void BuscarCedula()
        {
            Console.Write("Ingrese cédula: ");
            string cedula = Console.ReadLine();

            var encontrado = personas.Find(p => p.Cedula == cedula);

            if (encontrado != null)
            {
                Console.WriteLine(encontrado.MostrarInfo());
            }
            else
            {
                Console.WriteLine("No encontrado.");
            }
        }

        public static void FiltrarEdad()
        {
            Console.Write("Edad mínima: ");
            int edad = int.Parse(Console.ReadLine());

            var filtrados = personas.Where(p => p.Edad >= edad);

            foreach (var p in filtrados)
            {
                Console.WriteLine(p.MostrarInfo());
            }
        }

        public static void AtenderEstudiante()
        {
            if (colaAtencion.Count > 0)
            {
                var p = colaAtencion.Dequeue();

                Console.WriteLine("Atendiendo:");
                Console.WriteLine(p.MostrarInfo());

                historialAtendidos.Push(p);
            }
            else
            {
                Console.WriteLine("No hay estudiantes.");
            }
        }

        public static void MostrarHistorial()
        {
            Console.WriteLine("\nHistorial:");

            foreach (var p in historialAtendidos)
            {
                Console.WriteLine(p.MostrarInfo());
            }
        }
    }
}