using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static Practika_Ershov.E.D.ViewModels.LoginViewModel;

namespace Practika_Ershov.E.D.Views
{
    /// <summary>
    /// Логика взаимодействия для LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
           
        }

        
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Registr_MouseDown(object sender, MouseButtonEventArgs e)
        {

            var reg = new Registr();
            reg.Show();
            this.Close();

        }
        
       

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

           
        }

        private void Setting_Click(object sender, RoutedEventArgs e)
        {
            SettingsWin set = new SettingsWin();
            set.Show();
        }
    }

}
