using System;
using System.Collections.Generic;

namespace bucles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //FOR
            Console.WriteLine("Bucles FOR");
            Console.WriteLine("Números del 1 al 50 ");
            for (int i=1; i<=50; i++)
            {
                if (i==25) //valida cuando se llega a 25
                {
                    break; 
                }
                if (i%5==0) //valida los múltiplos
                {
                    continue;
                }
                Console.WriteLine(i);
            }//final bloque FOR

            //FOREACH
            Console.WriteLine("Bucles FOREACH");
            Console.WriteLine("Lista de estudiantes:" );

            List<string> estudiantes= new List<string>() {"Carlos", "Ana", "Miguel", "Luisa", "Feipe"};
            
            foreach (string nombre in estudiantes)
            {
                if (nombre== "Ana")
                    {
                        continue;
                    }
                
                Console.WriteLine ($"Buenos días {nombre}");
            }//final bloque foreach

            //WHILE
            Console.WriteLine("Bucles WHILE");
            Console.WriteLine ("Ingrese números positivos, escriba 0 para salir");

            int numero;

            while (true)
            {
                Console.Write("Ingrese un número: ");
                numero = int.Parse(Console.ReadLine()); //cambia el string a int
                
                if (numero > 100)
                {
                    Console.WriteLine("El número ha llegado al limite");
                    break;
                }
                
                if (numero == 0)
                {
                    Console.WriteLine ("Has salido del programa");
                    break;
                }

                if (numero >0)
                {
                    Console.WriteLine ("Número válido");
                }
            }//final del bloque while

            //DO WHILE
            Console.WriteLine("Bucles DO WHILE");
            int opcion;
            do
            {
                Console.WriteLine("\nMENÚ");
                Console.WriteLine ("1. Mostrar números pares");
                Console.WriteLine ("2. Mostrar números impares");
                Console.WriteLine ("3. Salir");
                Console.Write ("Selecciones una opción: ");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion) //valida la variable
                //funciona como un if con varias opciones disponibles
                //es más ordenado y sirve para comparar con varios valores
                {
                    case 1: //opciones posibles
                        Console.WriteLine("Números pares del 1 a 20");
                        for (int i= 1; i<=20;i++)
                        {
                            if (i%2 == 0)
                                Console.WriteLine(i);
                        }
                        break;
                    case 2:
                        Console.WriteLine("Números impares del 1 al 20");
                        for (int i=1; i<=20; i++)
                        {
                            if (i%2 !=0)
                                Console.WriteLine(i);
                        }
                        break;
                    case 3:
                        Console.WriteLine("Saliendo del programa . . .");
                        break;

                    default:
                        Console.WriteLine("Opción inválida, seleccione de nuevo");
                        break;

                }//bloque switch
                
            }while (opcion != 3);
        }
    }    
}