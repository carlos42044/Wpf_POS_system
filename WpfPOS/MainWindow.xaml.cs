using System;
using System.Collections.Generic;
using System.Globalization;
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
using AppSettingsLib;

namespace WpfPOS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string filename = @"C:\Users\CarlosF\Documents\Visual Studio 2017\Projects\WpfPOS\WpfPOS\settings.config";

        Config config = new Config();

        public Visibility ButtonIsVisible
        {
            get { return nameBtn.Visibility; }
            set { nameBtn.Visibility = value; }
        }

        public Visibility LabelIsVisible
        {
            get { return nameLabel.Visibility; }
            set { nameLabel.Visibility = value; }
        }
        public Visibility ImageIsVisible
        {
            get { return pictureBox1.Visibility; }
            set { pictureBox1.Visibility = value; }
        }

        public Visibility DropIsVisible
        {
            get { return comboBox1.Visibility; }
            set { comboBox1.Visibility = value; }
        }

        public MainWindow()
        {
            InitializeComponent();
            containerVisibility();
        }

        private void nameBtn_Click(object sender, RoutedEventArgs e)
        {
            nameBtn.Content = "Clicked";
            nameBtn.IsEnabled = false;
            //nameBtn.Visibility = Visibility.V
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void nameLabel_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            nameLabel.Content = "I have been gloriously clicked";
        }

        private void containerVisibility()
        {
            config.Read(filename);
            ButtonIsVisible = config.Get("ButtonIsVisible");
            NullToCollapsed.Convert(config.Get("ButtonIsVisible"), Visibility, null);
            //ButtonIsVisible = ((Visibility)config.Get("ButtonIsVisible"));
            //LabelIsVisible = ((Visibility)config.Get("LabelIsVisible"));
            //ImageIsVisible = ((Visibility)config.Get("ImageIsVisible"));
            //DropIsVisible = ((Visibility)config.Get("DropIsVisible"));
        }
    }

    public static class NullToCollapsed : IValueConverter
    {
        public static object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value != null ? Visibility.Visible : Visibility.Collapsed;
        }
        public static object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
