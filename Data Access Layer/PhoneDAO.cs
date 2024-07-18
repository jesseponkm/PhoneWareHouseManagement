using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace Data_Access_Layer
{
    public class PhoneDAO
    {
        
        private PhoneDAO() { }

        public static List<Phone> GetPhones()
        {
            var list = new List<Phone>();
            try
            {
                using var context = new PhoneWarehouseDbContext();
                list = context.Phones.Include(p => p.Brand).Where(p => p.Status == 1).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }

        public static Phone GetPhoneById(int id)
        {
            using var context = new PhoneWarehouseDbContext();
            return context.Phones.Include(p => p.Brand).SingleOrDefault( p => p.PhoneId == id && p.Status == 1);
        }

        public static void AddPhone(Phone phone)
        {
            try
            {
                using var context = new PhoneWarehouseDbContext();
                context.Phones.Add(phone);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public static void UpdatePhone(Phone phone)
        {
            try
            {
                using var context = new PhoneWarehouseDbContext();
                phone.Status = 1;
                context.Phones.Update(phone);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeletePhone(Phone phone)
        {
            try
            {
                using var context = new PhoneWarehouseDbContext();
                phone.Status = 0;
                context.Phones.Update(phone);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

       

    }
}
