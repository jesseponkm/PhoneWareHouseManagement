using BusinessObjects.Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class PhoneService : IPhoneService
    {
        private readonly IPhoneRepository repository;

        public PhoneService()
        {
            repository = new PhoneRepository();
        }

        public void AddPhone(Phone phone)
        {
            repository.AddPhone(phone);
        }

        public void DeletePhone(Phone phone)
        {
            throw new NotImplementedException();
        }

        public Phone GetPhoneById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Phone> GetPhones()
        {
            throw new NotImplementedException();
        }

        public void UpdatePhone(Phone phone)
        {
            throw new NotImplementedException();
        }
    }
}
