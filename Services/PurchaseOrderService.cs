using BusinessObjects.Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class PurchaseOrderService : IPurchaseOrderService
    {
        private readonly IPurchaseOrderRepository repository;
        public void AddPurchaseOrder(PurchaseOrder purchaseOrder)
        {
            repository.AddPurchaseOrder(purchaseOrder);
        }

        public List<PurchaseOrder> GetPurchaseOrders()
        {
            return repository.GetPurchaseOrders();
        }
    }
}
