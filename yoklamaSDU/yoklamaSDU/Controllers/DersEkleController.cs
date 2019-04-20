using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using yoklamaSDU.AppCode;
using yoklamaSDU.Models.EntityFramework;
using yoklamaSDU.ViewModels;
using Net.SourceForge.Koogra;
using Net.SourceForge.Koogra.Excel;
using Excel2007 = Net.SourceForge.Koogra.Excel2007;
using System.Data;
using System.Data.SqlClient;

namespace yoklamaSDU.Controllers
{
    public class DersEkleController : BaseController
    {
        // GET: DersEkle
        public ActionResult Index()
        {
            ViewBag.Faculty = ListFaculty((int)EnumParamaterGroup.Faculty);
            ViewBag.Departman = ListFaculty((int)EnumParamaterGroup.Departman);
            ViewBag.Class = ListFaculty((int)EnumParamaterGroup.Class);
            AddLessonViewModel model = new AddLessonViewModel();
            model.FacultyID = GetLoginUser().FacultyID;
            model.DepartmanID = GetLoginUser().DepartmanID;

            return View(model);
        }
        public ActionResult Save(AddLessonViewModel model, HttpPostedFileBase file)
        {
            ViewBag.Faculty = ListFaculty((int)EnumParamaterGroup.Faculty);
            ViewBag.Departman = ListFaculty((int)EnumParamaterGroup.Departman);
            ViewBag.Class = ListFaculty((int)EnumParamaterGroup.Class);
            if (ModelState.IsValid)
            {
                var loginUser = GetLoginUser();
                using (SduEntities ent = new SduEntities())
                {

                    if (file != null)
                    {
                        string path = HttpContext.Server.MapPath("~/Content/docs/") + file.FileName;
                        file.SaveAs(path);
                        List<string> dt = new List<string>();
                        IWorkbook workbook;
                        IWorksheet sheet;
                        uint lastRow;

                        workbook = new Excel2007.Workbook(path);
                        sheet = workbook.Worksheets.GetWorksheetByIndex(0);
                        lastRow = sheet.LastRow;
                        for (uint i = 1; i <= lastRow; i++)
                        {
                            IRow row = sheet.Rows.GetRow(i);
                            string studentNo = "";
                            studentNo = GetCellValue(row, 0);
                            dt.Add(studentNo);
                        }
                        System.IO.File.Delete(path);
                        foreach (var item in dt)
                        {
                            Lesson lesson = new Lesson();
                            lesson.FacultyID = model.FacultyID;
                            lesson.DepartmanID = model.DepartmanID;
                            lesson.EducatorID = loginUser.ID;
                            lesson.LessonName = model.LessonName;
                            lesson.ClassID = model.ClassID;
                            lesson.LessonCode = model.LessonCode;
                            lesson.MaxContinuity = model.MaxContinuity;
                            lesson.StudentNo = item.ToString();
                            ent.Lesson.Add(lesson);
                            ent.SaveChanges();
                        }
                    }
                    return RedirectToAction("Index");
                }
            }
            else
            {
                return View("Index", model);
            }
            
        }
        protected List<SelectListItem> ListFaculty(int type)
        {
            using (SduEntities ent = new SduEntities())
            {
                List<SelectListItem> item = new List<SelectListItem>();
                var list = ent.Parameter.Where(q => q.ParameterGroupID == type).Select(q => q).OrderBy(q => q.Text).ToList();
                foreach (var items in list)
                {
                    item.Add(new SelectListItem { Value = items.ParameterID.ToString(), Text = items.Text, Selected = false });
                }
                return item;
            }
        }

    }
}