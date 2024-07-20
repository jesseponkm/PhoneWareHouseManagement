using BusinessObjects.Models;
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

namespace PhoneWarehouseManagement.Views
{
    /// <summary>
    /// Interaction logic for SalesOrder.xaml
    /// </summary>
    public partial class SalesOrder : Window
    {
        private readonly PhoneWarehouseDbContext context;
        public SalesOrder()
        {   
            InitializeComponent();
            context = new PhoneWarehouseDbContext();
            Load();
        }

        private void Load()
        {
            lvSalesOrder.ItemsSource = context.SalesOrders.ToList();
        }

        private void Export_Click(object sender, RoutedEventArgs e)
        {
            Export export = new Export();
            
            if(export != null)
            {
                this.Close();
                export.Show();
            }
        }

        private void btnDetail_Click(object sender, RoutedEventArgs e)
        {
             var salesOrder = (sender as FrameworkElement).DataContext as BusinessObjects.Models.SalesOrder;
            if(salesOrder != null)
            {
                SalesOrderDetails detail = new SalesOrderDetails(salesOrder);
                detail.ShowDialog();
            }
        }
    }
}
