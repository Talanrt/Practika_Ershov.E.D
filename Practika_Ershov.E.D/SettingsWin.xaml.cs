using System;
using System.Collections.Generic;
using System.Configuration;
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
    /// Логика взаимодействия для SettingsWin.xaml
    /// </summary>
    public partial class SettingsWin : Window
    {
        Configuration AppConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        public SettingsWin()
        {
            InitializeComponent();

            if (AppConfig.Sections["UISettings"] is null)
            {
                AppConfig.Sections.Add("UISettings", new UISettings());

            }


            var UISettingSection = AppConfig.GetSection("UISettings");


            this.DataContext = UISettingSection;

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

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void SaveChanges_Click(object sender, RoutedEventArgs e)
        {
            AppConfig.Save();
        }
    }
}
