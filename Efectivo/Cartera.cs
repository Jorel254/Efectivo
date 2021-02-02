using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Efectivo
{
    public class Cartera
    {

        
        public ObservableCollection<Dinero> Monedero { get; private set; }

        public Cartera()
        {
            Monedero = new ObservableCollection<Dinero>();
        }
        public bool Confirmado { get; private set; }

        public void AgregarBilletes( Dinero b)
        {
            Monedero.Add(b);
        }
        public void AgregarMonedas( Dinero m)
        {
            Monedero.Add(m);
        }
        
        
    }
}
