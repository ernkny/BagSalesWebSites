using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Entities.Dto_s
{
    public class BagDto
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Title { get; set; }
        [AllowHtml]
        public string Description { get; set; }
        public string Price  { get; set; }
        public string Keywords { get; set; }
        public string ImageUrl { get; set; }
        public bool? InStock { get; set; }

    }
}
