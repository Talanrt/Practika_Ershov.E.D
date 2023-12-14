using System;
using System.Collections.Generic;
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

namespace Practika_Ershov.E.D
{
    /// <summary>
    /// Логика взаимодействия для AddEditWin.xaml
    /// </summary>
    public partial class AddEditWin : Window
    {
        private User _currentUSER = new User();
        public AddEditWin(User selectedUser )
        {
            if (selectedUser != null)
            {
                _currentUSER = selectedUser;
            }
            InitializeComponent();
            DataContext = _currentUSER;
        }

        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentUSER.Username))
                errors.AppendLine("Enter a username");
            if (string.IsNullOrWhiteSpace(_currentUSER.Password))
                errors.AppendLine("Enter a passsword");
            if (string.IsNullOrWhiteSpace(_currentUSER.Name))
                errors.AppendLine("Enter a name");
            if (string.IsNullOrWhiteSpace(_currentUSER.LastName))
                errors.AppendLine("Enter a last name");
             if (string.IsNullOrWhiteSpace(_currentUSER.Email))
                errors.AppendLine("Enter a email");


            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_currentUSER.Id == 0)
            {
                Tour_BaseEntities1.GetContext().User.Add(_currentUSER);
            }
            try
            {
                Tour_BaseEntities1.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}
