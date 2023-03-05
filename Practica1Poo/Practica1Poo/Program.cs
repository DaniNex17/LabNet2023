using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1Poo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            TransportePublico[] transportes = new TransportePublico[10];

            for (int i = 0; i < 5; i++)
            {
                Console.Write("Ingresa el número de pasajeros en el Omnibus " + (i + 1) + ": ");
                int pasajeros = int.Parse(Console.ReadLine());
                transportes[i] = new Omnibus(pasajeros);
                /*
                int pasajeros = rnd.Next(1, 50);
                transportes[i] = new Omnibus(pasajeros);
                */
            }

            for (int i = 5; i < 10; i++)
            {
                Console.Write("Ingresa el número de pasajeros en el Taxi " + (i - 4) + ": ");
                int pasajeros = int.Parse(Console.ReadLine());
                transportes[i] = new Taxi(pasajeros);
                /*
                int pasajeros = rnd.Next(1, 5);
                transportes[i] = new Taxi(pasajeros);
                */
            }

            Console.WriteLine("\n ----------------------------------Transportes públicos: ---------------------------------- \n");
          
            for (int i = 0; i < transportes.Length; i++)
            {
                transportes[i].Avanzar();
                Console.WriteLine($"Transporte #{i + 1}: {transportes[i].GetType().Name} con {transportes[i].pasajeros} pasajeros.");
                transportes[i].Detenerse();
                Console.WriteLine("\n----------------------------------------------------------------");

            }
            
            

            Console.ReadKey();
        }
    }
}
