namespace yoklamaSDU.Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Educator")]
    public partial class Educator
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Educator()
        {
            Lesson = new HashSet<Lesson>();
        }

        public int EducatorID { get; set; }

        [StringLength(50)]
        public string NameSurname { get; set; }

        [StringLength(50)]
        public string SicilNo { get; set; }

        [StringLength(50)]
        public string Username { get; set; }

        [StringLength(50)]
        public string Password { get; set; }

        public int? FacultyID { get; set; }

        public int? DepartmanID { get; set; }

        [StringLength(100)]
        public string Photo { get; set; }

        public virtual Parameter Parameter { get; set; }

        public virtual Parameter Parameter1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Lesson> Lesson { get; set; }
    }
}
