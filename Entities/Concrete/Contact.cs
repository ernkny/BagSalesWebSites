using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Contact:IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string  SurName { get; set; }
        public string Email { get; set; }
        public string  Country { get; set; }
        public string Address { get; set; }
        public string Messages { get; set; }
        public DateTime? Date { get; set; }
    }
}
