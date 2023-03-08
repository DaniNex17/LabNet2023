using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica2
{
    internal class Logic
    {
        public void MetodoQueLanzaExcepcion()
        {
            throw new Exception(" La excepcion ha sido capturada. ");
        }

        public void MetodoQueDevuelveExcepcion()
        {
            throw new ExcepcionPersonalizada(" La excepcion fue capturada. ");
        }
    }
}
