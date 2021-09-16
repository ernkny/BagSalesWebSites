using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class ImageBag:IEntity
    {
        
        public int Id { get; set; }
     
        public string ImageUrl { get; set; }
        public string DeleteUrl { get; set; }
        [ForeignKey("Bag")]
        public int? BagId { get; set; }
        public Bag Bag { get; set; }
            
    }
}
