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
        public Cartera Billetera { get; set; }
        public ObservableCollection<Dinero> dineros { get; set; }
        int Total = 0;
        public MainWindow()
        {
            Billetera = new Cartera();
            dineros = new ObservableCollection<Dinero>();
            Billetera.AgregarBilletes(new Billete("Cien", 100, 1));
            Billetera.AgregarBilletes(new Billete("Doscientos", 200, 1));
            Billetera.AgregarBilletes(new Billete("Veinte", 20, 1));

            InitializeComponent();

        }


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
            //if (dineros.Contains(dinero))
            //{
            //    int posicion = dineros.IndexOf(dinero);
            //    dineros.Remove(dinero);
            //    dinero.Cantidad += 1 ;
            //    dineros.Insert(posicion, dinero);
            //    Total += dinero.Valor;
            //    TxtTotal.Text = Total.ToString();
            //}
            //else
            //{
            //    dineros.Add(dinero);
            //    Total += dinero.Valor;
            //    TxtTotal.Text = Total.ToString();
            //}

            
            if (dineros.Contains(dinero))
            {
                //para que sacar y volver a meter si podemos incrementar la cantidad
                //como cantidad tiene INotifyPropertyChanged la vista se mantiene actualizada en el listview
                dinero.Cantidad++;
            }
            else
            {
                dineros.Add(dinero);
            }

            //Revisar la nueva propiedad calculada "Total" que se agregó en dinero
            //Calcular el todal y pasar el valor
            TxtTotal.Text = dineros.Sum(d => d.Total).ToString();
        }
    }
}
