using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica2
{
    public class Calculadora
    {
        public static double Dividir(double dividendo, double divisor)
        {
            if (divisor == 0)
            {
                throw new DivideByZeroException();
            }
            return dividendo / divisor;            
        }
        public static double DividirDosValores(double dividendo, double divisor)
        {
            if (divisor == 0)
            {
                throw new DivideByZeroException();
                
            }
            return dividendo / divisor;
        }
    }
}
