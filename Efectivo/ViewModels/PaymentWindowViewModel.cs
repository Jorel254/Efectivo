using Efectivo.Models;
using Efectivo.Views;
using GoldenToolKit;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;

namespace Efectivo.ViewModels
{
    public class PaymentWindowViewModel : ModelBase
    {
        List<string> Items;
        private string _Hora;
        private string _TotalBoleto;
        private string totalIngresado;
        private string _IDBoleto;
        private string _Cambio;
        private Visibility _labelVi;
        private int cash;
        private string _HoraSalida;
        Machine machine { get; set; }
        SQLConnect sQLConnect = new SQLConnect();
        public ClientModel Client { get; set; }
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
        public string HoraSalida
        {
            get => _HoraSalida;
            set
            {
                _HoraSalida = value;
                OnPropertyChanged();
            }
        }

        public Visibility LabelVi
        {
            get => _labelVi;
            set
            {
                _labelVi = value;
                OnPropertyChanged();
               
            }
        }
        public int Cash 
        {
            get => cash;
            set
            {
                cash = value;
                OnPropertyChanged();
            }
        }
        public ICommand DeleteMoney { get; set; }
        public ICommand SearchCommand { get; set; }
        public ICommand PayCommand { get; set; }
        public PaymentWindowViewModel()
        {
            Items = new List<string>();
            this.Money = new ObservableCollection<Dinero>();
            LabelVi = Visibility.Hidden;
            DeleteMoney = new Command<Dinero>(Delete);
            SearchCommand = new Command(SearchTicket);
            PayCommand = new Command(PayTicket);
            FindPrice();
        }

        private void PayTicket(object obj)
        {
            if (Convert.ToInt32(TotalIngresado) < Convert.ToInt32(TotalBoleto))
            {
                MessageBox.Show("El efectivo ingresado es menor al costo total del boleto", "Alerta", MessageBoxButton.OK);
            } else
            {
                var op = Convert.ToInt32(TotalIngresado) - Convert.ToInt32(TotalBoleto);
                Cambio = op.ToString();
                sQLConnect.ConnectionDB("Proyectos", ".");
                sQLConnect.ExecCommandSP(sQLConnect.Connection, "SP_PAYTICKET", new SqlParameter("@ID", Client.ID), new SqlParameter("@HORA_SALIDA", Client.Hora_salida));
                MessageBox.Show("Boleto pagado exitosamente", "Confirmación", MessageBoxButton.OK);
                sQLConnect.DesconnectionDB("Proyectos", ".");
                ClearScreen();
            }
        }

        public void AsignedClient(ClientModel client)
        {
            client.Hora_salida = DateTime.Now;
            Client = client;
            IDBoleto = "Boleto:" + client.ID.ToString();
            Hora = "Hora de entrada: " + client.Hora.Hour.ToString() + ":" + client.Hora.Minute.ToString() + ":" + client.Hora.Second.ToString();
            HoraSalida= "Hora actual: " + client.Hora_salida.Hour.ToString() + ":" + client.Hora_salida.Minute.ToString() + ":" + client.Hora_salida.Second.ToString();
            TimeSpan diferencia = client.Hora_salida.Subtract(client.Hora);
            int time = (int)diferencia.TotalMinutes;
            int ajuste = time / machine.TIEMPO;
            TotalBoleto = ajuste < 1 ? "0" : (ajuste * machine.PRECIO).ToString();
            LabelVi = Visibility.Visible;
            TotalIngresado = Cash.ToString();
        }

        public void InsertMoney(Dinero dinero)
        {
            this.Money.Add(dinero);
            Cash += dinero.Valor;
            TotalIngresado = Cash.ToString();

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
                Cash -= obj.Valor;
                TotalIngresado = Cash.ToString();
            }
            else
            {
                Money.Remove(obj);
                Cash -= obj.Valor;
                TotalIngresado = Cash.ToString();
            }

        }
        public void SearchTicket(object obj)
        {
            MasterControl.Current.Navegar<SearchPage>();

        }
        public void ClearScreen()
        {
            Money.Clear();
            IDBoleto = TotalBoleto = TotalIngresado = Cambio = HoraSalida = Hora = "";
            Cash = 0;
            LabelVi = Visibility.Hidden;
        }
        public void FindPrice()
        {
            sQLConnect.ConnectionDB("Proyectos", ".");
            Items.AddRange(sQLConnect.Read(sQLConnect.Connection, "SP_SEARCHPRICE", new SqlParameter("@ID", 2)));
            machine = new Machine(Convert.ToInt32(Items[0]), Convert.ToInt32(Items[1]), Convert.ToInt32(Items[2]), Convert.ToInt32(Items[3]));
            sQLConnect.DesconnectionDB("Proyectos", ".");
        }
    }
}
