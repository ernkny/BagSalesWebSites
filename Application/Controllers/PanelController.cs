using Application.Models;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace Application.Controllers
{
    [Authorize]
    public class PanelController : Controller
    {
        // GET: Panel
        public ActionResult Index()
        {
            return View();
        }

        #region Bag CRUD operations
        [HttpGet]
        public ActionResult Bag(int? id,int page=1)
        {
            IPagedList pagedList;
            var result= new List<Bag>();
            BagManager bagManager = new BagManager(new EfBagDal());
          
            result = bagManager.GetAllBags().OrderByDescending(x => x.Date).ToList();
            
            if(Convert.ToBoolean(id) == true)
            {
               result = bagManager.GetAllBags().Where(x => x.Showcase == Convert.ToBoolean(id)).OrderByDescending(x => x.Date).ToList();
            }
            pagedList = result.ToPagedList(page,20);
                
            return View(pagedList);
        }


        [HttpGet]
        public ActionResult BagAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult BagAdd(Bag bag, List<HttpPostedFileBase> files)
        {
            BagManager bagManager = new BagManager(new EfBagDal());
            var result= bagManager.AddBag(bag, files);
            TempData["errorMessages"] = result.First();
            return View();

        }

        public ActionResult BagDelete(int id)
        {
            BagManager bagManager = new BagManager(new EfBagDal());
            var result= bagManager.DeleteBag(id);
            return RedirectToAction("Bag");

        }
        public ActionResult BagBring(Bag bag)
        {
            BagManager bagManager = new BagManager(new EfBagDal());
            bagManager.UpdateBag(bag);
            return RedirectToAction("Bag");
        }

        [HttpGet]
        public ActionResult BagBring(int id)
        {
            ViewModel vm = new ViewModel();
            BagManager bagManager = new BagManager(new EfBagDal());
            EfBagImagesDal efBagImagesDal = new EfBagImagesDal();
            var result=bagManager.GetBagById(id);
            var images = efBagImagesDal.GetAll(x => x.BagId == id);
            vm.IEnumBag = result;
            vm.IEnumImageBag = images;
            return View(vm);
        }
        #endregion

        #region

        [HttpGet]
        public ActionResult Brand(int page = 1)
        {
            IPagedList pagedList;
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            pagedList = brandManager.GetAllBrand().ToPagedList(page,20);

            return View(pagedList);

        }
        [HttpGet]
        public ActionResult BrandAdd()
        {

            return View();


        }    
        [HttpPost]
        public ActionResult BrandAdd(Brand brad)
        {
          
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.AddBrand(brad);
            TempData["errorMessages"] = "Marka Eklendi";
            return View();

        }
        
        public ActionResult BrandDelete(int id)
        {

            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.DeleteBrand(id);
           
            return RedirectToAction("Brand");

        }


        #endregion


        #region Form Contact


        [HttpGet]
        public ActionResult GetFormInfo()
        {
            ContactManager contactManager = new ContactManager(new EfContactFormDal());
           var result= contactManager.GetAllContacts().OrderByDescending(x=>x.Date).ToList();

            return View(result);
        }
        
        public ActionResult ContactDelete(int id)
        {
            ContactManager contactManager = new ContactManager(new EfContactFormDal());
            var result=contactManager.GetContact(id);
            contactManager.ContactDelete(result);
            return RedirectToAction("GetFormInfo");
        }

        public ActionResult MessageDetail(int id)
        {
            ContactManager contactManager = new ContactManager(new EfContactFormDal());
            var result = contactManager.GetContact(id);
            return View(result);
        }


        #endregion


        
    }
}