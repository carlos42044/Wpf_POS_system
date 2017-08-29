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
            foreach (char c in textBox1.Text)
            {
               if(!Char.IsLetterOrDigit(c))
                {
                    wrongInput.Visibility = Visibility.Visible;
                    return;
                } 
            }

            wrongInput.Visibility = Visibility.Hidden;

            string key = textBox1.Text.ToLower();
            key = char.ToUpper(key[0]) + key.Substring(1);

            config.Read(filename);

            if (config.GetDict().ContainsKey("Product"+ key))
            {
                existsLabel.Visibility = Visibility.Visible;
            }
            else {
                config.Set("Product" + key, key);
                config.Write(filename);
                NewProduct = key;
                NewProductAdded = true;
                this.Close();
            }
        }

        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
           if (!IsLoaded)
            {
                return; 
            }

            wrongInput.Visibility = Visibility.Hidden;
            existsLabel.Visibility = Visibility.Hidden;

        }
    }
}
