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
    /// Interaction logic for Export.xaml
    /// </summary>
    public partial class Export : Window
    {
        List<SalesOrderDetail> salesOrderDetails;
        private SalesOrder so;
        private readonly PhoneWarehouseDbContext context;
        public Export()
        {
            InitializeComponent();
            context = new PhoneWarehouseDbContext();
            SalesOrder so = new SalesOrder();
            salesOrderDetails = new List<SalesOrderDetail>();

        }

        private void Load()
        {
            lvExport.ItemsSource = salesOrderDetails.ToList();
        }

        private void btnAddPhone_Click(object sender, RoutedEventArgs e)
        {
            var add = new AddPhone();
            if (add.ShowDialog() == true)
            {
                var existingDetail = salesOrderDetails.FirstOrDefault(detail => detail.PhoneId == add.sod.PhoneId);

                if (existingDetail != null)
                {
                    // Update existing quantity
                    existingDetail.Quantity += add.sod.Quantity;
                }
                else
                {
                    // Add new entry
                    salesOrderDetails.Add(add.sod);
                }
            }
            Load();
        }


        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            Load();
        }
    }
}
