using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Efectivo
{
    class Dinero
    {
        private int Valor { get; set; }
        public enum Billetes { Moneda=1, Billete=2 }
        Cartera e = new Cartera();
        public Dinero()
        {

        }
        public Dinero(int valor)
        {
            this.Valor = valor;

        }
        public void AgregarBilletes(string nombre, Billete b)
        {
            e.Monedero.Add(nombre, b);
        }
        public void AgregarMonedas(string nombre, Moneda m)
        {
            e.Monedero.Add(nombre, m);
        }
    }
}
