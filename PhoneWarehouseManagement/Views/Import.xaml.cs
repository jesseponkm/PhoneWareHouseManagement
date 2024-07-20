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
using System.Windows.Forms.VisualStyles;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Linq;

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
            decimal totalPrice = 0;
            foreach (PurchaseOrderDetail detail in purchaseOrderDetails)
            {
                totalPrice += detail.Price * detail.Quantity;
            }
            tbTotalPrice.Text = totalPrice.ToString();
        }

        private void LoadSuppliers()
        {
            cbbSupplier.ItemsSource = context.Suppliers.ToList();
            cbbSupplier.DisplayMemberPath = "SupplierName";
            cbbSupplier.SelectedValuePath = "SupplierId";
            cbbSupplier.SelectedIndex = 0;
            
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
            try
            {
                BusinessObjects.Models.PurchaseOrder purchasesOrder = new BusinessObjects.Models.PurchaseOrder();
                purchasesOrder.SupplierId = int.Parse(cbbSupplier.SelectedValue.ToString());
                purchasesOrder.TotalAmount = decimal.Parse(tbTotalPrice.Text.Trim());  
                purchasesOrder.OrderDate = DateTime.Now;
                context.PurchaseOrders.Add(purchasesOrder);
                context.SaveChanges();
                var maxId = context.PurchaseOrders.Max(p => p.OrderId);
                foreach (var detail in purchaseOrderDetails)
                {
                    detail.OrderId = maxId;
                    detail.Phone = null;
                    context.PurchaseOrderDetails.Add(detail);
                    context.SaveChanges();
                }
                MessageBox.Show("Import successfully!");

                ShowPurchaseOrderList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            PurchaseOrderDetail detail = (sender as FrameworkElement).DataContext as PurchaseOrderDetail;
            purchaseOrderDetails.Remove(detail);
            load();
        }

        private void ShowPurchaseOrderList()
        {
            var purchaseOrdersWindow = new PhoneWarehouseManagement.Views.PurchaseOrder();
            purchaseOrdersWindow.Show();
            this.Close();
        }
    }
}
