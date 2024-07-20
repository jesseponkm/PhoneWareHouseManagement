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

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            refresh();
        }
        private void refresh()
        {
            txtBrandId.Text = "";
            txtBrandName.Text = "";
            loadBrand();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (txtBrandName.Text != null)
            {
                Brand brand = new Brand();
                brand.BrandName = txtBrandName.Text;
                brandService.AddBrand(brand);
            } else
            {
                MessageBox.Show("BrandName not null");
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (grdBrand.SelectedItem is Brand selected)
            {
                selected.BrandName = txtBrandName.Text;
                brandService.UpdateBrand(selected);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (grdBrand.SelectedItem is Brand selected)
            {
                selected.Status = 0;
                brandService.UpdateBrand(selected);
            }
        }
    }
}
