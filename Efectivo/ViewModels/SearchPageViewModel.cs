using Efectivo.Models;
using Efectivo.Views;
using GoldenToolKit;
using GoldenToolKit.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Efectivo.ViewModels
{
    public class SearchPageViewModel : ModelBase, IUserControlInterface
    {
        List<string> Items;
        private string iD;
        public string ID
        { 
            get => iD;
            set
            {
                iD = value;
                OnPropertyChanged();
            }
            
        }
        public ICommand FindTicketCommand { get; set; }
        public ClientModel client { get; set; }
        public SearchPageViewModel()
        {
          
            Items = new List<string>();
            FindTicketCommand = new Command(FindTicket);
        }

        private void FindTicket(object obj)
        {
            SQLConnect sQLConnect = new SQLConnect();
            sQLConnect.ConnectionDB("Proyectos", ".");
            Items.AddRange(sQLConnect.Read(sQLConnect.Connection, "SP_SEARCHTICKET", new SqlParameter("@ID", ID)));
            if (Items.Count <= 0)
            {
                MessageBox.Show("Boleto no encontrado","Alerta",MessageBoxButton.OK);
                Items.Clear();
                ID = "";
            }
            else
            {
                DateTime time;
                DateTime.TryParse(Items[2], out time);
                client = new ClientModel(Guid.Parse(Items[0]), DateTime.Parse(Items[1]), Convert.ToInt32(Items[3]), time);
                var instance = MasterControl.Current.GoBack();
                var PayModel = ((PaymentWindow)instance).Model;
                PayModel.AsignedClient(client);
                Items.Clear();
                MasterControl.Current.Navegar<PaymentWindow>();
            }
            
        }

        public void OnHidden()
        {
            throw new NotImplementedException();
        }

        public void OnShown()
        {
            throw new NotImplementedException();
        }

        public void OnMessageReceived(string json)
        {
            throw new NotImplementedException();
        }

        public void OnMessageReceived(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
