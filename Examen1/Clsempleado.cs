using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Examen1
{
    internal class Clsempleado
    {

        private string cedula;
        public string Nombre;
        private string direccion;
        public float salario;
        private string telefono;
        public Clsempleado() 
        {
            
        }
        //Constrctor
        public Clsempleado(string cedula, string Nombre, string direccion, float salario, string telefono)
        {
            this.cedula = cedula;
            this.Nombre = Nombre;
            this.direccion = direccion;
            this.salario = salario;
            this.telefono = telefono;

        }

        public void IngresarEmpleado() 
        {
              
            Console.WriteLine("Ingrese los datos del empleado:");
            Console.Write("Cédula: ");
            Cedula = Console.ReadLine();
            Console.Write("Nombre: ");
            Nombre = Console.ReadLine();
            Console.Write("Dirección: ");
            Direccion = Console.ReadLine();
            Console.Write("Teléfono: ");
            Telefono = Console.ReadLine();
            Console.Write("Salario: ");
            float Salario;
            if (float.TryParse(Console.ReadLine(), out salario))
            {
                Salario = salario;
            }
            else
            {
                Console.WriteLine("Salario inválido es pondra en 0");
                Salario = 0;
            }

        }


        public string Cedula { get; set; }
        public string nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public float Salario { get; set; }
    }

  
    

}
