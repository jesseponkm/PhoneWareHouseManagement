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
    /// Interaction logic for SalesOrder.xaml
    /// </summary>
    public partial class SalesOrder : Window
    {
        public SalesOrder()
        {
            InitializeComponent();
        }

        private void btnSearch_Copy_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Export_Click(object sender, RoutedEventArgs e)
        {
            Export export = new Export();
            
            if(export != null)
            {
                this.Close();
                export.Show();
            }
        }
    }
}
