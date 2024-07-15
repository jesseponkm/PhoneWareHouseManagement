using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
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
            var list = new List<Brand>();
            try
            {
                list = context.Brands.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }
        public static Brand GetBrandById(int id)
        {
            return context.Brands.FirstOrDefault(x => x.BrandId == id);
        }
        public static void InsertBrand(Brand brand)
        {
            try
            {
                context.Brands.Add(brand);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void UpdateBrand(Brand brand)
        {
            try
            {
                context.Brands.Update(brand);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void DeleteBrand(Brand brand)
        {
            try
            {
                brand.Status = 0;
                context.Brands.Update(brand);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
