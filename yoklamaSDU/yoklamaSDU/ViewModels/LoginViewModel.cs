using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace yoklamaSDU.ViewModels
{
    public class LoginViewModel
    {
        public int ID { get; set; }
        public int AuthType { get; set; }
        public string NameSurname { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}