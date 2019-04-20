using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using yoklamaSDU.AppCode;
using yoklamaSDU.Models.EntityFramework;
using yoklamaSDU.ViewModels;

namespace yoklamaSDU.Controllers
{
    public class AyarlarController : BaseController
    {
        // GET: Ayarlar
        public ActionResult Index()
        {
            var loginUser = GetLoginUser();
            SettingsViewModel set = new SettingsViewModel();
            set.ID = loginUser.ID;
            set.Photo = loginUser.Photo;
            set.NameSurname = loginUser.NameSurname;
            set.TCKN = loginUser.TCKN;
            set.SicilNo = loginUser.SicilNo;
            return View(set);
        }
        public ActionResult UpdatePassword(SettingsViewModel settings)
        {
            if (ModelState.IsValid)
            {

                using (SduEntities ent = new SduEntities())
                {
                    var loginUser = GetLoginUser();
                    if (loginUser.AuthType == (int)EnumAuthType.Ogrenci)
                    {
                        var update = ent.Student.Where(q => q.StudentID == settings.ID && q.Password == settings.CurrentPassword).Select(q => q).SingleOrDefault();
                        if (update != null)
                        {
                            update.Password = settings.NewPassword;
                            ent.SaveChanges();
                        }
                        else
                        {
                            Session["toastError"] = "error";
                            return View("Index", settings);
                        }
                    }
                    else
                    {
                        var update = ent.Educator.Where(q => q.EducatorID == settings.ID && q.Password == settings.CurrentPassword).Select(q => q).SingleOrDefault();
                        if (update != null)
                        {
                            update.Password = settings.NewPassword;
                            ent.SaveChanges();
                        }
                        else
                        {
                            Session["toastError"] = "error";
                            return View("Index", settings);
                        }
                    }
                }
                return RedirectToAction("Logout", "Giris");
            }
            else
            {
                return View("Index", settings);
            }
        }
    }
}