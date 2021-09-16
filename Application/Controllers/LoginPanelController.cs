using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Application.Controllers
{
    public class LoginPanelController : Controller
    {
        // GET: LoginPanel
        #region Panel Login

        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(Admin admin)
        {
            AdminManager adminManager = new AdminManager(new EfAdminDal());
            var result=adminManager.GetAdmin(admin);
            if (result)
            {
                FormsAuthentication.SetAuthCookie(admin.UserName, false);
                return RedirectToAction("Index","Panel");
            }
            else
            {
                return View();
            }
            
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("AdminLogin");

        }


        #endregion
    }
}