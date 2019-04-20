
using Net.SourceForge.Koogra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using yoklamaSDU.AppCode;
using yoklamaSDU.Models.EntityFramework;

namespace yoklamaSDU.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            // session timeout olduğunda login sayfasına yönlendirme

            if (GetLoginUser() == null)
            {
                filterContext.Result = RedirectToAction("Index", "Giris");
            }
            else
            {
                // yetkisiz sayfalara erişimin engellenmesi
                string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
                //if (GetLoginUser().AutType != (int)EnumAuthType.Admin && controllerName == "Personal")
                //{
                //    filterContext.Result = RedirectToAction("Index", "Home", new RouteValueDictionary() { { "type", Session["type"] } });
                //}
                //if (GetLoginUser().Roles == (int)EnumRolesType.Developer && controllerName == "Lead")
                //{
                //    filterContext.Result = RedirectToAction("Index", "Home", new RouteValueDictionary() { { "type", Session["type"] } });
                //}
                //if (GetLoginUser().Roles == (int)EnumRolesType.OutSource && controllerName != "Home" && controllerName != "User")
                //{
                //    filterContext.Result = RedirectToAction("Index", "Home", new RouteValueDictionary() { { "type", Session["type"] } });
                //}
            }
        }

        public LoginUser GetLoginUser()
        {
            return (LoginUser)Session["LoginUser"];
        }
        public string GetCellValue(IRow cells, uint column)
        {
            if (cells != null && cells.GetCell(column) != null)
            {
                object value = cells.GetCell(column).Value;
                if (value != null)
                {
                    return value.ToString().Trim();
                }
            }
            return string.Empty;
        }
    }
}