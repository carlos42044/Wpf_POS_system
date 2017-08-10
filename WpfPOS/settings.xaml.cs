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

        //string filename = @"C:\Users\CarlosF\Documents\Visual Studio 2017\Projects\WpfPOS\WpfPOS\settings.config";
        Config config = new Config();
        string filename = MainWindow.filename;

        public settings()
        {
            InitializeComponent();
            config.Read(filename);
            setRadioChecks();
            fillComboBox();
            comboBoxProduct.SelectedIndex = comboBoxProduct.Items.IndexOf((string)config.Get("selectedProduct"));
           // radioImage.IsChecked = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        // for radioLabel
        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            toggleRadio("userLabelIsVisible");
        }

        // radioButton
        private void RadioButton_Click_1(object sender, RoutedEventArgs e)
        {
            toggleRadio("userButtonIsVisible");
        }

        // radioImages
        private void RadioButton_Click_2(object sender, RoutedEventArgs e)
        {
            toggleRadio("userImageIsVisible");
        }

        // radioDropdown
        private void RadioButton_Click_3(object sender, RoutedEventArgs e)
        {
            toggleRadio("userDropIsVisible");
        }

        public void toggleRadio(string str)
        {
            foreach (KeyValuePair<string, object> item in config.GetDict().ToList())
            {
                if (item.Key.Equals(str))
                {
                    config.Set(item.Key, "Visible");

                }
                else if (item.Key.StartsWith("user"))
                {
                    config.Set(item.Key, "Collapsed");
                }
            }

            config.Write(filename);
        }

        private void setRadioChecks()
        {
            if (config.Get("popupPay").Equals("true"))
            {
                radioPopout.IsChecked = true;
            } else
            {
                radioInWindow.IsChecked = true;
            }


            string radioChecked = "";

            foreach (KeyValuePair<string, object> item in config.GetDict().ToList())
            {
                if (!item.Key.Equals("popupPay") && item.Value.Equals("Visible"))
                {
                    radioChecked = (string)item.Key;
                }
            }

            switch (radioChecked)
            {
                case "userLabelIsVisible":
                    radioLabel.IsChecked = true;
                    break;
                case "userButtonIsVisible":
                    radioButton.IsChecked = true;
                    break;
                case "userDropIsVisible":
                    radioDropdown.IsChecked = true;
                    break;
                case "userImageIsVisible":
                    radioImage.IsChecked = true;
                    break;
                default:
                    break;
            }
            //MessageBox.Show("initial key in config " + radioChecked);

        }

        // radioInWindow
        private void RadioButton_Click_4(object sender, RoutedEventArgs e)
        {
            config.Set("popupPay", "false");
            config.Write(filename);
        }

        // radioPopout
        private void popupWindow_Click(object sender, RoutedEventArgs e)
        {
            config.Set("popupPay", "true");
            config.Write(filename);
        }

        private void fillComboBox()
        {
            foreach (KeyValuePair<string, object> item in config.GetDict().ToList())
            {
                if (item.Key.StartsWith("Product"))
                {
                    comboBoxProduct.Items.Add((string)item.Value);
                } else if (item.Key.StartsWith("selected"))
                {
                    comboBoxProduct.SelectedIndex = comboBoxProduct.Items.IndexOf(item.Value);
                }
            }

        }

        private void comboBoxProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MainWindow.productData = (string)comboBoxProduct.SelectedItem;
            config.Set("selectedProduct", MainWindow.productData);
            config.Write(filename);
        }
    }
}
