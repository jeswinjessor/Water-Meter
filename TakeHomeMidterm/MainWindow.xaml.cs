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

namespace TakeHomeMidterm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       public static Dictionary<double, double> _historyDictory = new Dictionary<double, double>();
        public MainWindow()
        {
            InitializeComponent();
            txtCurrentReading.Focus();
            
        }


        private void OnClickCalculate(object sender, RoutedEventArgs e) {
            double ChargeForWater = 0.00175;
            double CurrentReading = Convert.ToDouble(txtCurrentReading.Text);
            double PreviousReading = Convert.ToDouble(txtPreviousReading.Text);

            if (CurrentReading >= PreviousReading)
            {
                double GallonsUsed = CurrentReading - PreviousReading;
                double TotalCharge = GallonsUsed * ChargeForWater;
                txtGallonsUsed.Text = Convert.ToString(GallonsUsed);
                txtTotalCharge.Text = Convert.ToString(TotalCharge);
                try
                {
                    _historyDictory[GallonsUsed] = TotalCharge;
                    foreach (var s in _historyDictory)
                    {
                        txtErrorMessage.Text = Convert.ToString(s.Key);
                    }
                }
                catch 
                {
                    txtErrorMessage.Text = "This Reading is already Added!";
                }
            }
            else
            {
                txtErrorMessage.Text = "Current Reading is less than Previous Reading!!";
            }

            
        }
        private void About(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Water Meter");
        }
        private void Close(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void OnClickHistory(object sender, RoutedEventArgs e) 
        {
             HistoryWindow History = new HistoryWindow();
             History.ShowDialog();


        }

       
    }


}
