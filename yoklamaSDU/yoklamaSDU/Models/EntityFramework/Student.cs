namespace yoklamaSDU.Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Student")]
    public partial class Student
    {
        public int StudentID { get; set; }

        [StringLength(50)]
        public string NameSurname { get; set; }

        [StringLength(11)]
        public string StudentNo { get; set; }

        [StringLength(50)]
        public string CardNo { get; set; }

        public int? DepartmanID { get; set; }

        [StringLength(50)]
        public string Password { get; set; }

        [StringLength(50)]
        public string TCKN { get; set; }

        [StringLength(100)]
        public string Photo { get; set; }

        public int? BranchID { get; set; }

        public int? ClassID { get; set; }

        public int? FacultyID { get; set; }

        public virtual Parameter Parameter { get; set; }

        public virtual Parameter Parameter1 { get; set; }

        public virtual Parameter Parameter2 { get; set; }

        public virtual Parameter Parameter3 { get; set; }
    }
}
