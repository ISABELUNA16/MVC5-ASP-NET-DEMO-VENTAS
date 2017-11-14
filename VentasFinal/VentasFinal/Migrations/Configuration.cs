namespace VentasFinal.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<VentasFinal.Models.VentasFinalContext>
    {
        public Configuration()
        {
            
            //Activar las migraciones automáticas
            AutomaticMigrationDataLossAllowed = true;
            //----------

            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(VentasFinal.Models.VentasFinalContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
