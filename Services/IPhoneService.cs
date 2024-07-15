using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects.Models;

namespace Services
{
    public interface IPhoneService
    {
        List<Phone> GetPhones();
        Phone GetPhoneById(int id);
        void AddPhone(Phone phone);
        void UpdatePhone(Phone phone);
        void DeletePhone(Phone phone);
    }
}
