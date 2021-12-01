using Efectivo.Models;
using GoldenToolKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Efectivo.ViewModels
{
    public class PrincipalPageViewModel : ModelBase
    {
        public Cartera Billetera { get; set; }
        public MainWindowViewModel ViewModel { get; set; }
        public ICommand GenerateCommand { get; set; }
        public PrincipalPageViewModel()
        {
            Billetera = new Cartera();
            GenerateCommand = new Command<Dinero>(AddMoney);
            WalletFull();
        }


        public void AddMoney(Dinero dinero)
        {
            if (ViewModel.ConetinsMoney(dinero))
            {
                dinero.Cantidad++;
            }
            else
            {
                ViewModel.InsertMoney(dinero);
            }
        }
        private void WalletFull()
        {
            Billetera.AgregarBilletes(new Billete("Cien", 100, 1, "/Images/Cien.png"));
            Billetera.AgregarBilletes(new Billete("Quinientos", 500, 1, "/Images/Quinientos.png"));
            Billetera.AgregarBilletes(new Billete("Doscientos", 200, 1, "/Images/Doscientos.png"));
            Billetera.AgregarBilletes(new Billete("Veinte", 20, 1, "/Images/Veinte.jpg"));
            Billetera.AgregarBilletes(new Billete("Cincuenta", 50, 1, "/Images/Cincuenta.png"));
            Billetera.AgregarMonedas(new Moneda("Diez", 10, 1, "/Images/Diez.png"));
            Billetera.AgregarMonedas(new Moneda("Cinco", 5, 1, "/Images/Cinco.png"));
            Billetera.AgregarMonedas(new Moneda("Dos", 2, 1, "/Images/Dos.png"));
            Billetera.AgregarMonedas(new Moneda("Uno", 1, 1, "/Images/Uno.png"));
        }
    }
}
