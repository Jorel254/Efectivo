using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Efectivo
{
    class Moneda : Dinero
    {
        public string Nombre { get; set; }
        public Moneda()
        {

        }
        public Moneda(string Nombre, int Valor, TipoEfectivo Tipo) : base(Valor, Tipo)
        {
            this.Nombre = Nombre;
        }
        
    }
}
