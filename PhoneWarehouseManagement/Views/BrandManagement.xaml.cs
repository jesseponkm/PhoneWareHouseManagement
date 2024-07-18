using BusinessObjects.Models;
using Services;
using System.Windows;
using System.Windows.Controls;

namespace PhoneWarehouseManagement.Views
{
    /// <summary>
    /// Interaction logic for BrandManagement.xaml
    /// </summary>
    public partial class BrandManagement : Window
    {
        private readonly IBrandService brandService;
        public BrandManagement()
        {
            InitializeComponent();
            brandService = new BrandService();
            loadBrand();

        }
        public void loadBrand()
        {
            grdBrand.ItemsSource = brandService.GetBrands();
        }

        private void grdBrand_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (grdBrand.SelectedItem is Brand selected)
            {
                txtBrandId.Text = selected.BrandId.ToString();
                txtBrandName.Text = selected.BrandName.ToString();
            }
        }
    }
}
