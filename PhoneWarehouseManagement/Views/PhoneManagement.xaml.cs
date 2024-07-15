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
using BusinessObjects;
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
        public void LoadPhone()
        {
            grdPhone.ItemsSource = phoneService.GetPhones();
        }
        public void LoadBrand()
        {
            cboBrand.ItemsSource = brandService.GetBrands().ToList();
            cboBrand.SelectedIndex = 0;
        }
    }
}
