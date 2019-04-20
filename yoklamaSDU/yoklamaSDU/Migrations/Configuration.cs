namespace yoklamaSDU.Migrations
{
    using Models.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<yoklamaSDU.Models.EntityFramework.SduEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        //    AutomaticMigrationDataLossAllowed = true;
     
           
        }

        protected override void Seed(yoklamaSDU.Models.EntityFramework.SduEntities context)
        {
            //  This method will be called after migrating to the latest version.
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
