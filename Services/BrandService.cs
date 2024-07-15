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
        private readonly IBrandRepository _brandRepository;
        public BrandService()
        {
            _brandRepository = new BrandRepository();

        }
        void IBrandService.AddBrand(Brand brand)
        {
            _brandRepository.AddBrand(brand);
        }

        void IBrandService.DeleteBrand(Brand brand)
        {
            _brandRepository?.DeleteBrand(brand);
        }

        Brand IBrandService.GetBrandById(int id)
        {
            return _brandRepository.GetBrandById(id);
        }

        List<Brand> IBrandService.GetBrands()
        {
            return _brandRepository.GetBrands();
        }

        void IBrandService.UpdateBrand(Brand brand)
        {
            _brandRepository.UpdateBrand(brand);
        }
    }
}
