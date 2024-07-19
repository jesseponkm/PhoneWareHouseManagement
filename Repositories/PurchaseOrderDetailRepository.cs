using BusinessObjects.Models;
using Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class PurchaseOrderDetailRepository : IPurchaseOrderDetailRepository
    {
        public void Add(PurchaseOrderDetail p)
        {
            PurchaseOrderDetailDAO.AddOrderDetail(p);
        }

        public List<PurchaseOrderDetail> GetAlls(int id)
        {
            return PurchaseOrderDetailDAO.GetPurchaseOrderDetails(id);
        }
    }
}
