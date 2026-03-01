using System;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.Text;

namespace seguridad
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine ("Seguridad básica. \nProtege a las aplicaciones de amenazas." );
            Console.WriteLine ("Válidación de datos.");

            Console.Write ("Ingrese su edad: ");
            string entrada = Console.ReadLine();//define la variable entrada 
            
            if (int.TryParse(entrada, out int edad) && edad >0) //transforma de string a int con TryParse
            {
                Console.WriteLine ("Edad válida " + edad);
            }
            else
            {
                Console.WriteLine ("Edad inválida.");
            }

            Console.Write("Ingrese su correo electrónico: ");
            string correo = Console.ReadLine ();
            string patron = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            if (Regex.IsMatch(correo, patron))
            {
                Console.WriteLine ("Correo válido.");
            }
            else
            {
                Console.WriteLine ("Formato de correo inválido.");
            } //final de la validación

            //Bloque de manejo de contraseñas
            Console.WriteLine ("Manejo de contraseñas.");
            Console.Write ("Ingresa tu contraseña.");
            string password = Console.ReadLine();

            string salt = Guid.NewGuid().ToString();
            string passwordSalt = password + salt;
            string hash = GenerarHash (passwordSalt);

            Console.WriteLine("Contraseña original: " + password);
            Console.WriteLine("Salt: " + salt);
            Console.WriteLine("Hash con SHA-256: " + hash);
        
        //Consulta de SQL
            Console.WriteLine ("Consulta segura SQL.");
            
            string usuario = "Nicole";
            string passwordIngresado = "24534";

            string hashedPassword = GenerarHash(passwordIngresado);
            
        //Seguro 
            string querySegura = "SELECT * FROM usuarios WHERE usuario = @usuario AND password = @password";
        
        //Inseguro
            // string query = "SELECT * FROM Users WHERE usuario = '" + usuario + "' AND password = '" + passwordIngresado + "'";

            Console.WriteLine("Consulta SQL segura:");
            Console.WriteLine(querySegura);
        
        
        //Por qué es más seguro con parámetros? 
        //Concatenar strings permite que el atacante modifique la consulta.
        //Usar parámetros separa la lógica SQL de los datos.
        
        Console.WriteLine ("Presione cualquier tecla para salir del prpgrama. . ."):
        Console.ReadKey();
        }
        static string GenerarHash(string texto)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(texto));
                return Convert.ToBase64String(bytes);
            }
        }
    }
}