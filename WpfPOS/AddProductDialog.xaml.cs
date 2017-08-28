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
    /// Interaction logic for AddProductDialog.xaml
    /// </summary>
    public partial class AddProductDialog : Window
    {
        Config config = new Config();
        string filename = MainWindow.filename;
        bool productFound = false;

        public string NewProduct { get; set; }
        public bool NewProductAdded { get; set; }


        public AddProductDialog()
        {
            config.Read(filename);
            InitializeComponent();
            NewProductAdded = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string productName = textBox1.Text.ToLower();
            productName = char.ToUpper(productName[0]) + productName.Substring(1);

            if (!productFound) okBtn.IsEnabled = true;

            foreach (KeyValuePair<string, object> item in config.GetDict().ToList())
            {
                if (item.Key.Equals("Product" + productName))
                {
                    MessageBox.Show("found the product" + productName);
                    existsLabel.Visibility = Visibility.Visible;
                    okBtn.IsEnabled = false;
                    productFound = true;
                }

                productFound = false;
            }

            if (!productFound)
            {
                config.Set("Product" + productName, productName);
                config.Write(filename);
                NewProduct = productName;
                NewProductAdded = true;
                this.Close();
            }
        }

        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                okBtn.IsEnabled = true;

            } catch(Exception ee)
            {

            }
        }
    }
}
