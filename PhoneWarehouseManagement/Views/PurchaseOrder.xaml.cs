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
    public partial class PurchaseOrder : Window
    {
        public List<Phone> SelectedPhones { get; set; }

        public PurchaseOrder()
        {
            InitializeComponent();
            SelectedPhones = new List<Phone>();
            PhonesDataGrid.ItemsSource = SelectedPhones;
            LoadSuppliers();
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
                foreach (var phone in selectPhonesWindow.SelectedPurchaseOrderDetail)
                {
                    SelectedPhones.Add(phone);
                }
                PhonesDataGrid.Items.Refresh();
                UpdateTotalAmount();
            }
        }

        private void UpdateTotalAmount()
        {
            decimal totalAmount = 0;
            foreach (var phone in SelectedPhones)
            {
                totalAmount += phone.Price * phone.Quantity;
            }
            TotalAmountTextBlock.Text = totalAmount.ToString("C");
        }
    }
}
