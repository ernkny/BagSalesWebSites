using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class BangThisBagContext:DbContext
    {
        
        public BangThisBagContext():base("BangThisBagCon")
        {
            
        }
       
        public DbSet<Bag> Bags { get; set; }
        public DbSet<ImageBag> ImageBags { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Admin> admins { get; set; }
    }
}
