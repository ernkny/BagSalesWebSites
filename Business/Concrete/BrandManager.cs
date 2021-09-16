using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
     public class BrandManager
    {
        IBrandDal _brandDal;
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }
        public void AddBrand(Brand brand)
        {
            _brandDal.Add(brand);
        }
        public List<Brand> GetAllBrand()
        {
            var result = _brandDal.GetAll();
            return result;
        }
        public void DeleteBrand(int id)
        {
            var result = _brandDal.Get(x=>x.Id==id);
            _brandDal.Delete(result);
            
        }
    }
}
