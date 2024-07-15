using BusinessObjects.Models;
using Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class BrandRepository : IBrandRepository
    {
        public void AddBrand(Brand brand)
        {
            BrandDAO.InsertBrand(brand);
        }

        public void DeleteBrand(Brand brand)
        {
            BrandDAO.DeleteBrand(brand);
        }

        public Brand GetBrandById(int id)
        {
            return BrandDAO.GetBrandById(id);
        }

        public List<Brand> GetBrands()
        {
            List<Brand> list = new List<Brand>();
            list = BrandDAO.GetBrands();
            return list;
        }

        public void UpdateBrand(Brand brand)
        {
            BrandDAO.UpdateBrand(brand);
        }
    }
}
