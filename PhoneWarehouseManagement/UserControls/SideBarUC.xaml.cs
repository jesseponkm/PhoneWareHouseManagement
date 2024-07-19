using PhoneWarehouseManagement.Views;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PhoneWarehouseManagement.UserControls
{
    /// <summary>
    /// Interaction logic for SideBarUC.xaml
    /// </summary>
    public partial class SideBarUC : UserControl
    {
        public SideBarUC()
        {
            InitializeComponent();
        }

        private void btnPhone_Click(object sender, RoutedEventArgs e)
        {
            PhoneManagement p = new PhoneManagement();
            p.Show();
            Window window = Window.GetWindow(this);
            if (window != null)
            {
                window.Close();
            }
        }

        private void btnSupplier_Click(object sender, RoutedEventArgs e)
        {
            SupplierManagement suplierManagement = new SupplierManagement();
            suplierManagement.Show();
            Window window = Window.GetWindow(this);
            if (window != null)
            {
                window.Close();
            }
        }

        private void btnOrder_Click(object sender, RoutedEventArgs e)
        {
            SalesOrder orderManagement = new SalesOrder();
            orderManagement.Show();
            Window window = Window.GetWindow(this);
            if(window != null)
            {
                window.Close();
            }
        }
    }
}
