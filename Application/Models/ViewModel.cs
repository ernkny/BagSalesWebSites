using Entities.Concrete;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Application.Models
{
    public class ViewModel
    {
       public Bag IEnumBag { get; set; }
        public IEnumerable<ImageBag> IEnumImageBag{ get; set; }
        public IPagedList<Bag> PagedlistBag { get; set; }
        public List<string> IamgeUrls { get; set; }
        public List<string> categories { get; set; }
    }
    
}