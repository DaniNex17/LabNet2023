using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1Poo
{
    public class Taxi : TransportePublico
    {
        public Taxi(int pasajeros) : base(pasajeros)
        {
          
        }

        public override void Avanzar()
        {
            Console.WriteLine("Taxi avanzando...");
        }

        public override void Detenerse()
        {
            Console.WriteLine("Taxi deteniendose...");
        }
    }
}
