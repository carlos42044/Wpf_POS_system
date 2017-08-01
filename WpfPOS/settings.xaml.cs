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
using AppSettingsLib;

namespace WpfPOS
{
    /// <summary>
    /// Interaction logic for settings.xaml
    /// </summary>
    public partial class settings : Window
    {

        string filename = @"C:\Users\CarlosF\Documents\Visual Studio 2017\Projects\WpfPOS\WpfPOS\settings.config";
        Config config = new Config();

        public settings()
        {
            InitializeComponent();
            config.Read(filename);
            setRadioChecks();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RadioButton_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void RadioButton_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void RadioButton_Click_3(object sender, RoutedEventArgs e)
        {

        }

        private void setRadioChecks()
        {
            if (config.Get("popupPay").Equals("true"))
            {
                popupWindow.IsChecked = true;
            }


            string radioChecked = "";

            foreach (KeyValuePair<string, object> item in config.GetDict().ToList())
            {
                if (!item.Key.Equals("popupPay") && item.Value.Equals("true"))
                {
                    radioChecked = (string)item.Key;
                }
            }

            switch (radioChecked)
            {
                case "LabelIsVisible":
                    radioLabel.IsChecked = true;
                    break;
                case "ButtonIsVisible":
                    radioButton.IsChecked = true;
                    break;
                case "DropIsVisible":
                    radioDropdown.IsChecked = true;
                    break;
                case "ImageIsVisible":
                    radioImage.IsChecked = true;
                    break;
                default:
                    break;
            }
            //MessageBox.Show("initial key in config " + radioChecked);

        }
    }
}
