using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using yoklamaSDU.Models.EntityFramework;
using yoklamaSDU.ViewModels;

namespace yoklamaSDU.Controllers
{
    public class DersBilgileriController : BaseController
    {
        // GET: DersBilgileri
        public ActionResult Index()
        {
            using (SduEntities ent = new SduEntities())
            {
                var std = GetLoginUser();

                List<ListLessonsViewModel> list = (from q in ent.Lesson
                                             join p in ent.Educator on q.EducatorID equals p.EducatorID
                                             where q.StudentNo == std.StudentNo
                                             select new ListLessonsViewModel
                                             {
                                                 LessonCode = q.LessonCode,
                                                 EducatorName = p.NameSurname,
                                                 LessonName = q.LessonName,
                                                 Max = q.MaxContinuity
                                             }).OrderBy(q=>q.LessonCode).ToList();
                return View(list);
            }
        }
    }
}