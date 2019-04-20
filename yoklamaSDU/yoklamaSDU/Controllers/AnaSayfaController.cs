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
    public class AnaSayfaController : BaseController
    {
        // GET: Home
        public ActionResult Index()
        {
            using (SduEntities ent=new SduEntities())
            {
                var loginUser = GetLoginUser();
                if (loginUser.AuthType==(int)EnumAuthType.Ogrenci)
                {
                HomePageViewModel detail = (from q in ent.Student
                              join p in ent.Parameter on q.DepartmanID equals p.ParameterID
                              join w in ent.Parameter on q.BranchID equals w.ParameterID
                              join e in ent.Parameter on q.ClassID equals e.ParameterID
                              join s in ent.Parameter on q.FacultyID equals s.ParameterID
                              where q.TCKN == loginUser.TCKN
                              select new HomePageViewModel
                              {
                                  TCKN = q.TCKN,
                                  NameSurname = q.NameSurname,
                                  Branch = w.Text,
                                  Class = e.Text,
                                  Departman = p.Text,
                                  StudentNo = q.StudentNo,
                                  Faculty = s.Text,
                                  Photo=q.Photo,
                                  AuthType=loginUser.AuthType
                              }).SingleOrDefault();
                          return View(detail);
                }
                else
                {
                    HomePageViewModel detail = (from q in ent.Educator
                                                join p in ent.Parameter on q.DepartmanID equals p.ParameterID
                                                join s in ent.Parameter on q.FacultyID equals s.ParameterID
                                                where q.SicilNo == loginUser.SicilNo
                                                select new HomePageViewModel
                                                {
                                                    SicilNo=q.SicilNo,
                                                    NameSurname = q.NameSurname,
                                                    Departman = p.Text,
                                                    Faculty = s.Text,
                                                    Photo = q.Photo,
                                                    AuthType=loginUser.AuthType
                                                }).SingleOrDefault();
                    return View(detail);
                }
            }
        }

    }
}