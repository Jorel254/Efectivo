using Efectivo.ViewModels;
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
    public partial class MainWindow : Window
    {
        private readonly PrincipalPage principal;
        public MainWindow()
        {
            InitializeComponent();
            principal = new PrincipalPage();
            principal.Model2.ViewModel = this.Model;
            principal.Show();
        }
        private void Window_Closing(object sender, CancelEventArgs e)
        {
            principal.Close();
        }
    }
}
