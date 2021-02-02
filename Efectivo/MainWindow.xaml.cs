using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Efectivo
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       public  Cartera Billetera { get; set; }
        public MainWindow()
        {
            Billetera = new Cartera();
            Billetera.AgregarBilletes(new Billete("Cien", 100));
            Billetera.AgregarBilletes(new Billete("Doscientos", 200));
            Billetera.AgregarBilletes(new Billete("Veinte", 20));
           
            InitializeComponent();
            
        }
        ObservableCollection<Dinero> Dineros= new ObservableCollection<Dinero>();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender">Sender SIEMPRE representa el OBJETO que generó el evento</param> zy xD
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
            Button n = (Button)sender;
            Dinero dinero = (Dinero)n.DataContext;
            //ahora buscar
            Dineros.Add(dinero);

        }
    }
}
