using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer
{
    public class BrandDAO
    {
        private static PhoneWarehouseDbContext context = new PhoneWarehouseDbContext();
        private BrandDAO() { }
        public static List<Brand> GetBrands()
        {
            var brands = new List<Brand>();
            try
            {
                brands = context.Brands.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return brands;
        }
    }
}
