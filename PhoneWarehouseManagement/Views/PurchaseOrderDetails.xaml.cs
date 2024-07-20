using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
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
    /// Interaction logic for PurchaseOrderDetails.xaml
    /// </summary>
    public partial class PurchaseOrderDetails : Window
    {
        private BusinessObjects.Models.PurchaseOrder _purchasesOrder;
        private readonly PhoneWarehouseDbContext context;
        public PurchaseOrderDetails(BusinessObjects.Models.PurchaseOrder purchasesOrder)
        {
            InitializeComponent();
            context = new PhoneWarehouseDbContext();
            _purchasesOrder = purchasesOrder;
            Load();
        }

        public void Load()
        {
            lvDetail.ItemsSource = context.PurchaseOrderDetails.Include(p => p.Phone).Where(p => p.OrderId == _purchasesOrder.OrderId).ToList();
        }
    }
}
