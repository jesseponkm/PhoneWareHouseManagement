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
            cboBrand.ItemsSource = brandService.GetBrands();
        }
        private void Clear()
        {
            txtId.Text = string.Empty;
            txtModelName.Text = string.Empty;
            txtDescription.Text = string.Empty ;
            txtPrice.Text = string.Empty;
            txtStock.Text = string.Empty;
            cboBrand.SelectedValue = null;
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
                cboBrand.SelectedValue = phone.Brand.BrandId;
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            Clear();
        }
    }
}
