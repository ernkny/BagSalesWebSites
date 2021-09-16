using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Application.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            BagManager bagManager = new BagManager(new EfBagDal());
            var result = bagManager.GetAllBags().Where(x => x.Showcase == true).OrderByDescending(x => x.Date).Take(15).ToList();
            return View(result);
        }

        [HttpGet]
        public ActionResult Page404()
        {

            return View();;
        }

        [HttpPost]
        public ActionResult Index(string searchfilter)
        {
            BagManager bagManager = new BagManager(new EfBagDal());
            var result = bagManager.GetAllBags().Where(x => x.Showcase == true && x.Title.ToLowerInvariant().Contains(searchfilter.ToLowerInvariant())).OrderByDescending(x => x.Date).Take(15).ToList();

            return View(result);
        }

        [HttpGet]
        public ActionResult NewThisWeek()
        {
            BagManager bagManager = new BagManager(new EfBagDal());
            var result = bagManager.GetAllBags().OrderByDescending(x => x.Date).Take(15).ToList();
            return View(result);
        }

        [HttpPost]
        public ActionResult NewThisWeek(string searchfilter)
        {
            BagManager bagManager = new BagManager(new EfBagDal());
            var result = bagManager.GetAllBags().Where(x => x.Title.ToLowerInvariant().Contains(searchfilter.ToLowerInvariant())).OrderByDescending(x => x.Date).Take(15).ToList();

            return View(result);
        }

        public ActionResult BagDetail(int id)
        {
            BagManager bagManager = new BagManager(new EfBagDal());
            var result = bagManager.DetailBag(id);   
            return View(result);
        }

        [HttpGet]
        public ActionResult Contact()
        {
            EfCountryDal efcountryDal = new EfCountryDal();
            var result = efcountryDal.GetAll();
            return View(result);
        }

        [HttpPost]
        public ActionResult PostContactForm(Contact contact)
        {
            contact.Date = DateTime.Now;
            ContactManager contactManager = new ContactManager(new EfContactFormDal());
            var message = contactManager.AddContact(contact);
            if (message)
            {
                TempData["messages"] = "Form Sended. Thanks For Contact With Us";
            }
            else
            {
                TempData["messages"] = "Contact Form Couldn't Send. Check Your Info. And Try Again";
            }

            EfCountryDal efcountryDal = new EfCountryDal();
            var result = efcountryDal.GetAll();
            return View("Contact", result);
        }

        [HttpGet]
        public ActionResult Store(int page=1)
        {
            Application.Models.ViewModel viewModel = new Models.ViewModel();
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            BagManager bagManager = new BagManager(new EfBagDal());
            var result = bagManager.GetAllBags().OrderByDescending(x=>x.Date).ToList();
            List<string> Categories = new List<string>();
            Categories = brandManager.GetAllBrand().Select(x => x.BrandName).ToList();

            viewModel.categories = Categories;
            viewModel.PagedlistBag = result.ToPagedList(page, 16);


            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Store(int page = 1, string SearchFilter = "")
        {
            Application.Models.ViewModel viewModel = new Models.ViewModel();

            BagManager bagManager = new BagManager(new EfBagDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            var result = bagManager.GetAllBags().OrderByDescending(x => x.Date).ToList();
            List<string> Categories = new List<string>();
            Categories = brandManager.GetAllBrand().Select(x=>x.BrandName).ToList();

            viewModel.categories = Categories;
            viewModel.PagedlistBag = result.Where(x => x.Title.ToLowerInvariant().Contains(SearchFilter.ToLowerInvariant()) || x.Model.ToLowerInvariant().Contains(SearchFilter.ToLowerInvariant())).OrderByDescending(x => x.Date).ToPagedList(page, 16);


            return View(viewModel);


        }

        public ActionResult About()
        {
            return View();
        }

    }
}