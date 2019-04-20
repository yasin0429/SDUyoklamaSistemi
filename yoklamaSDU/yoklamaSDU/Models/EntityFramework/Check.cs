namespace yoklamaSDU.Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Check")]
    public partial class Check
    {
        public int CheckID { get; set; }

        [StringLength(50)]
        public string IP { get; set; }

        [StringLength(50)]
        public string CartNo { get; set; }

        public int? LessonID { get; set; }

        public int? BranchID { get; set; }

        public virtual Lesson Lesson { get; set; }

        public virtual Parameter Parameter { get; set; }
    }
}
