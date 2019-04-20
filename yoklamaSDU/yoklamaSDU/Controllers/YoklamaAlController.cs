using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using yoklamaSDU.AppCode;
using yoklamaSDU.Models.EntityFramework;

namespace yoklamaSDU.Controllers
{
    [AllowAnonymous]
    public class YoklamaAlController : ApiController
    {
        [AcceptVerbs("GET", "POST")]
        public IHttpActionResult Yoklama(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                using (SduEntities ent=new SduEntities())
                {
                    var control = ent.Student.Where(q => q.CardNo == id).Select(q => q).SingleOrDefault();
                    if (control!=null)
                    {
                        YoklamaController cnt = new YoklamaController();
                        cnt.dosyayaYaz(control.Photo,control.StudentNo,control.NameSurname);
                    }
                }
            }
            Response rsp = new Response();
            rsp.response = id;
            return Json(rsp);
        }
   
    }
}
