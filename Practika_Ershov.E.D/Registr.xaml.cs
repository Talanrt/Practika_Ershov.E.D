using Practika_Ershov.E.D.Views;
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
using System.Xml.Linq;

namespace Practika_Ershov.E.D
{
    /// <summary>
    /// Логика взаимодействия для Registr.xaml
    /// </summary>
    public partial class Registr : Window
    {
        public Registr()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            LoginView lp = new LoginView();
            lp.Show();
            this.Close();
        }

        private void btnReg_Click(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrEmpty(Login.Text) || string.IsNullOrEmpty(Password.Text) || string.IsNullOrEmpty(Name.Text) || string.IsNullOrEmpty(Familya.Text) || string.IsNullOrEmpty(Pochta.Text)) 
            {  
                return;
            }
           
            try
            {
                SqlConnection con = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB; Database=Tour_Base; Integrated Security=True");
                con.Open();
                string add_data = "INSERT INTO [dbo].[User] VALUES(@Username, @Password, @Name, @LastName, @Email)";
                SqlCommand cmd = new SqlCommand(add_data, con);

                cmd.Parameters.AddWithValue("@Username", Login.Text);
                cmd.Parameters.AddWithValue("@Password", Password.Text);
                cmd.Parameters.AddWithValue("@Name", Name.Text);
                cmd.Parameters.AddWithValue("@LastName", Familya.Text);
                cmd.Parameters.AddWithValue("@Email", Pochta.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                Login.Text = "";
                Password.Text = "";
                Name.Text = "";
                Familya.Text = "";
                Pochta.Text = "";
                LoginView lp = new LoginView();
                this.Close();
                lp.Show();
            }
            catch
            {

            }
        }

        private void Setting_Click(object sender, RoutedEventArgs e)
        {
            SettingsWin Set = new SettingsWin();    
            Set.Show();
        }
    }
}
