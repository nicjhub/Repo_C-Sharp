using System;
using System.Collections.Generic;

// Namespace del proyecto
namespace RefugioAnimales
{
    // CLASE ABSTRACTA
    public abstract class Animal
    {
        // Atributos privados
        private string nombre;
        private int edad;

        
        public string Nombre
        {
            get { return nombre; } 
            set { nombre = value; } 
        }

        
        public int Edad
        {
            get { return edad; }
            set
            {
                //edad debe ser mayor que 0
                if (value > 0)
                    edad = value;
                else
                    Console.WriteLine("La edad debe ser mayor que 0.");
            }
        }

        
        public Animal(string nombre, int edad)
        {
            Nombre = nombre;
            Edad = edad;
        }

        
        public abstract void EmitirSonido();
    }

    
    public class Perro : Animal
    {
        
        public Perro(string nombre, int edad) : base(nombre, edad) { }

        
        public override void EmitirSonido()
        {
            Console.WriteLine(Nombre + " dice: Guau Guau");
        }
    }

    
    public class Gato : Animal
    {
        public Gato(string nombre, int edad) : base(nombre, edad) { }

        public override void EmitirSonido()
        {
            Console.WriteLine(Nombre + " dice: Miau");
        }
    }

    
    public class Pajaro : Animal
    {
        public Pajaro(string nombre, int edad) : base(nombre, edad) { }

        public override void EmitirSonido()
        {
            Console.WriteLine(Nombre + " dice: Pío Pío");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Mensaje inicial
            Console.WriteLine("Sistema de Gestión de Animales - Refugio\n");

            // Lista que almacenará diferentes tipos de animales
            List<Animal> refugio = new List<Animal>();

            // Pude cantidad de animales al usuario
            Console.Write("¿Cuántos animales deseas ingresar?: ");
            int cantidad = int.Parse(Console.ReadLine());

            // Ciclo para ingresar animales
            for (int i = 0; i < cantidad; i++)
            {
                Console.WriteLine("\nAnimal #" + (i + 1));
                
                Console.Write("Tipo (perro/gato/pajaro): ");
                string tipo = Console.ReadLine().ToLower();

                Console.Write("Nombre: ");
                string nombre = Console.ReadLine();
              
                Console.Write("Edad: ");
                int edad = int.Parse(Console.ReadLine());

                Animal nuevoAnimal = null;

                if (tipo == "perro")
                    nuevoAnimal = new Perro(nombre, edad);
                else if (tipo == "gato")
                    nuevoAnimal = new Gato(nombre, edad);
                else if (tipo == "pajaro")
                    nuevoAnimal = new Pajaro(nombre, edad);
                else
                {
                    // Si el tipo es incorrecto, repite el intento
                    Console.WriteLine("Tipo no válido, intenta de nuevo.");
                    i--;
                    continue;
                }

                // Agregar el animal a la lista
                refugio.Add(nuevoAnimal);
            }

            // Muestra los animales registrados
            Console.WriteLine("\n--- Animales en el refugio ---\n");

            // Recorre la lista
            foreach (Animal animal in refugio)
            {
                // Mostrar datos
                Console.WriteLine("Nombre: " + animal.Nombre + " | Edad: " + animal.Edad);

                animal.EmitirSonido();

                Console.WriteLine();
            }

            // Pausa para que la consola no se cierre
            Console.WriteLine("Presiona ENTER para salir...");
            Console.ReadLine();
        }
    }
}