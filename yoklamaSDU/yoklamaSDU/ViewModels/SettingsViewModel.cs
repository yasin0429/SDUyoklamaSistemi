using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace yoklamaSDU.ViewModels
{
    public class SettingsViewModel
    {
        public int ID { get; set; }
        public string Photo { get; set; }
        public string NameSurname { get; set; }
        public string TCKN { get; set; }
        public string SicilNo { get; set; }
        public string StudentNo { get; set; }
        [Required(ErrorMessage = "Lütfen eski şifrenizi giriniz.")]
        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; }

        [Required(ErrorMessage = "Lütfen yeni şifrenizi giriniz.")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Lüften yeni şifrenizi tekrar giriniz.")]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "Şifreler eşleşmiyor. Lütfen tekrar deneyiniz.")]
        public string NewPasswordRepeat { get; set; }
    }
}