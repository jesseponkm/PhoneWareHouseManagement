using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
using Services;
using BusinessObjects.Models;
using Microsoft.IdentityModel.Tokens;

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

            var filterBrands = new List<Brand>();
            filterBrands.Add(new Brand {BrandId = -1, BrandName = "All", Phones = phoneService.GetPhones()});
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
            txtDescription.Text = string.Empty ;
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
                cboBrand.SelectedValue = phone.BrandId ;
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

                phone.ModelName = txtModelName.Text;
                phone.Description = txtDescription.Text;
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

                phone.ModelName = txtModelName.Text;
                phone.Description = txtDescription.Text;
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
            if(filterByBrand.SelectedItem is Brand brand)
            {
                grdPhone.ItemsSource = brand.Phones.ToList();
            } else
            {
                LoadPhone();
            }

        }
    }
}
