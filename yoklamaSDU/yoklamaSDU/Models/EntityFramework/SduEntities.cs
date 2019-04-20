namespace yoklamaSDU.Models.EntityFramework
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SduEntities : DbContext
    {
        public SduEntities()
            : base("name=SduEntities")
        {
        }

        public virtual DbSet<Check> Check { get; set; }
        public virtual DbSet<Educator> Educator { get; set; }
        public virtual DbSet<Lesson> Lesson { get; set; }
        public virtual DbSet<Parameter> Parameter { get; set; }
        public virtual DbSet<ParameterGroup> ParameterGroup { get; set; }
        public virtual DbSet<Student> Student { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Parameter>()
                .HasMany(e => e.Check)
                .WithOptional(e => e.Parameter)
                .HasForeignKey(e => e.BranchID);

            modelBuilder.Entity<Parameter>()
                .HasMany(e => e.Educator)
                .WithOptional(e => e.Parameter)
                .HasForeignKey(e => e.FacultyID);

            modelBuilder.Entity<Parameter>()
                .HasMany(e => e.Educator1)
                .WithOptional(e => e.Parameter1)
                .HasForeignKey(e => e.DepartmanID);

            modelBuilder.Entity<Parameter>()
                .HasMany(e => e.Lesson)
                .WithOptional(e => e.Parameter)
                .HasForeignKey(e => e.FacultyID);

            modelBuilder.Entity<Parameter>()
                .HasMany(e => e.Lesson1)
                .WithOptional(e => e.Parameter1)
                .HasForeignKey(e => e.ClassID);

            modelBuilder.Entity<Parameter>()
                .HasMany(e => e.Lesson2)
                .WithOptional(e => e.Parameter2)
                .HasForeignKey(e => e.DepartmanID);

            modelBuilder.Entity<Parameter>()
                .HasMany(e => e.Student)
                .WithOptional(e => e.Parameter)
                .HasForeignKey(e => e.DepartmanID);

            modelBuilder.Entity<Parameter>()
                .HasMany(e => e.Student1)
                .WithOptional(e => e.Parameter1)
                .HasForeignKey(e => e.BranchID);

            modelBuilder.Entity<Parameter>()
                .HasMany(e => e.Student2)
                .WithOptional(e => e.Parameter2)
                .HasForeignKey(e => e.ClassID);

            modelBuilder.Entity<Parameter>()
                .HasMany(e => e.Student3)
                .WithOptional(e => e.Parameter3)
                .HasForeignKey(e => e.FacultyID);
        }
    }
}
