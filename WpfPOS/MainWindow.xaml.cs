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
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Drawing.Drawing2D;
using System.IO;


namespace WpfPOS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Path to the settings.config file
        string filename = @"C:\Users\CarlosF\Documents\Visual Studio 2017\Projects\WpfPOS\WpfPOS\settings.config";
        Config config = new Config();
        
        // Employee and product classes
        Employee[] user = new Employee[5];
        Product[] items = new Product[6];
        Employee currentUser;

        // Variable to store runningTotal
        public static double runningTotal = 0.0;

        // Variables to store transaction information (global variables for the 2 forms)
        public static string Stamp { get; set; }
        public static string User { get; set; }
        public static string theUser = User;

        public static string Total { get; set; }
        public static string TenderEntered { get; set; }
        public static string Change { get; set; }
        public static string Required { get; set; }
        public static bool processClicked = false;

        // Properties for container visibility
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

        // Table variables
        public static DataTable table = new DataTable();
        public static DataTable table2 = new DataTable();

        public MainWindow()
        {
            InitializeComponent();


            containerVisibility();
            updateName();
            updateProducts();
            randomUser();
            updateContainers();
            createTableHeaders();
           
            // Creates timer for timeStamp label
            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0,0,1);
            dispatcherTimer.Start();
        }

        private void createTableHeaders()
        {
            // Headers for the cart table
            table.Columns.Add(new DataColumn("Description", typeof(String)));
            table.Columns.Add(new DataColumn("Price", typeof(String)));
            table.Columns.Add(new DataColumn("Quantity", typeof(int)));
            table.Columns.Add(new DataColumn("Total", typeof(String)));
            dataGridView1.ItemsSource = table.DefaultView;

            // Headers for the transaction table
            table2.Columns.Add(new DataColumn("Stamp", typeof(String)));
            table2.Columns.Add(new DataColumn("User", typeof(String)));
            table2.Columns.Add(new DataColumn("Total", typeof(String)));
            table2.Columns.Add(new DataColumn("Tendered", typeof(String)));
            table2.Columns.Add(new DataColumn("Change", typeof(String)));

            dataGridView2.ItemsSource = table2.DefaultView;
        }

        // Method to handle updating the time
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            timeLabel.Content = DateTime.Now.ToLongTimeString();
        }

      

        // changes user to random (in auto-property)
        private void randomUser()
        { 
            User = user[new Random().Next(0, 5)].getFirstName();
            theUser = User;
            //MessageBox.Show("randomUser() : " + User);
        }

        private void nameBtn_Click(object sender, RoutedEventArgs e)
        {
            randomUser();
            updateContainers();
        }

        private void nameLabel_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            randomUser();
            updateContainers();
        }

        private void pictureBox1_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            randomUser();
            updateContainers();
        }
        
        // updates auto-property for User when name is changed in comboBox
        private void comboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            User = comboBox1.SelectionBoxItem.ToString();
          // updateContainers();
        }
        
        // Used to show correct user container (reads from settings.config file)
        private void containerVisibility()
        {
            config.Read(filename);

            ButtonIsVisible = (System.Windows.Visibility)
                Enum.Parse(typeof(System.Windows.Visibility), (string)config.Get("ButtonIsVisible"));
            ImageIsVisible = (System.Windows.Visibility)
               Enum.Parse(typeof(System.Windows.Visibility), (string)config.Get("ImageIsVisible"));
            DropIsVisible = (System.Windows.Visibility)
               Enum.Parse(typeof(System.Windows.Visibility), (string)config.Get("DropIsVisible"));
            LabelIsVisible = (System.Windows.Visibility)
               Enum.Parse(typeof(System.Windows.Visibility), (string)config.Get("LabelIsVisible"));
          
        }

        // Update containers to show correct users
        private void updateContainers()
        {
            nameLabel.Content = theUser;
            nameBtn.Content = theUser;
            pictureBox1.Source = BitmapToImageSource(CreateImageFromText(theUser));
            comboBox1.SelectedIndex = comboBox1.Items.IndexOf(theUser);
        }

       

        // Adds items to cart
        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            payBtn.IsEnabled = true;
            Random rnd = new Random();
            Product newItem = items[rnd.Next(0, items.Length)];
            int quantity = rnd.Next(1, 4);
            double total = (double)quantity * newItem.getPrice();

            table.Rows.Add(new Object[] { newItem.getProductName(), String.Format("{0:#.00}", newItem.getPrice()), quantity, string.Format("{0:#.00}", total) });
            runningTotal += total;

            // attempting to format double in to "money" x.xx
            Total = frmtDouble(runningTotal);
            totalLabel.Content = Total;
            updateRequired();
        }

        // Listening for user to enter tender
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            updateTenderedRequired();
        }

        // Payment process. (handles both pop up and in-window payment)
        private void payBtn_Click(object sender, RoutedEventArgs e)
        {
            addBtn.IsEnabled = false;
            clearBtn.IsEnabled = false;
            payBtn.IsEnabled = false;
           // MessageBox.Show("at pay btn click User: " + User + "\r\n uuser is: " + uuser);

            if (config.Get("popupPay").Equals("true"))
            {
                popup pop = new popup();
                pop.ShowDialog();
                table.Rows.Clear();
                runningTotal = 0;
                totalLabel.Content = "0.00";
                addBtn.IsEnabled = true;
                clearBtn.IsEnabled = true;
            }
            else
            {
                tendered.Visibility = Visibility.Visible;
                requiredLabel.Visibility = Visibility.Visible;
                processBtn.Visibility = Visibility.Visible;
                cancelBtn.Visibility = Visibility.Visible;
                processBtn.IsEnabled = false;
            }
        }

        // format double to string (0.00)
        private string frmtDouble(double money)
        {
            return String.Format("{0:#.00}", money);
        }

        // update 'require: 0.00' label (only does 0-runningTotal)
        public void updateRequired()
        {
            Required = "required: " + String.Format("{0:#.00}", (0.0 - runningTotal));
            try
            {
                requiredLabel.Content = Required;
                requiredLabel.Foreground = System.Windows.Media.Brushes.Red;
            } catch (Exception e)
            {
                //MessageBox.Show(e);
            }
           
        }

        // update 'require: 0.00' label to show change/how much is still required
        private void updateTenderedRequired()
        {
            updateRequired();

            try
            {
                double currentEntered = Convert.ToDouble(tendered.Text);
                string currentRequired = String.Format("{0:#.00}", (runningTotal - currentEntered));

                if (runningTotal - currentEntered == 0 || currentRequired.Equals(".00"))
                {
                    requiredLabel.Foreground = System.Windows.Media.Brushes.Black;
                    Required = "change: " + 0;
                    requiredLabel.Content = Required;
                    processBtn.IsEnabled = true;
                }
                else if (runningTotal - currentEntered > 0)
                {
                    Required = "required: " + String.Format("{0:#.00}", (runningTotal - currentEntered));
                    requiredLabel.Content = Required;
                    processBtn.IsEnabled = false;
                }
                else if (runningTotal - currentEntered < 0)
                {
                    requiredLabel.Foreground = System.Windows.Media.Brushes.Black;
                    Required = "change: " + String.Format("{0:#.00}", (Math.Abs(runningTotal - currentEntered)));
                    requiredLabel.Content = Required;
                    processBtn.IsEnabled = true;
                }

            }
            catch (Exception exp)
            {
                //MessageBox.Show(exp.ToString());
            }
        }

        // Fills employee array with names
        private void updateName()
        {
            // Random employees
            String[] users = { "Mike", "Joe", "Samanatha", "Liz", "Evan" };

            for (int i = 0; i < users.Length; i++)
            {
                user[i] = new Employee(users[i], "Unkown");
                comboBox1.Items.Add(user[i].getFirstName());
            }

            // fill the comboBox with all the names
        }

        // Fills product array with products
        private void updateProducts()
        {
            // Random cheese products
            String[] products = { "Asiago", "Chedder", "Parmesan", "Swiss", "American", "PepperJack" };
            double[] prices = { .99, 1.20, .50, 1.25, 1.99, 1.12 };

            for (int i = 0; i < items.Length; i++)
            {
                items[i] = new Product(products[i], prices[i]);
            }
        }

        // Process payment in-window
        private void processBtn_Click(object sender, RoutedEventArgs e)
        {
            Stamp = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
            TenderEntered = tendered.Text;
            Total = String.Format("{0:#.00}", runningTotal.ToString());
            Change = String.Format("{0:#.00}", Math.Abs(runningTotal - Convert.ToDouble(TenderEntered)).ToString());
            table2.Rows.Add(new Object[] { Stamp, theUser, Total, TenderEntered, Change });

            runningTotal = 0;
            totalLabel.Content = "0.00";
            tendered.Text = "0.00";
            requiredLabel.Visibility = Visibility.Collapsed;
            processBtn.Visibility = Visibility.Collapsed;
            cancelBtn.Visibility = Visibility.Collapsed;
            tendered.Visibility = Visibility.Collapsed;
            table.Rows.Clear();


            addBtn.IsEnabled = true;
            clearBtn.IsEnabled = true;
            payBtn.IsEnabled = false;
        }

        // Cancel button
        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            processBtn.Visibility = Visibility.Collapsed;
            cancelBtn.Visibility = Visibility.Collapsed;
            tendered.Visibility = Visibility.Collapsed;
            requiredLabel.Visibility = Visibility.Collapsed;

            addBtn.IsEnabled = true;
            clearBtn.IsEnabled = true;
            payBtn.IsEnabled = true;
        }

        // Clear button, clears the table
        private void clearBtn_Click(object sender, RoutedEventArgs e)
        {
            table.Rows.Clear();
            runningTotal = 0;
            totalLabel.Content = "0.00";
        }

        // Text to bitmap converter
        public Bitmap CreateImageFromText(string Text)
        {
            // Create the Font object for the image text drawing.
            Font textFont = new Font("Arial", 18, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);

            Bitmap ImageObject = new Bitmap(150, 40);
            // Add the anti aliasing or color settings.
            Graphics GraphicsObject = Graphics.FromImage(ImageObject);

            // Set Background color
            GraphicsObject.Clear(System.Drawing.Color.White);
            // to specify no aliasing
            GraphicsObject.SmoothingMode = SmoothingMode.Default;
            GraphicsObject.TextRenderingHint = TextRenderingHint.SystemDefault;
            GraphicsObject.DrawString(Text, textFont, new SolidBrush(System.Drawing.Color.Black), 0, 0);
            GraphicsObject.Flush();

            return (ImageObject);
        }
        
        // Bitmap to text converter
        public BitmapImage BitmapToImageSource(Bitmap bitmap)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                memory.Position = 0;
                BitmapImage bitmapimage = new BitmapImage();
                bitmapimage.BeginInit();
                bitmapimage.StreamSource = memory;
                bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapimage.EndInit();

                return bitmapimage;
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            settings settingWindow = new settings();
            settingWindow.ShowDialog();
            config.Read(filename);
            containerVisibility();
            updateContainers();
        }
    }

}
