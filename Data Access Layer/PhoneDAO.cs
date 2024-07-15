using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace Data_Access_Layer
{
    public class PhoneDAO
    {
        private static PhoneWarehouseDbContext context = new PhoneWarehouseDbContext();
        private PhoneDAO() { }

        public static List<Phone> GetPhones()
        {
            var list = new List<Phone>();
            try
            {
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
            return context.Phones.Include(p => p.Brand).SingleOrDefault( p => p.PhoneId == id && p.Status == 1);
        }

        public static void AddPhone(Phone phone)
        {
            try
            {
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
                phone.Status = 0;
                context.Phones.Update(phone);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);    
            }
        } 
    }
}
