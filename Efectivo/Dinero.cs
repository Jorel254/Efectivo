using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Efectivo
{
    class Dinero
    {
        public enum TipoEfectivo { Moneda = 1, Billete = 2 }
        public int Valor { get; set; }

        public TipoEfectivo Tipo { get; set; }
        Cartera e = new Cartera();
        public Dinero()
        {

        }
        public Dinero(int Valor, TipoEfectivo Tipo)
        {
          
            this.Valor = Valor;
            this.Tipo = Tipo;
        }
        public  void AgregarBilletes(TipoEfectivo tipo, Billete b)
        {
            e.Monedero.Add(tipo,b);
        }
        public  void AgregarMonedas( TipoEfectivo tipo, Moneda m)
        {
            e.Monedero.Add(tipo,m);
        }
    }
}
