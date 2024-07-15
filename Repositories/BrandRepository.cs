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
        void IBrandRepository.AddBrand(Brand brand)
        {
            BrandDAO.InsertBrand(brand);
        }

        void IBrandRepository.DeleteBrand(Brand brand)
        {
            BrandDAO.DeleteBrand(brand);
        }

        Brand IBrandRepository.GetBrandById(int id)
        {
            return BrandDAO.GetBrandById(id);
        }

        List<Brand> IBrandRepository.GetBrands()
        {
            return BrandDAO.GetBrands();
        }

        void IBrandRepository.UpdateBrand(Brand brand)
        {
            BrandDAO.UpdateBrand(brand);
        }
    }
}
