using BusinessObjects.Models;
using Microsoft.IdentityModel.Tokens;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

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
            grdSuplier.ItemsSource = context.Suppliers.Where(p => p.Status == 1).ToList();
        }

        private void grdSuplier_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (grdSuplier.SelectedItem is Supplier supplier)
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

            if (txtName.Text.Trim().IsNullOrEmpty())
            {
                MessageBox.Show("Please input name!");
                txtName.Focus();
               
                return;
            }
            if (!IsValidPhoneNumber(txtPhone.Text.Trim()))
            {
                MessageBox.Show("Please input valid phone number!");
                txtPhone.Focus();
                
                return;
            }
            if (!IsValidEmail(txtEmail.Text.Trim()))
            {
                MessageBox.Show("Please input valid email!");
                txtEmail.Focus();
              
                return;
            }
            Supplier sp = new Supplier();
            sp.SupplierName = txtName.Text.Trim();
            sp.ContactName = txtContactName.Text.Trim();
            sp.Phone = txtPhone.Text.Trim();
            sp.Email = txtEmail.Text.Trim();
            sp.Address = txtAddress.Text.Trim();
            sp.Status = 1;
            try
            {
                context.Suppliers.Add(sp);
                if (context.SaveChanges() > 0)
                {
                    MessageBox.Show("Added successfully!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            LoadSupplier();


        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtId.Text = string.Empty;
            txtName.Text = string.Empty;
            txtContactName.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtAddress.Text = string.Empty;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (txtId.Text.IsNullOrEmpty())
            {
                MessageBox.Show("Please choose a supplier to update!");
                return;
            }
            if (txtName.Text.Trim().IsNullOrEmpty())
            {
                MessageBox.Show("Please input name!");
                txtName.Focus();
                return;
            }
            if (!IsValidPhoneNumber(txtPhone.Text.Trim()))
            {
                MessageBox.Show("Please input a valid phone number!");
                txtPhone.Focus();
                return;
            }
            if (!IsValidEmail(txtEmail.Text.Trim()))
            {
                MessageBox.Show("Please input a valid email!");
                txtEmail.Focus();
                return;
            }

           
            int supplierId = int.Parse(txtId.Text);
            Supplier existingSupplier = context.Suppliers.FirstOrDefault(s => s.SupplierId == supplierId);

            if (existingSupplier != null)
            {
               
                existingSupplier.SupplierName = txtName.Text.Trim();
                existingSupplier.ContactName = txtContactName.Text.Trim();
                existingSupplier.Phone = txtPhone.Text.Trim();
                existingSupplier.Email = txtEmail.Text.Trim();
                existingSupplier.Address = txtAddress.Text.Trim();
                existingSupplier.Status = 1;

                try
                {
                    
                    if (context.SaveChanges() > 0)
                    {
                        LoadSupplier();
                        MessageBox.Show("Updated successfully!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure to delete this supplier?","Confirm" ,MessageBoxButton.YesNo, MessageBoxImage.Information);
            if(result == MessageBoxResult.Yes)
            {
                Supplier sp = context.Suppliers.FirstOrDefault(p => p.SupplierId == int.Parse(txtId.Text));
                if(sp != null)
                {
                    sp.Status = 0;
                    try
                    {
                        context.Suppliers.Update(sp);
                        if (context.SaveChanges() > 0)
                        {
                            LoadSupplier();
                            MessageBox.Show("Deleted successfully!");
                        }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                   
                }
                
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            grdSuplier.ItemsSource = context.Suppliers.Where(p => p.Status == 1 && (p.SupplierName.ToLower().Contains(txtSearch.Text.Trim().ToLower()) ||
            p.ContactName.ToLower().Contains(txtSearch.Text.Trim().ToLower()) || p.Email.ToLower().Contains(txtSearch.Text.Trim().ToLower()) ||
            p.Phone.ToLower().Contains(txtSearch.Text.Trim().ToLower())
            )).ToList();
        }
    }
}
