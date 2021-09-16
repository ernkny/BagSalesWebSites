using Business.Cryptograph;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AdminManager
    {
        IAdminDal _adminDal;
        public AdminManager(IAdminDal admindal)
        {
            _adminDal = admindal;
        }
        public bool GetAdmin(Admin admin)
        {
            Md5Crptograph crptograph = new Md5Crptograph();
            string username = crptograph.md5sifreleme(admin.UserName);
            string password = crptograph.md5sifreleme(admin.Password);

            var result= _adminDal.Get(x => x.UserName == username && x.Password==password);
            if (result==null)
            {
                return false;
            }
            else
            {
               return true;
            }
           
        }
    }
}
