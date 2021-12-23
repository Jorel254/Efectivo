using Efectivo.ViewModels;
using GoldenToolKit.Interfaces;
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

namespace Efectivo.Views
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class Master : Window
    {
        public PrincipalPage principal { get; set; }
        public Master()
        {
            App.MainWindow = this;
            principal = new PrincipalPage();
            InitializeComponent();
            this.Navigation.Navegar(new PaymentWindow());
            IUserControlInterface actual = this.Navigation.GetCurrentControl();
            principal.Model2.ViewModel = ((PaymentWindow)actual).Model;
            principal.Show();
        }
        private void Window_Closing(object sender, CancelEventArgs e)
        {
            principal.Close();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Navigation.Navegar(this.Navigation.GoBack());
        }

        private void Forward_Click(object sender, RoutedEventArgs e)
        {
            this.Navigation.Navegar(this.Navigation.GoFoward());
        }
    }
}
