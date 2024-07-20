using BusinessObjects.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for Export.xaml
    /// </summary>
    public partial class Export : Window
    {
        List<SalesOrderDetail> salesOrderDetails;
    
        private readonly PhoneWarehouseDbContext context;
        public Export()
        {
            InitializeComponent();
            context = new PhoneWarehouseDbContext();
            
            salesOrderDetails = new List<SalesOrderDetail>();

        }

        private void Load()
        {
            lvExport.ItemsSource = salesOrderDetails.ToList();
            totalPrice.Text = salesOrderDetails.Sum(detail => detail.Price).ToString();
        }

        private void btnAddPhone_Click(object sender, RoutedEventArgs e)
        {
            var add = new AddPhone();
            if (add.ShowDialog() == true)
            {
                var existingDetail = salesOrderDetails.FirstOrDefault(detail => detail.PhoneId == add.sod.PhoneId);

                if (existingDetail != null)
                {
                    // Update existing quantity
                    existingDetail.Quantity += add.sod.Quantity;
                }
                else
                {
                    // Add new entry
                    salesOrderDetails.Add(add.sod);
                }
            }
            
            Load();
        }



        private bool IsValidPhoneNumber(string phoneNumber)
        {
            // Biểu thức chính quy cho số điện thoại Việt Nam
            string pattern = @"^(0|\+84)(\d{9})$";
            return Regex.IsMatch(phoneNumber, pattern);
        }
        private void ShowSalesOrderList()
        {
            var salesOrderWindow = new PhoneWarehouseManagement.Views.SalesOrder();
            salesOrderWindow.Show();

            // Optionally close the current window
            this.Close();
        }

        private void btnExport_Click(object sender, RoutedEventArgs e)
        {
            if (txtName.Text.Trim().IsNullOrEmpty() || !IsValidPhoneNumber(txtPhoneNumber.Text.Trim()))
            {
                MessageBox.Show("Please input Name and valid phone number!");
                return;
            }
            try
            {
                BusinessObjects.Models.SalesOrder salesOrder = new BusinessObjects.Models.SalesOrder();
                salesOrder.CustomerName = txtName.Text.Trim();
                salesOrder.Note = txtNote.Text.Trim();
                salesOrder.PhoneNumber = txtPhoneNumber.Text.Trim();
                salesOrder.TotalPrice = salesOrderDetails.Sum(detail => detail.Price);
                salesOrder.OrderDate = DateTime.Now;
                context.SalesOrders.Add(salesOrder);
                context.SaveChanges();
                var salesOrderId = context.SalesOrders.Max(p => p.SaleOrderId);
                foreach (var detail in salesOrderDetails)
                {
                    detail.SaleOrderId = salesOrderId;
                    Phone phone = context.Phones.FirstOrDefault(p => p.PhoneId == detail.PhoneId);
                    phone.Stock = phone.Stock - detail.Quantity; ;
                    detail.Phone = null;
                    context.SalesOrderDetails.Add(detail);
                    context.Phones.Update(phone);
                    context.SaveChanges();
                }
                MessageBox.Show("Export successfully!");
                
                ShowSalesOrderList();
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
      
            ShowSalesOrderList();
        }

        
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            SalesOrderDetail detail = (sender as FrameworkElement).DataContext as SalesOrderDetail;
            salesOrderDetails.Remove(detail);
            Load();
        }

    }
}
