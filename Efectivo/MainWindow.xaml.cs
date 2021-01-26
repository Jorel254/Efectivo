using System;
using System.Collections.Generic;
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
        public MainWindow()
        {
            InitializeComponent();

        }
       

        private void BtnAgregar_Click(object sender, RoutedEventArgs e)
        {
          
            int Validar;
            if (CheckB.IsChecked==true)
            {
                Validar = (int)Dinero.TipoEfectivo.Billete;
            }else if(CheckM.IsChecked==true)
            {
                Validar = (int)Dinero.TipoEfectivo.Moneda;
            }else
            {
                Validar = 0;
            }

            if (Validar==2)
            {
                try
                {
                   
                    
                    MessageBox.Show("Se agrego exitosamente", "Ingreso", MessageBoxButton.OK);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
                
            }else if (Validar==1)
            {
                try
                {
                    
                    MessageBox.Show("Se agrego exitosamente", "Ingreso", MessageBoxButton.OK);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            }else
            {
                MessageBox.Show("Necesita seleccionar si es Moneda o Billete para agregarlo", "Advertencia", MessageBoxButton.OK);
            }
            CheckB.IsEnabled = true;
            CheckM.IsEnabled = true;
            TxtNombre.Text = "";
            TxtValor.Text = "";
        }

        private void CheckB_Checked(object sender, RoutedEventArgs e)
        {
            CheckM.IsChecked=false;
        }

        private void CheckM_Checked(object sender, RoutedEventArgs e)
        {
            CheckB.IsChecked = false;
        }
    }
}
