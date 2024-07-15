using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using BusinessObjects.Models;

namespace Repositories
{
    public interface IPhoneRepository
    {
        List<Phone> GetPhones();
        void AddPhone(Phone phone);
        void UpdatePhone(Phone phone);
        void DeletePhone(Phone phone);  
    }
}
