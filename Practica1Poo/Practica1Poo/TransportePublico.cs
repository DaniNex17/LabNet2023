using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1Poo
{
    public abstract class TransportePublico
    {
        public int pasajeros;

        public TransportePublico(int pasajeros) 
        {
            this.pasajeros = pasajeros;
        }

        public int getPasajeros()
        {
            return pasajeros;
        }

        public void setPasajeros(int pasajeros)
        {
            this.pasajeros= pasajeros;
        }

        public abstract void Avanzar();

        public abstract void Detenerse();

        

    }


}
