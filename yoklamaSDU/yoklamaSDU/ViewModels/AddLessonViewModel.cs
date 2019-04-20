using System;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using yoklamaSDU.AppCode;

namespace yoklamaSDU.ViewModels
{
    public class AddLessonViewModel
    {
        [Required(ErrorMessage = "Lütfen Fakülte Seçiniz.")]
        [DataType(DataType.Text)]
        public int? FacultyID { get; set; }

        [Required(ErrorMessage = "Lütfen Bölüm Seçiniz.")]
        [DataType(DataType.Text)]
        public int? DepartmanID { get; set; }

        [Required(ErrorMessage = "Lütfen Ders Adı Giriniz.")]
        [DataType(DataType.Text)]
        public string  LessonName { get; set; }

        [Required(ErrorMessage = "Lütfen Sınıf Seçiniz.")]
        [DataType(DataType.Text)]
        public int? ClassID { get; set; }

        [Required(ErrorMessage = "Lütfen Ders Kodunu Giriniz.")]
        [DataType(DataType.Text)]
        public string LessonCode { get; set; }

        public int? MaxContinuity { get; set; }
       

    }
}