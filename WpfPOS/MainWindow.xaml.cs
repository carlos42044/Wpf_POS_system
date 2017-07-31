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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfPOS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public Visibility ButtonisVisible
        {
            get { return nameBtn.Visibility; }
            set { nameBtn.Visibility = value; }
        }

        public Visibility LabelisVisible
        {
            get { return nameLabel.Visibility; }
            set { nameLabel.Visibility = value; }
        }
        public Visibility ImageisVisible
        {
            get { return pictureBox1.Visibility; }
            set { pictureBox1.Visibility = value; }
        }

        public Visibility DropisVisible
        {
            get { return comboBox1.Visibility; }
            set { comboBox1.Visibility = value; }
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void nameBtn_Click(object sender, RoutedEventArgs e)
        {
            nameBtn.Content = "Clicked";
            nameBtn.IsEnabled = false;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void nameLabel_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            nameLabel.Content = "I have been gloriously clicked";
        }
    }
}
