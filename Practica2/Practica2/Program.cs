using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Practica2
{
    internal class Program
    {
        private Logic logica;
        static void Main(string[] args)
        {

            Console.WriteLine("\n--------------------------------Bienvenido a la Practica #2 de Este Maravilloso LAB-------------------------------- \n");
            bool salir = false;
            do
            {              
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Punto 1");
                Console.WriteLine("2. Punto 2");
                Console.WriteLine("3. Punto 3");
                Console.WriteLine("4. Punto 4");
                Console.WriteLine("5. Salir");
                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine();
                switch (opcion)
                {
                    case "1":
                        PrimerPunto();
                        break;
                    case "2":
                        SegundoPunto();                       
                        break;
                    case "3":
                        TercerPunto();
                        break;
                    case "4":
                        CuartoPunto();
                        break;
                    case "5":
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("Opción inválida. \n");
                        break;
                }
            } while (!salir);
        }
        //----------------------------------------------- PRIMER PUNTO -----------------------------------------------
        private static void PrimerPunto()
        {
            Calculadora calc = new Calculadora();
            while (true)
            {
                try
                {
                    Console.Write("Ingrese el dividendo: ");
                    double dividendo = double.Parse(Console.ReadLine());

                    Console.Write("Ingrese el divisor: ");
                    double divisor = double.Parse(Console.ReadLine());

                    double resultado = Calculadora.Dividir(dividendo, divisor);
                    Console.WriteLine($"El resultado de la división es: {resultado}");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error: se ingresó un valor no válido.");
                }
                catch (DivideByZeroException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                finally
                {
                    Console.WriteLine("Operación finalizada.");
                }
                Console.Write("¿Desea hacer otra división? (S/N): ");
                string respuesta = Console.ReadLine().ToUpper();
                if (respuesta != "S")
                {
                    break;
                }
            }
        }
        //----------------------------------------------- SEGUNDO PUNTO -----------------------------------------------
        private static void SegundoPunto()
        {
            Calculadora calc = new Calculadora();
            while (true)
            {
                try
                {
                    Console.Write("Ingrese el dividendo: ");
                    double dividendo = double.Parse(Console.ReadLine());

                    Console.Write("Ingrese el divisor: ");
                    double divisor = double.Parse(Console.ReadLine());

                    double resultado = Calculadora.DividirDosValores(dividendo, divisor);
                    Console.WriteLine($"El resultado de la división es: {resultado}");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error: Seguro Ingreso una letra o no ingreso nada!");
                }
                catch (DivideByZeroException ex)
                {
                    Console.WriteLine($"Solo Chuck Norris divide por cero!\n {ex.Message}");
                }
                finally
                {
                    Console.WriteLine("Operación finalizada.");
                }
                Console.Write("¿Desea hacer otra división? (S/N): ");
                string respuesta = Console.ReadLine().ToUpper();
                if (respuesta != "S")
                {
                    break;
                }
            }
        }
        //----------------------------------------------- TERCER PUNTO -----------------------------------------------
        private static void TercerPunto()
        {
            Logic logica = new Logic();
            try
            {
                logica.MetodoQueLanzaExcepcion();
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nMensaje de la excepcion: " + ex.Message);
                Console.WriteLine("Tipo de la excepcion: " + ex.GetType().ToString() + "\n");    
            }
        }
        //----------------------------------------------- CUARTO PUNTO -----------------------------------------------
        private static void CuartoPunto()
        {
            Logic logica = new Logic();
            try
            {              
                logica.MetodoQueDevuelveExcepcion();
            }
            catch (ExcepcionPersonalizada ex)
            {
                // Mostrar el mensaje y tipo de la excepción personalizada
                Console.WriteLine("\nMensaje de la excepción: " + ex.Message);
                Console.WriteLine("Tipo de la excepción: " + ex.GetType().ToString()+ "\n");
            }
        }
    }
}
