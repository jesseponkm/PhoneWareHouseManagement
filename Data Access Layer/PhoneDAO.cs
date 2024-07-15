using BusinessObjects.Models;
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
                list = context.Phones.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
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
                Phone p = context.Phones.FirstOrDefault(o => o.PhoneId == phone.PhoneId);
                if (p != null)
                {
                    p.Status = false;
                    context.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);    
            }
        } 
    }
}
