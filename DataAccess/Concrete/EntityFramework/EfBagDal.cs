
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBagDal: EfEntityRepositoryBase<Bag, BangThisBagContext>, IBagDal
    {

        public List<BagDto> GetBagDetail()
        {
            using (BangThisBagContext context= new BangThisBagContext())
            {
                var result = from b in context.Bags
                             join d in context.ImageBags
                             on b.Id equals d.BagId
                             select new BagDto
                             {
                                 Id = b.Id,
                                 Model = b.Model,
                                 Title = b.Title,
                                 Price = b.Price,
                                 Description = b.Description,
                                 Keywords=b.Keywords,
                                 InStock=b.InStock,
                                 ImageUrl = d.ImageUrl
                             };
                return result.ToList();
            }
        }
    }
}
