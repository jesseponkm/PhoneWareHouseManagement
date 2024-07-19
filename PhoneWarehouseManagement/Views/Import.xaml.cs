using BusinessObjects.Models;
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
    public partial class Import : Window
    {
        private PurchaseOrder po;
        List<PurchaseOrderDetail> purchaseOrderDetails;
        private readonly PhoneWarehouseDbContext context;

        public Import()
        {
            InitializeComponent();
            context = new PhoneWarehouseDbContext();
            PurchaseOrder po = new PurchaseOrder();
            purchaseOrderDetails = new List<PurchaseOrderDetail>();
            load();
            LoadSuppliers();
        }

        private void load()
        {
            grdImportOrder.ItemsSource = purchaseOrderDetails.ToList();
        }

        private void LoadSuppliers()
        {
            // Logic để load danh sách nhà cung cấp vào SupplierComboBox từ cơ sở dữ liệu
        }

        private void SelectPhonesButton_Click(object sender, RoutedEventArgs e)
        {
            var selectPhonesWindow = new SelectPhonesWindow();
            if (selectPhonesWindow.ShowDialog() == true)
            {
                var existingDetail = purchaseOrderDetails.FirstOrDefault(detail => detail.PhoneId == selectPhonesWindow.pod.PhoneId);

                if (existingDetail != null)
                {
                    existingDetail.Quantity += selectPhonesWindow.pod.Quantity;
                }
                else
                {
                    purchaseOrderDetails.Add(selectPhonesWindow.pod);
                }
            }
            load();
        }

        private void btnSaveOrder_Click(object sender, RoutedEventArgs e)
        {
            PurchaseOrder po = new PurchaseOrder();
            foreach (var detail in purchaseOrderDetails)
            {

            }
        }
    }
}
