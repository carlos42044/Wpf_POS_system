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

namespace WpfPOS
{
    /// <summary>
    /// Interaction logic for popup.xaml
    /// </summary>
    public partial class popup : Window
    {
        double runningTotal = MainWindow.runningTotal;
        string user = MainWindow.theUser;
        string total = MainWindow.Total;
        string req = MainWindow.Required;
        string tenderEntered = MainWindow.TenderEntered;

        public popup()
        {
            InitializeComponent();
            requiredLabel.Content = req;
 }

        private void processBtn_Click(object sender, RoutedEventArgs e)
        {
            string stamp = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
            string change = String.Format("{0:#.00}", Math.Abs(runningTotal - Convert.ToDouble(tendered.Text)).ToString());
            string total = String.Format("{0:#.00}", runningTotal.ToString());

            MainWindow.table2.Rows.Add(new Object[] { stamp, user, total, String.Format("{0:#.00}", String.Format("{0:#.00}", tendered.Text)), change });
            MainWindow.processClicked = true;
            this.Close();
        }

        private void tendered_TextChanged(object sender, TextChangedEventArgs e)
        {
            requiredLabel.Content = req;
            requiredLabel.Foreground = Brushes.Red;

            try
            {
                double currentEntered = Convert.ToDouble(tendered.Text);
                string currentRequired = String.Format("{0:#.00}", (runningTotal - currentEntered));

                if (runningTotal - currentEntered == 0 || currentRequired.Equals(".00"))
                {
                    requiredLabel.Foreground= Brushes.Black;

                    requiredLabel.Content = "change: " + 0;
                    processBtn.IsEnabled = true;
                }
                else if (runningTotal - currentEntered > 0)
                {
                    requiredLabel.Content = "required: " + String.Format("{0:#.00}", (runningTotal - currentEntered));
                    processBtn.IsEnabled = false;
                }
                else if (runningTotal - currentEntered < 0)
                {
                    requiredLabel.Foreground = Brushes.Black;
                    requiredLabel.Content = "change: " + String.Format("{0:#.00}", (Math.Abs(runningTotal - currentEntered)));

                    processBtn.IsEnabled = true;
                }

            }
            catch (Exception exp)
            {
                //MessageBox.Show(exp.ToString());
            }
        }

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
