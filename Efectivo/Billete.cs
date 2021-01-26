using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Efectivo
{
    class Billete : Dinero
    {
       

        public Billete(string Nombre, int Valor) : base(Nombre, Valor, TipoEfectivo.Billete)
        {
           
        }
       
    }
}
