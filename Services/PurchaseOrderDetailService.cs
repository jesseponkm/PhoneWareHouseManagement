using BusinessObjects.Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class PurchaseOrderDetailService : IPurchaseOrderDetailService
    {
        private readonly IPurchaseOrderDetailRepository repository;
        public PurchaseOrderDetailService()
        {
            repository = new PurchaseOrderDetailRepository();
        }

        public void Add(PurchaseOrderDetail p)
        {
            repository.Add(p);
        }

        public List<PurchaseOrderDetail> GetAlls(int id)
        {
            return repository.GetAlls(id);
        }
    }
}
