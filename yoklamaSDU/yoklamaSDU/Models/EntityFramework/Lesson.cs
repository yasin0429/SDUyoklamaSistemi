namespace yoklamaSDU.Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Lesson")]
    public partial class Lesson
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Lesson()
        {
            Check = new HashSet<Check>();
        }

        public int LessonID { get; set; }

        [StringLength(50)]
        public string LessonName { get; set; }

        public int? EducatorID { get; set; }

        [StringLength(11)]
        public string StudentNo { get; set; }

        public int? ClassID { get; set; }

        [StringLength(10)]
        public string LessonCode { get; set; }

        public int? MaxContinuity { get; set; }

        public int? FacultyID { get; set; }

        public int? DepartmanID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Check> Check { get; set; }

        public virtual Educator Educator { get; set; }

        public virtual Parameter Parameter { get; set; }

        public virtual Parameter Parameter1 { get; set; }

        public virtual Parameter Parameter2 { get; set; }
    }
}
