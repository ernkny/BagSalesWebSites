using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;


namespace Business.Upload
{
    public class ImagesUpload
    {
       
        
        public ImagesUpload()
        {

        }
      
        public List<ImageBag> ServerImageUpload( List<HttpPostedFileBase> _files)
        {
            List<ImageBag> ImagesBag = new List<ImageBag>();
            foreach (var file in _files)
            {
                if (file.ContentLength > 0 && file != null)
                {
                    var extensiton = Path.GetExtension(file.FileName.ToLower());
                    
                    if (extensiton == ".png" || extensiton == ".jpg"  || extensiton == ".jpeg" )
                    {
                        ImageBag imagebag = new ImageBag();
                        string guid = Guid.NewGuid().ToString();

                        string pathway = Path.Combine(HttpContext.Current.Server.MapPath("~/Images/Bags/"), Path.GetFileName(guid + extensiton));
                        file.SaveAs(pathway);
                        string pathImage = "/Images/Bags/" + guid + extensiton;
                        imagebag.ImageUrl = pathImage;
                        imagebag.DeleteUrl = pathway;
                        ImagesBag.Add(imagebag);
                        

                    }
                    
               

                }
                
               
            }
            return ImagesBag;
        }

        public bool DeleteImages(List<ImageBag> deletePaths)
        {
            try
            {
                foreach (var item in deletePaths)
                {
                    string deleteurl = item.DeleteUrl;
                    System.IO.File.Delete(deleteurl);

                }
            }
            catch (Exception)
            {

                return false;
            }
         
            return true;
        }
    }
}
