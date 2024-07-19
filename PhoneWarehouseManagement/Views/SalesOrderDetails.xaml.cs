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
using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;

namespace PhoneWarehouseManagement.Views
{
    /// <summary>
    /// Interaction logic for SalesOrderDetails.xaml
    /// </summary>
    public partial class SalesOrderDetails : Window
    {
        private BusinessObjects.Models.SalesOrder _salesOrder;
        private readonly PhoneWarehouseDbContext context;
        public SalesOrderDetails(BusinessObjects.Models.SalesOrder salesOrder)
        {
            InitializeComponent();
            context = new PhoneWarehouseDbContext();
            _salesOrder = salesOrder;
            Load();
        }

        public void Load()
        {
            lvDetail.ItemsSource = context.SalesOrderDetails.Include(p => p.Phone).Where(p => p.SaleOrderId == _salesOrder.SaleOrderId).ToList();
        }
    }
}
