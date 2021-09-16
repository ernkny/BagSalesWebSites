using Business.Validators.FluentValidation;
using DataAccess.Abstract;
using Entities.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ContactManager
    {
        IContactDal _contactDal;
        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public bool AddContact(Contact contact)
        {
            ContactValidator validationRules = new ContactValidator();
            ValidationResult result = validationRules.Validate(contact);
            if (result.IsValid)
            {
                _contactDal.Add(contact);
                return true;
            }
            else
            {
                return false;
            }
            

        }
        public void ContactDelete(Contact contact)
        {
            _contactDal.Delete(contact);
                
        }

        public List<Contact>GetAllContacts()
        {
            var result = _contactDal.GetAll();
            return result;
        }
        public Contact GetContact(int id)
        {
            var result = _contactDal.Get(x=>x.Id==id);
            return result;
        }

    }
}
