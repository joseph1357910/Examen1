using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen1
{

    internal class Clsmenu
    {
        private List<Clsempleado> empleados = new List<Clsempleado>(); 
        public string Empleadoencontrado;
        private string Consultarempleado;
        private string Listarempleado;
        private string Mostrarsalario;
        private string Calcularaltoybajo;
       

        public Clsmenu() 

        {
             int opcion; 

            Console.WriteLine("Menu");
            Console.WriteLine("1-Agregar Empleados");
            Console.WriteLine("2-Inicializar arreglos");
            Console.WriteLine("3-Modificar Empleados");
            Console.WriteLine("4-Borrar empleados");
            Console.WriteLine("5-Reportes");
           


            do
            {
                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    switch (opcion)
                    {
                        case 1: AgregarEmpleados(); break;
                        case 2: InicializarArreglos(); break;
                        case 3: ModificarEmpleados(); break;
                        case 4: BorrarEmpleados(); break;
                        case 5: Reportes(); break;
                        default:
                            break;
                    }
                    
                }
                
            } while (opcion !=6);

        }

        private void AgregarEmpleados()
        {
            Clsempleado nuevoEmpleado = new Clsempleado();
            nuevoEmpleado.IngresarEmpleado();
            empleados.Add(nuevoEmpleado);
            Console.WriteLine("Ingrese otra opcion del menu");
        }

        private void ModificarEmpleados()
        {
            Console.WriteLine("Modifique al empleado");

            Console.Write("Número de cédula del empleado a modificar: ");
            string cedulaAModificar = Console.ReadLine();

            Clsempleado empleadoAModificar = empleados.Find(e => e.Cedula == cedulaAModificar);

            if (empleadoAModificar != null)
            {
                Console.WriteLine("Nuevo nombre: ");
                string nuevoNombre = Console.ReadLine();
                if (!string.IsNullOrEmpty(nuevoNombre))
                {
                    empleadoAModificar.Nombre = nuevoNombre;
                }

                Console.WriteLine("Nueva dirección: ");
                string nuevaDireccion = Console.ReadLine();
                if (!string.IsNullOrEmpty(nuevaDireccion))
                {
                    empleadoAModificar.Direccion = nuevaDireccion;
                }

                Console.WriteLine("Nuevo teléfono: ");
                string nuevoTelefono = Console.ReadLine();
                if (!string.IsNullOrEmpty(nuevoTelefono))
                {
                    empleadoAModificar.Telefono = nuevoTelefono;
                }

                Console.WriteLine("Nuevo salario: ");
                string nuevoSalarioInput = Console.ReadLine();
                if (!string.IsNullOrEmpty(nuevoSalarioInput) && float.TryParse(nuevoSalarioInput, out float nuevoSalario))
                {
                    empleadoAModificar.Salario = nuevoSalario;
                }

                Console.WriteLine("Empleado modificado exitosamente.");
            }
            else
            {
                Console.WriteLine("Empleado no encontrado.");
            }
            Console.WriteLine("Ingrese otra opcion del menu");

        }
        private void BorrarEmpleados()
        {
           
            empleados.Clear();
            Console.WriteLine("Los datos del empleado se han eliminado");
            Console.WriteLine("Digite otra opcion del menu");
        }
        private void InicializarArreglos()
        {

        }
        private void Reportes()
        {
            int marcar;
            Console.WriteLine("Sub menu de reportes");
            Console.WriteLine("1-Consultar empleados");
            Console.WriteLine("2-Listar todos los empelados");
            Console.WriteLine("3-Calcular y mostrar el promedio de los salarios");
            Console.WriteLine("4-Calcular y mostrar el salario más alto y el más bajo de todos los empleados");
            Console.WriteLine("5-Salir");
            do
            {
                if (int.TryParse(Console.ReadLine(), out marcar))
                {
                    switch (marcar)
                    {
                        case 1: ConsultarEmpleados(); break;
                        case 2: Listartodoslosempelados(); break;
                        case 3: CalcularPromedioSalarios(); break;
                        case 4: SalariomasAltoBajo(); break;
                        case 5:
                            Console.WriteLine("Ingrese otra opcion del menu");
                            return; 
                        default:
                            break;
                    }
                }
            } while (marcar != 5);
            

        }

        public void ConsultarEmpleados() 
        {
            Console.WriteLine("Ingrese el número de cédula a buscar: ");
            string cedulaABuscar = Console.ReadLine();
            Clsempleado empleadoEncontrado = empleados.Find(e => e.Cedula == cedulaABuscar);

            if (empleadoEncontrado != null)
            {
                Console.WriteLine("Empleado encontrado:");
                Console.WriteLine("Cédula: " + empleadoEncontrado.Cedula);
                Console.WriteLine("Nombre: " + empleadoEncontrado.Nombre);
                Console.WriteLine("Dirección: " + empleadoEncontrado.Direccion);
                Console.WriteLine("Teléfono: " + empleadoEncontrado.Telefono);
                Console.WriteLine("Salario: " + empleadoEncontrado.salario);

            }
            else
            {
                Console.WriteLine("Empleado no encontrado.");
            }
            Console.WriteLine("Ingrese otra opcion del submenu");
        }
       
        public void Listartodoslosempelados() 
        {
            Console.WriteLine("Empleados ordendos por nombre:");
            var empleadosOrdenadosPorNombre = empleados.OrderBy(e => e.Nombre);

            foreach (var empleado in empleadosOrdenadosPorNombre)
            {
                Console.WriteLine("Cédula: " + empleado.Cedula);
                Console.WriteLine("Nombre: " + empleado.Nombre);
                Console.WriteLine("Dirección: " + empleado.Direccion);
                Console.WriteLine("Teléfono: " + empleado.Telefono);
                Console.WriteLine("Salario: " + empleado.Salario);
                Console.WriteLine();
               
            }
            Console.WriteLine("Ingrese otra opcion del submenu");
        }   
        public void CalcularPromedioSalarios() 
        {
            float totalSalarios = 0;

          
            foreach (var empleado in empleados)
            {
                totalSalarios += empleado.Salario;
            }

           
            float promedioSalarios = totalSalarios / empleados.Count;

            Console.WriteLine("Promedio de salarios: " + promedioSalarios);
            Console.WriteLine("Ingrese otra opcion del submenu");

        }

            

        public void SalariomasAltoBajo() 
        {
            float salarioAlto = CalcularSalarioAlto();
            float salarioBajo = CalcularSalarioBajo();

            Console.WriteLine("Salario más alto: " + salarioAlto);
            Console.WriteLine("Salario más bajo: " + salarioBajo);
            Console.WriteLine("Ingrese otra opcion del submenu");
        }
        public float CalcularSalarioAlto()
        {
            float salarioAlto = float.MinValue;

            foreach (var empleado in empleados)
            {
                if (empleado.Salario > salarioAlto)
                {
                    salarioAlto = empleado.Salario;
                }
            }

            return salarioAlto;
        }

        public float CalcularSalarioBajo()
        {
            float salarioBajo = float.MaxValue;

            foreach (var empleado in empleados)
            {
                if (empleado.Salario < salarioBajo)
                {
                    salarioBajo = empleado.Salario;
                }
            }

            return salarioBajo;
        }
    }
}
