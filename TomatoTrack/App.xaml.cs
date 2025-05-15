using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace TomatoTrack
{
    /// <summary>
    /// Interação lógica para App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            
            LoginWindow login = new LoginWindow();
            login.Show();

        }
    }
}
