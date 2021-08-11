using BusinessLayer.Concrate;
using DataAccessLayer.Concrate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcProjeKampi.Controllers
{
    public class LoginController : Controller
    {
        AdminManager adm = new AdminManager(new EfAdminDal());
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin p)
        {
            //Context c = new Context();
           // var adminuserinfo = c.Admins.FirstOrDefault(x=>x.AdminUserName == p.AdminUserName && x.AdminUserPassword == p.AdminUserPassword);
            var adminuserinfo = adm.GetList().FirstOrDefault(x=>x.AdminUserName == p.AdminUserName && x.AdminUserPassword == p.AdminUserPassword);


            if (adminuserinfo != null)
            {
                FormsAuthentication.SetAuthCookie(adminuserinfo.AdminUserName,false);
                Session["AdminUserName"] = adminuserinfo.AdminUserName;
                return RedirectToAction("Index","AdminCategory");
            }
            else
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        //[HttpGet]
        //public ActionResult KullaniciEkle()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult KullaniciEkle(Admin adminModel)
        //{
        //    Context c = new Context();

        //    var crypto = new SimpleCrypto.PBKDF2();
        //    var encrypedPassword = crypto.Compute(adminModel.AdminUserPassword);

        //    var User = new Admin();

        //    int result = 0;

        //    if (adminModel.AdminID == 0)
        //    {
        //        User.AdminUserName = adminModel.AdminUserName;
        //        User.AdminUserPassword = adminModel.AdminUserPassword;
        //        //User.Salt =adminModel.Salt
        //        c.Admins.Add(User);
        //        c.SaveChanges();
        //    }

        //    return View();
        //}
    }
}