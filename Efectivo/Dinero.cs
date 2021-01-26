using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Efectivo
{
   abstract class Dinero
    {
        public enum TipoEfectivo { Moneda = 1, Billete = 2 }
        public int Valor { get; set; }

        public TipoEfectivo Tipo { get; set; }
        

        public Dinero(int Valor, TipoEfectivo Tipo)
        {
          
            this.Valor = Valor;
            this.Tipo = Tipo;
        }
        
    }
}
