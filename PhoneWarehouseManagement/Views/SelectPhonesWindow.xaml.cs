using BusinessObjects.Models;
using Microsoft.IdentityModel.Tokens;
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
        private readonly IBrandService brandService;
        public PurchaseOrderDetail pod;
        public SelectPhonesWindow()
        {
            InitializeComponent();
            phoneService = new PhoneService();
            brandService = new BrandService();
            LoadPhone();
            LoadFilterBrand();
        }
        private void LoadPhone()
        {
            grdPhone.ItemsSource = phoneService.GetPhones();
        }

        private void grdPhone_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (grdPhone.SelectedItem is Phone phone)
            {
                txtId.Text = phone.PhoneId.ToString();
            }
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

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (txtId.Text.Trim().IsNullOrEmpty())
            {
                MessageBox.Show("Please choose a product!");
                return;
            }
            if (!txtQuantity.Text.Trim().IsNullOrEmpty())
            {
                if (int.TryParse(txtQuantity.Text.Trim(), out int quantity))
                {
                    if (grdPhone.SelectedItem is Phone phone)
                    {
                        var newPod = new PurchaseOrderDetail
                        {
                            Quantity = quantity,
                            Price = phone.Price,
                            PhoneId = phone.PhoneId,
                            Phone = phone
                        };
                        pod = newPod; // Set the new SalesOrderDetail
                        this.DialogResult = true;
                    }
                }
            }
            else
            {
                MessageBox.Show("Please input the quantity of product that want to export!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;

        }

    }
}
