

using Efectivo.ViewModels;

namespace Efectivo.Views
{
    /// <summary>
    /// Interaction logic for SearchPage.xaml
    /// </summary>
    public partial class SearchPage 
    {
        public SearchPageViewModel Model { get; set; }
        public SearchPage(MainWindowViewModel model)
        {
            Model = new SearchPageViewModel(model);
            DataContext = Model;
            InitializeComponent();
        }
    }
}
