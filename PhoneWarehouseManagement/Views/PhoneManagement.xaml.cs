using BusinessObjects.Models;
using Microsoft.IdentityModel.Tokens;
using Services;
using System.Windows;
using System.Windows.Controls;
using static System.Net.Mime.MediaTypeNames;

namespace PhoneWarehouseManagement.Views
{
    /// <summary>
    /// Interaction logic for PhoneManagement.xaml
    /// </summary>
    public partial class PhoneManagement : Window
    {
        private readonly IPhoneService phoneService;
        private readonly IBrandService brandService;

        public PhoneManagement()
        {
            InitializeComponent();
            phoneService = new PhoneService();
            brandService = new BrandService();
            LoadPhone();
            LoadBrand();
            LoadFilterBrand();
        }

        private void LoadPhone()
        {
            grdPhone.ItemsSource = phoneService.GetPhones();
        }

        private void LoadBrand()
        {
            var brands = brandService.GetBrands().ToList();
            cboBrand.ItemsSource = brands;
            cboBrand.DisplayMemberPath = "BrandName";
            cboBrand.SelectedValuePath = "BrandId";
            cboBrand.SelectedIndex = 0;
        }

        private void LoadFilterBrand()
        {
            var brands = brandService.GetBrands().ToList();
            var filterBrands = new List<Brand>();
            filterBrands.Add(new Brand { BrandId = -1, BrandName = "All", Phones = phoneService.GetPhones() });
            filterBrands.AddRange(brands);
            filterByBrand.ItemsSource = filterBrands;
            filterByBrand.DisplayMemberPath = "BrandName";
            filterByBrand.SelectedValuePath = "BrandId";
            filterByBrand.SelectedIndex = 0;
        }
        private void Clear()
        {
            txtId.Text = string.Empty;
            txtModelName.Text = string.Empty;
            txtDescription.Text = string.Empty;
            txtPrice.Text = string.Empty;
            txtStock.Text = string.Empty;
            cboBrand.SelectedIndex = 0;
        }

        private void grdPhone_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (grdPhone.SelectedItem is Phone phone)
            {
                txtId.Text = phone.PhoneId.ToString();
                txtModelName.Text = phone.ModelName;
                txtDescription.Text = phone.Description;
                txtPrice.Text = phone.Price.ToString();
                txtStock.Text = phone.Stock.ToString();
                cboBrand.SelectedValue = phone.BrandId;
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            Clear();
        }


        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                Phone phone = new Phone();
                if (txtModelName.Text.Trim().IsNullOrEmpty())
                {
                    MessageBox.Show("Model Name can not be blank or empty!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (!decimal.TryParse(txtPrice.Text, out decimal price))
                {
                    MessageBox.Show("Invalid price!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    txtPrice.Text = string.Empty;
                    txtPrice.Focus();
                    return;
                }
                if (!int.TryParse(txtStock.Text, out int stock))
                {
                    MessageBox.Show("Invalid stock!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    txtStock.Text = string.Empty;
                    txtStock.Focus();
                    return;
                }

                phone.ModelName = txtModelName.Text.Trim();
                phone.Price = price;
                phone.Stock = stock;

                phone.Description = txtDescription.Text.Trim();
                phone.BrandId = int.Parse(cboBrand.SelectedValue.ToString());
                phoneService.AddPhone(phone);
                LoadPhone();
                MessageBox.Show("Add phone successfully!", "Infor", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (!txtId.Text.Trim().IsNullOrEmpty())
            {
                MessageBoxResult result = MessageBox.Show(
                "Are you sure you want to delete this item?",
                "Confirmation",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question
                );
                if (result == MessageBoxResult.Yes)
                {
                    phoneService.DeletePhone(int.Parse(txtId.Text));
                    Clear();
                    LoadPhone();
                    MessageBox.Show("Delete successfully!");
                }
            }
            
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtId.Text.IsNullOrEmpty())
                {
                    MessageBox.Show("Please choose a phone!", "Infor", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }

                Phone phone = new Phone();
                phone.PhoneId = int.Parse(txtId.Text);
                if (decimal.TryParse(txtPrice.Text, out decimal price))
                {
                    phone.Price = price;
                }
                else
                {
                    MessageBox.Show("Invalid price!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    txtPrice.Text = string.Empty;
                    txtPrice.Focus();
                    return;
                }

                if (int.TryParse(txtStock.Text, out int stock))
                {
                    phone.Stock = stock;
                }
                else
                {
                    MessageBox.Show("Invalid stock!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    txtStock.Text = string.Empty;
                    txtStock.Focus();
                    return;
                }

                phone.ModelName = txtModelName.Text.Trim();
                phone.Description = txtDescription.Text.Trim();
                phone.BrandId = int.Parse(cboBrand.SelectedValue.ToString());
                phoneService.UpdatePhone(phone);
                LoadPhone();
                MessageBox.Show("Update phone successfully!", "Infor", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void filterByBrand_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (filterByBrand.SelectedItem is Brand brand)
            {
                grdPhone.ItemsSource = brand.Phones.Where(p => p.Status == 1 && p.ModelName.ToLower().Contains(txtSearch.Text.Trim().ToLower())).ToList();
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            if (filterByBrand.SelectedItem is Brand brand)
            {
                if (brand.BrandId != -1)
                    grdPhone.ItemsSource = brand.Phones.Where(p => p.Status == 1 && p.ModelName.ToLower().Contains(txtSearch.Text.Trim().ToLower())).ToList();
                else
                {
                    grdPhone.ItemsSource = phoneService.GetPhones().Where(p => p.Status == 1 && p.ModelName.ToLower().Contains(txtSearch.Text.Trim().ToLower()));
                }
            }
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            txtSearch.Text = string.Empty;
            LoadFilterBrand();
            LoadPhone();

        }
    }
}
