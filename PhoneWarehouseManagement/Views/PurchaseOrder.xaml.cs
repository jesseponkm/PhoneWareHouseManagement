using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for PurchaseOrder.xaml
    /// </summary>
    public partial class PurchaseOrder : Window
    {
        private readonly PhoneWarehouseDbContext context;
        public PurchaseOrder()
        {
            InitializeComponent();
            context = new PhoneWarehouseDbContext();
            Load();
        }
        private void Load()
        {
            lvPurchasesOrder.ItemsSource = context.PurchaseOrders.Include(p => p.Supplier).ToList();
        }

        private void btnSearch_Copy_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDetail_Click(object sender, RoutedEventArgs e)
        {
            var purchasesOrder = (sender as FrameworkElement).DataContext as BusinessObjects.Models.PurchaseOrder;
            if (purchasesOrder != null)
            {
                PurchaseOrderDetails detail = new PurchaseOrderDetails(purchasesOrder);
                detail.ShowDialog();
            }
        }

        private void btnImport_Click(object sender, RoutedEventArgs e)
        {
            Import import = new Import();

            if (import != null)
            {
                this.Close();
                import.Show();
            }
        }
    }
}
