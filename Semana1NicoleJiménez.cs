using System;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
    
            Console.Write("Ingresa tu nombre: "); 
            string nombre = Console.ReadLine();

            Console.Write("Ingresa tu edad: "); 
            int edad = int.Parse(Console.ReadLine());

            // Da la info
            Console.WriteLine($"Hola {nombre}, tienes {edad} años.\"); 

            int edadFutura = edad + 5;
            Console.WriteLine($"En 5 años tendrás {edadFutura} años.\");
            // Valida las edades
            if (edad >= 18)
                {
                Console.WriteLine("Eres mayor de edad.\"); 
                }
            else
                {
                Console.WriteLine("Eres menor de edad.\");
                }

        }
        
    }
}
