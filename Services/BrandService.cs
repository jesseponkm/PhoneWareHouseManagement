using BusinessObjects.Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository brandRepository;
        public BrandService()
        {
            brandRepository = new BrandRepository();

        }

        public void AddBrand(Brand brand)
        {
            brandRepository.AddBrand(brand);
        }

        public void DeleteBrand(Brand brand)
        {
            brandRepository.DeleteBrand(brand);
        }

        public Brand GetBrandById(int id)
        {
            return brandRepository.GetBrandById(id);
        }

        public List<Brand> GetBrands()
        {
            return brandRepository.GetBrands();
        }

        public void UpdateBrand(Brand brand)
        {
            brandRepository.UpdateBrand(brand);
        }
    }
}
