using Efectivo.ViewModels;
using System.Windows.Controls;

namespace Efectivo.Views
{
    /// <summary>
    /// Interaction logic for PaymentWindow.xaml
    /// </summary>
    public partial class PaymentWindow : UserControl
    {
        public PaymentWindowViewModel Model { get; set; }
        public PaymentWindow(MainWindowViewModel model)
        {
            Model = new PaymentWindowViewModel(model);
            DataContext = Model;
            InitializeComponent();
        }
    }
}
