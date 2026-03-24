using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poo2
{
    public abstract class Persona
    {
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public int Edad { get; set; }

        public Persona() { }

        public Persona(string nombre, int edad, string cedula)
        {
            Nombre = nombre;
            Edad = edad;
            Cedula = cedula;
        }

        public abstract string MostrarInfo();

        public virtual decimal CalcularPago()
        {
            return 1000;
        }
    }
}