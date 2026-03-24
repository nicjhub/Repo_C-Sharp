using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace poo2
{
    public class EstudianteBecado : Estudiante
    {
        public string TipoBeca { get; set; }

        public EstudianteBecado(string nombre, int edad, string cedula, string carrera, string tipoBeca)
            : base(nombre, edad, cedula, carrera)
        {
            TipoBeca = tipoBeca;
        }

        public override string MostrarInfo()
        {
            return $"Estudiante Becado: {Nombre}, Edad: {Edad}, Cédula: {Cedula}, Carrera: {Carrera}, Beca: {TipoBeca}";
        }

        public override decimal CalcularPago()
        {
            decimal pagoBase = base.CalcularPago();

            if (TipoBeca == "Completa")
                return 0;
            if (TipoBeca == "Parcial")
                return pagoBase * 0.5m;

            return pagoBase * 0.8m;
        }
    }
}