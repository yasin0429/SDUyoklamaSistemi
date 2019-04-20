using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace yoklamaSDU.ViewModels
{
    public class ListLessonsViewModel
    {
        public string LessonCode { get; set; }
        public string LessonName { get; set; }
        public string EducatorName { get; set; }
        public int? Max { get; set; }

    }
}