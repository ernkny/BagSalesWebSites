using Business.Upload;
using Business.Validators.FluentValidation;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.Dto_s;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Business.Concrete
{
    public class BagManager
    {
        IBagDal _bagDal;
        public BagManager(IBagDal bagDal)
        {
            _bagDal = bagDal;
            
        }
        public List<string> AddBag(Bag bag, List<HttpPostedFileBase> files)
        {
            List<string> messages=new List<string>();
            BagValidator validationRules = new BagValidator();
            
            ValidationResult result = validationRules.Validate(bag);
            if (result.IsValid && files.Count==4 && 0<files.Count)
            {
                
                ImagesUpload upload = new ImagesUpload();
                var ımages= upload.ServerImageUpload(files);
                bag.ImageBags = new List<ImageBag>();
                bag.ImageBags.AddRange(ımages);
                bag.ImageUrl = ımages.First().ImageUrl;
                _bagDal.Add(bag);
                messages.Add("Ürün Eklendi!");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    messages.Add(item.ErrorMessage);
                }
                if (files.Count !=4)
                {
                    messages.Add("4 Resim Eklenmeli. Lütfen Ürün Resmi Ekleyiniz! ");
                }
                
            }
            
            return messages;
        }
        public List<Bag> GetAllBags()
        {

            return _bagDal.GetAll();
        }

        public Bag GetBagById(int id)
        {
            var result = _bagDal.Get(x => x.Id == id);
            return result;
        }
        public bool DeleteBag(int id)
        {
            
            var result=_bagDal.Get(x => x.Id == id);
            EfBagImagesDal efBagImagesDal = new EfBagImagesDal(); ;
            ImagesUpload ımagesUpload = new ImagesUpload();
            var ımageDelete= efBagImagesDal.GetAll().Where(x=>x.BagId==id);
            var ımageDeleteControl = ımagesUpload.DeleteImages(ımageDelete.ToList());
            if (ımageDeleteControl)
            {
                foreach (var item in ımageDelete)
                {
                    efBagImagesDal.Delete(item);
                }

                _bagDal.Delete(result);
                return true;
            }
            return false;
        }

        public void UpdateBag(Bag bag)
        {
            var result=_bagDal.Get(x => x.Id == bag.Id);
            if (String.IsNullOrEmpty(bag.ImageUrl))
            {
                bag.ImageUrl = result.ImageUrl;
            }
            if (bag.Date.ToString()== "1.01.0001 00:00:00")
            {
                bag.Date = result.Date;
            }

            _bagDal.Update(bag);
        }

        public List<BagDto> DetailBag(int id)
        {
            var result=_bagDal.GetBagDetail().Where(x => x.Id == id).ToList();
            return result;
        }

        #region Control-Validate Operations
        public bool ControlImagesCount(int id)
        {
            IBagImagesDal bagImagesDal=null;
            var result= bagImagesDal.GetAll(x => x.BagId == id).Count();
            if (result<5)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion  

    }
}
