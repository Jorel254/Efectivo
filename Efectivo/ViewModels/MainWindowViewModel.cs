using Efectivo.Models;
using GoldenToolKit;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Efectivo.ViewModels
{
    public class MainWindowViewModel : ModelBase
    {
        private string _Hora;
        private string _TotalBoleto;
        private string totalIngresado;
        private string _IDBoleto;
        private string _Cambio;
        private string labelVi;

        public ObservableCollection<Dinero> Money { get; set; }
        public string TotalIngresado
        {
            get => totalIngresado;
            set
            {
                totalIngresado = value;
                OnPropertyChanged();
            }
        }
        public string TotalBoleto
        {
            get => _TotalBoleto;
            set
            {
                _TotalBoleto = value;
                OnPropertyChanged();
            }
        }
        public string Cambio
        {
            get => _Cambio;
            set
            {
                _Cambio = value;
                OnPropertyChanged();
            }
        }
        public string IDBoleto
        {
            get => _IDBoleto;
            set
            {
                _IDBoleto = value;
                OnPropertyChanged();
            }
        }
        public string Hora
        {
            get => _Hora;
            set
            {
                _Hora = value;
                OnPropertyChanged();
            }
        }

        public string LabelVi
        {
            get => labelVi;
            set
            {
                labelVi = value;
                OnPropertyChanged();
            }
        }
        public ICommand DeleteMoney { get; set; }
        public MainWindowViewModel()
        {
            this.Money = new ObservableCollection<Dinero>();
            LabelVi = IVisibilityEnum.GetString(VisibilityLevel.Hidden);
            DeleteMoney = new Command<Dinero>(Delete);
        }

        public void InsertMoney(Dinero dinero)
        {
            this.Money.Add(dinero);
        }
        public bool ConetinsMoney(Dinero dinero)
        {
            if (this.Money.Contains(dinero))
            {
                return true;
            }
            return false;
        }
        public void Delete(Dinero obj)
        {
            if (Money.Contains(obj) && obj.Cantidad>1)
            {
                obj.Cantidad--;
            }else
            {
                Money.Remove(obj);
            }
            
        }
    }
}
