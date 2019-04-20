using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using yoklamaSDU.AppCode;
using yoklamaSDU.Models.EntityFramework;

namespace yoklamaSDU.Controllers
{
    public class YoklamaController : BaseController
    {
        // GET: YoklamaBaslat
        public ActionResult Index()
        {

            return View();
        }
        public void dosyayaYaz(string photo,string studentno,string name)
        {
            // birden fazla cihaz olunca her biri için yeni bir klasör açılacak
            string dosya_yolu = HostingEnvironment.MapPath("~/WebPage/index.html");
            FileStream fs = new FileStream(dosya_yolu, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamReader read = new StreamReader(fs);
            string txt=read.ReadToEnd();
            txt = txt.Replace("photo", ".." + photo);
            txt = txt.Replace("studentno", studentno);
            txt=  txt.Replace("namesurname", name);
            //string dosya_yolu1 = @"C:\Users\muzaffer\Source\Repos\muzafferaknn\yoklamaSDU\yoklamaSDU\yoklamaSDU\WebPage\deneme.html";
            string dosya_yolu1 = HostingEnvironment.MapPath("~/WebPage/user.html");
            FileStream fs1 = new FileStream(dosya_yolu1, FileMode.Truncate, FileAccess.ReadWrite);
            StreamWriter write = new StreamWriter(fs1);
            write.Write(txt);
            write.Close();
            fs1.Close();
            read.Close();
            fs.Close();

        }

    }
}