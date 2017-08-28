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
using System.Data;
using System.IO;

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
        DataTable table = new DataTable();

        public settings()
        {
            InitializeComponent();
            config.Read(filename);
            setRadioChecks();
            fillComboBox();
            comboBoxProduct.SelectedIndex = comboBoxProduct.Items.IndexOf((string)config.Get("selectedProduct"));
            // radioImage.IsChecked = true;
            DataGrid1.ItemsSource = table.DefaultView;

            foreach (KeyValuePair<string, object> item in config.GetDict().ToList())
            {
                if (item.Key.StartsWith("selected"))
                {
                    table.ReadXml(@System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\proudcts-" + item.Value + ".xml");
                }
            }

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

            MessageBox.Show(table.TableName);
            renderTable();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AddProductDialog productDialog = new AddProductDialog();
            productDialog.ShowDialog();

            if (productDialog.NewProductAdded)
            {
                comboBoxProduct.Items.Add(productDialog.NewProduct);
                comboBoxProduct.SelectedIndex = comboBoxProduct.Items.IndexOf(productDialog.NewProduct);
            }  
        }

        private void renderTable()
        {
            // combobox selcted index change method is being called as soon as settings is hit in the program fix it 
            table.ReadXml(@System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\proudcts-" + (string)comboBoxProduct.SelectedItem + ".xml");
        }
    }
}
