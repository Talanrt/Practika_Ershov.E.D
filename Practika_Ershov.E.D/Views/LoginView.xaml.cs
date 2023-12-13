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
            myBorder.BorderBrush = new SolidColorBrush(Colors.DimGray);
            myBorder.Background = new SolidColorBrush(Colors.DimGray);
            fogotPS.Foreground = new SolidColorBrush(Colors.Black);
            btnLogin.Background= new SolidColorBrush(Colors.Gray);
            
        }

        private void btnTheme_Unchecked(object sender, RoutedEventArgs e)
        {
            fogotPS.Foreground = new SolidColorBrush(Colors.MediumSeaGreen);
            btnLogin.Background = new SolidColorBrush(Colors.MediumSeaGreen);
            myBorder.BorderBrush = new LinearGradientBrush
            {
                StartPoint = new Point(0, 0),
                EndPoint = new Point(1, 1),
                GradientStops =
                            {
                            new GradientStop(Colors.Green, 0),
                            new GradientStop(Colors.MediumSeaGreen, 0.75),
                            new GradientStop(Colors.MediumSlateBlue, 1)
                            }
            };
            myBorder.Background = new LinearGradientBrush
            {
                StartPoint = new Point(0, 1),
                EndPoint = new Point(1, 0),
                GradientStops =
                                {
                                new GradientStop(Colors.MediumSeaGreen, 0),
                                new GradientStop((Color)ColorConverter.ConvertFromString("#1B1448"), 1)
                                }
            };
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
