using BusinessObjects.Models;
using Services;
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
    /// Interaction logic for SelectPhonesWindow.xaml
    /// </summary>
    public partial class SelectPhonesWindow : Window
    {
        private readonly IPhoneService phoneService;
        public List<PurchaseOrderDetail> SelectedPurchaseOrderDetail { get; private set; }
        public List<Phone> AllPhones { get; private set; }
        public List<PurchaseOrderDetail> purchaseOrderDetails { get; private set; }

        public SelectPhonesWindow()
        {
            InitializeComponent();
            SelectedPurchaseOrderDetail = new List<Phone>();
            LoadPhones();
            PhonesDataGrid.ItemsSource = AllPhones;
        }

        private void LoadPhones()
        {
            // Sử dụng IPhoneService để lấy danh sách điện thoại từ cơ sở dữ liệu
            IPhoneService phoneService = new PhoneService();
            var phones = phoneService.GetPhones();
            AllPhones = phones.Select(p => new Phone(p)).ToList();
        }

        private void AddSelectedButton_Click(object sender, RoutedEventArgs e)
        {
            if(grdSelectedPhone.SelectedItem is Phone selected)
            {
                PurchaseOrderDetail detail = new PurchaseOrderDetail();
                detail.Phone
                
            }

            foreach (var phone in AllPhones.Where(p => p.IsSelected))
            {
                SelectedPurchaseOrderDetail.Add(new Phone
                {
                    ModelName = phone.ModelName,
                    Price = phone.Price,
                    Quantity = 1 // hoặc số lượng người dùng nhập vào
                });
            }
            this.DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
