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

        public void DeletePhone(int phoneId)
        {
            repository.DeletePhone(phoneId);
        }

        public Phone GetPhoneById(int id)
        {
            return repository.GetPhoneById(id);
        }

        public List<Phone> GetPhones()
        {
            return repository.GetPhones();
        }

        public void UpdatePhone(Phone phone)
        {
            repository.UpdatePhone(phone);
        }
    }
}
