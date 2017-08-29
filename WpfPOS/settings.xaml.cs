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
        bool saved = false;

        public settings()
        {
            InitializeComponent();
            config.Read(filename);
            setRadioChecks();
            fillComboBox();
            comboBoxProduct.SelectedIndex = comboBoxProduct.Items.IndexOf((string)config.Get("selectedProduct"));
            // radioImage.IsChecked = true;
            DataGrid1.ItemsSource = table.DefaultView;

            table.ReadXml(@System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\products-" + config.GetDict()["selectedProduct"] + ".xml");
        }

        // Ok button
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!saved)
            {
                MessageBoxResult result = MessageBox.Show("Your changes have not been saved.\r\nDo you want to save your changes?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    saveChanges();
                } 
            }
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
            if (!IsLoaded)
            {
                return; 
            }

            MainWindow.productData = (string)comboBoxProduct.SelectedItem;
            config.Set("selectedProduct", MainWindow.productData);
            config.Write(filename);

            renderTable();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AddProductDialog productDialog = new AddProductDialog();
            productDialog.ShowDialog();
            config.Read(filename);
            
            if (productDialog.NewProductAdded)
            {

                table.Clear();
                table.TableName = productDialog.NewProduct;

               // table = config.load(productDialog.NewProduct);
                config.load(@System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\products-" + productDialog.NewProduct + ".xml");
                comboBoxProduct.Items.Add(productDialog.NewProduct);
                comboBoxProduct.SelectedIndex = comboBoxProduct.Items.IndexOf(productDialog.NewProduct);
                MainWindow.productData = (string)comboBoxProduct.SelectedItem;
            }
        }

        private void renderTable()
        {

            table.Clear();
            string dataPath = @System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\products-" + MainWindow.productData + ".xml";
            table.TableName = MainWindow.productData; ;
            table.ReadXml(dataPath);
            //DataGrid1.ItemsSource = table.DefaultView;
        }

        // save button
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            saveChanges();
        }

        private void saveChanges()
        {
            saved = true;
            savedLabel.Visibility = Visibility.Visible;

            table.WriteXml(@System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\products-" + MainWindow.productData + ".xml", XmlWriteMode.WriteSchema);

            Task.Delay(2000).ContinueWith(_ =>
            {
                this.Dispatcher.Invoke(() =>
                {
                    savedLabel.Visibility = Visibility.Hidden;
                });
            }
            );
        }
    }
}
