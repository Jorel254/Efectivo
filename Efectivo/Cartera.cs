using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Efectivo
{
    class Cartera
    {


        List<Dinero> Monedero = new List<Dinero>();
        public void AgregarBilletes( Billete b)
        {
            Monedero.Add(b);
        }
        public void AgregarMonedas( Moneda m)
        {
            Monedero.Add(m);
        }

    }
}
