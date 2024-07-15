﻿using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IBrandRepository
    {
        List<Brand> GetBrands();
        void UpdateBrand(Brand brand);
        void DeleteBrand(Brand brand);
        void AddBrand(Brand brand);
        Brand GetBrandById(int id);
    }
}
