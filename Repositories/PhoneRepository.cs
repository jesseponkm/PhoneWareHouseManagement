using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Access_Layer;

namespace Repositories
{
    public class PhoneRepository : IPhoneRepository
    {
        
        public void AddPhone(Phone phone)
        {
           PhoneDAO.AddPhone(phone);
        }

        public void DeletePhone(int phoneId)
        {
            PhoneDAO.DeletePhone(phoneId);
        }

        public Phone GetPhoneById(int id)
        {
            return PhoneDAO.GetPhoneById(id);
        }

        public List<Phone> GetPhones()
        {
            return PhoneDAO.GetPhones();
        }

        public void UpdatePhone(Phone phone)
        {
            PhoneDAO.UpdatePhone(phone); 
        }
    }
}
