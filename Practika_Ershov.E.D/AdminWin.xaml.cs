using Practika_Ershov.E.D.Models;
using Practika_Ershov.E.D.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Practika_Ershov.E.D
{
    /// <summary>
    /// Логика взаимодействия для AdminWin.xaml
    /// </summary>
    public partial class AdminWin : Window
    {

        //Tour_BaseEntities1 TE = new Tour_BaseEntities1();
        public AdminWin()
        {
            
            InitializeComponent();
           // loadgrid();
            
        }
        //private void loadgrid()
        //{
        //    var data = from r in TE.Employees select r;
        //}

       
        private void myBorder2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }

        }
        private bool IsMaximized = false;

        

        private void myBorder2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ClickCount== 2) 
            
            { 
                if (IsMaximized)
                {
                    this.WindowState = WindowState.Normal;
                    this.Width = 1080;
                    this.Height = 720;

                    IsMaximized= false;
                }   
                else
                {
                    this.WindowState = WindowState.Maximized;

                    IsMaximized = true;
                }
            }

        }

        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(LoginUser.Text) || string.IsNullOrEmpty(PasswordUser.Text) || string.IsNullOrEmpty(NameUser.Text) || string.IsNullOrEmpty(FamilyaUser.Text) || string.IsNullOrEmpty(PochtaUser.Text))
            {
                return;
            }

            try
            {
                SqlConnection con = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB; Database=Tour_Base; Integrated Security=True");
                con.Open();
                string add_data = "INSERT INTO [dbo].[User] VALUES(@Username, @Password, @Name, @LastName, @Email)";
                SqlCommand cmd = new SqlCommand(add_data, con);

                cmd.Parameters.AddWithValue("@Username", LoginUser.Text);
                cmd.Parameters.AddWithValue("@Password", PasswordUser.Text);
                cmd.Parameters.AddWithValue("@Name", NameUser.Text);
                cmd.Parameters.AddWithValue("@LastName", FamilyaUser.Text);
                cmd.Parameters.AddWithValue("@Email", PochtaUser.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                LoginUser.Text = "";
                PasswordUser.Text = "";
                NameUser.Text = "";
                FamilyaUser.Text = "";
                PochtaUser.Text = "";
               
            }
            catch
            {

            }
        }

        private void addUserButton_Click(object sender, RoutedEventArgs e)
        {
            border_admin.Visibility = Visibility.Hidden;
            border_checkUsers.Visibility = Visibility.Hidden;
            border_user.Visibility = Visibility.Visible; 
           
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            border_user.Visibility= Visibility.Hidden;
            border_admin.Visibility= Visibility.Hidden;
            border_checkUsers.Visibility= Visibility.Hidden;
            //обновление таблицы
            //SqlConnection connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Tour_Base;Integrated Security=True");
            //connection.Open();
            //string cmd = "SELECT * FROM User"; // Из какой таблицы нужен вывод
            //SqlCommand createCommand = new SqlCommand(cmd, connection);
            //createCommand.ExecuteNonQuery();
            //SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
            //DataTable dt = new DataTable("User");
            //dataAdp.Fill(dt);
            //DGridHotels.ItemsSource = dt.DefaultView;
            //connection.Close();
        }

        private void btnAddAdmin_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(LoginAdmin.Text) || string.IsNullOrEmpty(PasswordAdmin.Text))
            {
                return;
            }

            try
            {
                SqlConnection con = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB; Database=Tour_Base; Integrated Security=True");
                con.Open();
                string add_data = "INSERT INTO [dbo].[admins] VALUES(@username, @password)";
                SqlCommand cmd = new SqlCommand(add_data, con);

                cmd.Parameters.AddWithValue("@Username", LoginAdmin.Text);
                cmd.Parameters.AddWithValue("@Password", PasswordAdmin.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                LoginAdmin.Text = "";
                PasswordAdmin.Text = "";
               
            }
            catch
            {

            }
        }

        private void addAdminButton_Click(object sender, RoutedEventArgs e)
        {
            border_user.Visibility = Visibility.Hidden;
            border_checkUsers.Visibility = Visibility.Hidden;
            border_admin.Visibility = Visibility.Visible;
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            var Log = new LoginView();
            this.Close();
            Log.Show();
            
        }

        private void CheckUsers_Click(object sender, RoutedEventArgs e)
        {
            border_admin.Visibility = Visibility.Hidden;
            border_user.Visibility = Visibility.Hidden;
            border_checkUsers.Visibility = Visibility.Visible;

        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            AddEditWin addEdit = new AddEditWin();
            addEdit.Show();
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Tour_Base;Integrated Security=True");
            connection.Open();
            string cmd = "SELECT * FROM [User]";
            SqlCommand createCommand = new SqlCommand(cmd, connection);
            createCommand.ExecuteNonQuery();
            SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
            DataTable dt = new DataTable("User");
            dataAdp.Fill(dt);
            DGridHotels.ItemsSource = dt.DefaultView;
            connection.Close();


        }
        private void Delete_User(int Id)
        {
            SqlConnection connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Tour_Base;Integrated Security=True");
            string cmd = "DELETE FROM [User] WHERE Id = @Id";
            SqlCommand deleteCommand = new SqlCommand(cmd, connection);
            deleteCommand.Parameters.AddWithValue("@Id", Id);

            try
            {
                connection.Open();
                deleteCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
       
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (DGridHotels.SelectedItem != null && DGridHotels.SelectedItem is DataRowView)
            {
                DataRowView row = (DataRowView)DGridHotels.SelectedItem;
                int userId = Convert.ToInt32(row["Id"]); 
                Delete_User(userId);
            }
        }
    }
}
