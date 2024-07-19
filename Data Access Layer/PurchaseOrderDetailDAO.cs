using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer
{
    public class PurchaseOrderDetailDAO
    {
        private PurchaseOrderDetailDAO() { }
        public static List<PurchaseOrderDetail> GetPurchaseOrderDetails(int purchaseOrderId)
        {
            var list = new List<PurchaseOrderDetail>();
            try
            {
                using var context = new PhoneWarehouseDbContext();
                list = context.PurchaseOrderDetails.Where(p => p.OrderId == purchaseOrderId).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }
        public static void AddOrderDetail(PurchaseOrderDetail purchaseOrderDetail)
        {
            try
            {
                using var context = new PhoneWarehouseDbContext();
                context.PurchaseOrderDetails.Add(purchaseOrderDetail);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
