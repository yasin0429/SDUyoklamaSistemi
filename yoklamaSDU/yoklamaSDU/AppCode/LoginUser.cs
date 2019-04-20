using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace yoklamaSDU.AppCode
{
    public class LoginUser
    {
        // ortak prop
        public int ID { get; set; }
        public string NameSurname { get; set; }
        public string Password { get; set; }
        public int AuthType { get; set; }
        public string Photo { get; set; }
        public int? FacultyID { get; set; }
        public int? DepartmanID { get; set; }

        // ogr prop
        public string TCKN { get; set; }
        public int? BranchID { get; set; }
        public int? ClassID { get; set; }
        public string StudentNo { get; set; }
        public string CardNo { get; set; }

        // hoca prop

        public string SicilNo { get; set; }





    }
}