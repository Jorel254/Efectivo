using Efectivo.Models;
using Efectivo.Views;
using GoldenToolKit;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Efectivo.ViewModels
{
    public class MainWindowViewModel : ModelBase
    {
        private PaymentWindow _first;
        private SearchPage _second;
        public PaymentWindow First
        {
            get
            {
                if (_first == null)
                    _first = new PaymentWindow(this);
                return _first;
            }
        }
        public SearchPage Second
        {
            get
            {
                if (_second == null)
                    _second = new SearchPage(this);
                return _second;
            }
        }
       
    }
}
