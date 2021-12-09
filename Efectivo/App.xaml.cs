﻿using Efectivo.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Efectivo
{
    /// <summary>
    /// Lógica de interacción para App.xaml
    /// </summary>
   
    public partial class App : Application
    {
        public static new Master MainWindow { get; set; }
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
        }
    }
}
