using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Practika_Ershov.E.D.Views;

namespace Practika_Ershov.E.D
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected void ApplicationStart(object sender, StartupEventArgs e)
        {
            var loginView = new LoginView();
            loginView.Show();
            loginView.IsVisibleChanged += (s, sv) =>
            {
                if (loginView.IsVisible == false && loginView.IsLoaded)
                {
                    var mainWin = new MainWindow();
                    mainWin.Show();
                    loginView.Close();
                }
            };

        }   
    }
}
