using Efectivo.Models;
using Efectivo.Views;
using GoldenToolKit;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Efectivo.ViewModels
{
   public class PaymentWindowViewModel : ModelBase
    {
        private string _Hora;
        private string _TotalBoleto;
        private string totalIngresado;
        private string _IDBoleto;
        private string _Cambio;
        private string labelVi;

        public ObservableCollection<Dinero> Money { get; set; }
        public MainWindowViewModel Instance { get; set; }
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
        public ICommand SearchCommand { get; set; }
        public PaymentWindowViewModel()
        {

        }
        public PaymentWindowViewModel(MainWindowViewModel model)
        {
            Instance = model;
            this.Money = new ObservableCollection<Dinero>();
            LabelVi = IVisibilityEnum.GetString(VisibilityLevel.Hidden);
            DeleteMoney = new Command<Dinero>(Delete);
            SearchCommand = new Command(SearchTicket);
        }

        public void AsignedClient(ClientModel client)
        {
            IDBoleto = "Boleto:" + client.ID.ToString();
            Hora = "Hora de entrada: " + client.Hora.Hour.ToString() + ":" + client.Hora.Minute.ToString() + ":" + client.Hora.Second.ToString();
            labelVi = IVisibilityEnum.GetString(VisibilityLevel.Visible);
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
            if (Money.Contains(obj) && obj.Cantidad > 1)
            {
                obj.Cantidad--;
            }
            else
            {
                Money.Remove(obj);
            }

        }
        public void SearchTicket(object obj)
        {
            App.MainWindow.Navegar(Instance.Second);
        }

    }
}
