using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer
{
    public class PurchaseOrderDAO
    {
        private PurchaseOrderDAO() { }
        public static List<PurchaseOrder> GetPurchaseOrders()
        {
            var list = new List<PurchaseOrder>();
            try
            {
                using var context = new PhoneWarehouseDbContext();
                list = context.PurchaseOrders.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }
        public static List<PurchaseOrder> GetPurchaseOrderBySupplier(int supplierId)
        {
            var list = new List<PurchaseOrder>();
            try
            {
                using var context = new PhoneWarehouseDbContext();
                list = context.PurchaseOrders.Where(p => p.SupplierId == supplierId).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }
        public static void AddPurchaseOrder(PurchaseOrder purchaseOrder)
        {
            try
            {
                using var context = new PhoneWarehouseDbContext();
                context.PurchaseOrders.Add(purchaseOrder);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
