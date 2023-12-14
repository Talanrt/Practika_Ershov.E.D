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
        
        private void btnTheme_Checked(object sender, RoutedEventArgs e)
        {
            ResourceDictionary dark = new ResourceDictionary();
            dark.Source = new Uri("Dark.xaml", UriKind.Relative);
            Application.Current.Resources.MergedDictionaries.Add(dark);

        }

        private void btnTheme_Unchecked(object sender, RoutedEventArgs e)
        {
            ResourceDictionary Light = new ResourceDictionary();
            Light.Source = new Uri("Light.xaml", UriKind.Relative);
            Application.Current.Resources.MergedDictionaries.Add(Light);
        }
        
        //private bool CheckCredentials(string username, string password)
        //{
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        try
        //        {
        //            connection.Open();

        //            string query = "SELECT COUNT(*) FROM admins WHERE username = @username AND password = @password";
        //            SqlCommand command = new SqlCommand(query, connection);
        //            command.Parameters.AddWithValue("@username", username);
        //            command.Parameters.AddWithValue("@password", password);

        //            int count = (int)command.ExecuteScalar();
        //            return count > 0;
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show("An error occurred: " + ex.Message);
        //            return false;
        //        }
        //    }
        //}

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            //string username = txtUser.Text;
            //string password = pass.ToString();

            //if (CheckCredentials(username, password))
            //{
            //    AdminWin adminWin = new AdminWin();
            //    adminWin.Show();
            //    Close();
            //}

        }



       
    }

}
