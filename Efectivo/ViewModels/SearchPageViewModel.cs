﻿using Efectivo.Models;
using Efectivo.Views;
using GoldenToolKit;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Efectivo.ViewModels
{
    public class SearchPageViewModel : ModelBase
    {
        List<string> items;
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
        public MainWindowViewModel instance { get; set; }
        public SearchPageViewModel()
        {

        }
        public SearchPageViewModel(MainWindowViewModel model)
        {
            instance = model;
            items = new List<string>();
            FindTicketCommand = new Command(FindTicket);
        }

        private void FindTicket(object obj)
        {
            SQLConnect sQLConnect = new SQLConnect();
            sQLConnect.ConnectionDB("Proyectos", ".");
            items.AddRange(sQLConnect.Read(sQLConnect.Connection, "SP_SEARCHTICKET", new SqlParameter("@ID", ID)));
            DateTime time;
            DateTime.TryParse(items[2], out time);
            client = new ClientModel(Guid.Parse(items[0]), DateTime.Parse(items[1]), Convert.ToInt32(items[3]),time);
            instance.First.Model.AsignedClient(client);
            App.MainWindow.Navegar(instance.First);
            items.Clear();
        }
    }
}