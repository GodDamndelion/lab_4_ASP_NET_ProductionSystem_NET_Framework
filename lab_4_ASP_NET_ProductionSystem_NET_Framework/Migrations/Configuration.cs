namespace lab_4_ASP_NET_ProductionSystem_NET_Framework.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<lab_4_ASP_NET_ProductionSystem_NET_Framework.Models.MainDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "lab_4_ASP_NET_ProductionSystem_NET_Framework.Models.MainDbContext";
        }

        protected override void Seed(lab_4_ASP_NET_ProductionSystem_NET_Framework.Models.MainDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
