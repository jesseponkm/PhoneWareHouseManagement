using BusinessObjects.Models;
using Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class PurchaseOrderRepository : IPurchaseOrderRepository
    {
        public void AddPurchaseOrder(PurchaseOrder purchaseOrder)
        {
            PurchaseOrderDAO.AddPurchaseOrder(purchaseOrder);
        }

        public List<PurchaseOrder> GetPurchaseOrders()
        {
            return PurchaseOrderDAO.GetPurchaseOrders();
        }
    }
}
