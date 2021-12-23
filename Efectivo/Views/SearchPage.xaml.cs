

using Efectivo.ViewModels;
using GoldenToolKit.Interfaces;
using System.Windows.Controls;

namespace Efectivo.Views
{
    /// <summary>
    /// Interaction logic for SearchPage.xaml
    /// </summary>
    public partial class SearchPage : UserControl, IUserControlInterface
    {
        public SearchPageViewModel Model { get; set; }
        
        public SearchPage()
        {
            Model = new SearchPageViewModel();
            DataContext = Model;
            InitializeComponent();
        }

        public void OnHidden()
        {
           
        }

        public void OnShown()
        {
           
        }

        public void OnMessageReceived(string json)
        {
           
        }
    }
}
