using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using yoklamaSDU.AppCode;
using yoklamaSDU.Models.EntityFramework;
using yoklamaSDU.ViewModels;

namespace yoklamaSDU.Controllers
{
    public class GirisController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {

                return View(new LoginViewModel());
        }
        public ActionResult LoginUser(LoginViewModel login)
         {
            using (SduEntities ent=new SduEntities())
            {
                LoginUser loginUser = new LoginUser();
                var studentControl = ent.Student.Where(q => q.StudentNo == login.UserName && q.Password == login.Password).Select(q => q).SingleOrDefault();
                if (studentControl != null)
                {
                    loginUser.AuthType = (int)EnumAuthType.Ogrenci;
                    loginUser.TCKN = studentControl.TCKN;
                    loginUser.ClassID = studentControl.ClassID;
                    loginUser.BranchID = studentControl.BranchID;
                    loginUser.StudentNo = studentControl.StudentNo;
                    loginUser.CardNo = studentControl.CardNo;
                    // ortak olanlar
                    loginUser.ID = studentControl.StudentID;
                    loginUser.NameSurname = studentControl.NameSurname;
                    loginUser.Password = studentControl.Password;
                    loginUser.Photo = studentControl.Photo;
                    loginUser.FacultyID = studentControl.FacultyID;
                    loginUser.DepartmanID = studentControl.DepartmanID;
                    Session["LoginUser"] = loginUser;
                    FormsAuthentication.SetAuthCookie(studentControl.StudentNo, false);
                    return RedirectToAction("Index", "AnaSayfa");
                }
                else
                {
                    var educatorControl = ent.Educator.Where(q => q.Username == login.UserName && q.Password == login.Password).Select(q => q).SingleOrDefault();
                    if (educatorControl!=null)
                    {
                        loginUser.ID = educatorControl.EducatorID;
                        loginUser.NameSurname = educatorControl.NameSurname;
                        loginUser.Password = educatorControl.Password;
                        loginUser.Photo = educatorControl.Photo;
                        loginUser.FacultyID = educatorControl.FacultyID;
                        loginUser.DepartmanID = educatorControl.DepartmanID;
                        loginUser.AuthType = (int)EnumAuthType.Hoca;
                        loginUser.SicilNo = educatorControl.SicilNo;
                        Session["LoginUser"] = loginUser;
                        FormsAuthentication.SetAuthCookie(educatorControl.SicilNo, false);
                        return RedirectToAction("Index", "AnaSayfa");
                    }
                    else
                    {
                        Session["LoginUser"] = "Error";
                    }
                }
                    return View("Index", login);
            }
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            Session.Remove("LoginUser");
            return RedirectToAction("Index", "Giris");
        }
    }
}