using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Efectivo
{
   public abstract class Dinero
    {
        public enum TipoEfectivo { Moneda = 1, Billete = 2 }
        public int Valor { get; set; }
        public string Nombre { get; set; }
        public TipoEfectivo Tipo { get; set; }
        

        public Dinero(string Nombre, int Valor, TipoEfectivo Tipo)
        {
            this.Nombre = Nombre;
            this.Valor = Valor;
            this.Tipo = Tipo;
        }
        
    }
}
