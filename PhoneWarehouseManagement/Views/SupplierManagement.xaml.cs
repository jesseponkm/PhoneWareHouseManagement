using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using Data_Access_Layer;

namespace PhoneWarehouseManagement.Views
{
    /// <summary>
    /// Interaction logic for SupplierManagement.xaml
    /// </summary>
    public partial class SupplierManagement : Window
    {
        private readonly PhoneWarehouseDbContext context;
        public SupplierManagement()
        {
            InitializeComponent();
            context = new PhoneWarehouseDbContext();
            LoadSupplier();
        }

        private void LoadSupplier()
        {
            grdSuplier.ItemsSource = context.Suppliers.ToList();
        }

        private void grdSuplier_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(grdSuplier.SelectedItem is Supplier supplier)
            {
                txtId.Text = supplier.SupplierId.ToString();
                txtName.Text = supplier.SupplierName;
                txtContactName.Text = supplier.ContactName;
                txtPhone.Text = supplier.Phone;
                txtEmail.Text = supplier.Email;
                txtAddress.Text = supplier.Address;
            }

        }
        private bool IsValidPhoneNumber(string phoneNumber)
        {
            // Biểu thức chính quy cho số điện thoại Việt Nam
            string pattern = @"^(0|\+84)(\d{9})$";
            return Regex.IsMatch(phoneNumber, pattern);
        }

        // Phương thức kiểm tra định dạng email
        private bool IsValidEmail(string email)
        {
            // Biểu thức chính quy cho email
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
