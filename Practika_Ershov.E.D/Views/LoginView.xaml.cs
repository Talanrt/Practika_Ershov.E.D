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



        //<Border.BorderBrush>
        //        <LinearGradientBrush StartPoint = "0,0" EndPoint="1,1">
        //            <GradientStop Color = "Green" Offset="0"/>
        //            <GradientStop Color = "MediumSeaGreen" Offset="0.75"/>
        //            <GradientStop Color = "MediumSlateBlue" Offset="1"/>
        //        </LinearGradientBrush>
        //    </Border.BorderBrush>

        //    <Border.Background>
        //        <LinearGradientBrush StartPoint = "0,1" EndPoint="1,0">
        //            <GradientStop Color = "MediumSeaGreen" Offset="0"/>
        //            <GradientStop Color = "#1B1448" Offset="1"/>
        //        </LinearGradientBrush>
        //    </Border.Background>
    }

}
