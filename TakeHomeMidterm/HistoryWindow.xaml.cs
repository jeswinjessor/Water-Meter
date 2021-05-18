using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

namespace TakeHomeMidterm
{
    /// <summary>
    /// Interaction logic for HistoryWindow.xaml
    /// </summary>
    public partial class HistoryWindow : Window 
    {
        //MainWindow MainWindow = new MainWindow();

       
        public HistoryWindow()
        {
            InitializeComponent();
            Dictionary<double, double> _HistoryListView = MainWindow._historyDictory;
            List<Items> list = new List<Items>();
            foreach (KeyValuePair<double, double> HistoryList in _HistoryListView)
            {
                list.Add(new Items(HistoryList.Key, HistoryList.Value));
            }
            var query = (from d in list orderby d.GallonsUsed select new { d.GallonsUsed, d.TotalCharge });
            HistoryItems.ItemsSource = query.ToList();
            
        }




    }


    public class Items
    {
        public double GallonsUsed { get; set; }
        public double TotalCharge { get; set; }

        public Items(double GallonsUsed, double TotalCharge)
        {
            this.GallonsUsed = GallonsUsed;
            this.TotalCharge = TotalCharge;
        }
    }
}
