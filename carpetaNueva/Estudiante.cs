using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poo2
{
    public class Estudiante : Persona
    {
        public string Carrera { get; set; }

        public Estudiante(string nombre, int edad, string cedula, string carrera)
            : base(nombre, edad, cedula)
        {
            Carrera = carrera;
        }

        public override string MostrarInfo()
        {
            return $"Estudiante: {Nombre}, Edad: {Edad}, Cédula: {Cedula}, Carrera: {Carrera}";
        }

        public override decimal CalcularPago()
        {
            if (Carrera == "Medicina")
                return 2000;
            if (Carrera == "Ingeniería")
                return 1500;
            return 1200;
        }
    }
}