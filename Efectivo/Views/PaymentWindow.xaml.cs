using Efectivo.ViewModels;
using GoldenToolKit.Interfaces;
using System.Windows.Controls;

namespace Efectivo.Views
{
    /// <summary>
    /// Interaction logic for PaymentWindow.xaml
    /// </summary>
    public partial class PaymentWindow : UserControl, IUserControlInterface
    {
        public PaymentWindowViewModel Model { get; set; }
        public PaymentWindow()
        {
            Model = new PaymentWindowViewModel();
            DataContext = Model;
            InitializeComponent();
        }

        public void OnHidden()
        {
            //:)
        }

        public void OnShown()
        {
            //:)
        }

        public void OnMessageReceived(string json)
        {
            //:)
        }

        public void OnMessageReceived(object obj)
        {
            throw new System.NotImplementedException();
        }
    }
}
