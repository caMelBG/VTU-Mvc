using System.Data.Entity.Migrations;

namespace DataBase.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<UniversityContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(UniversityContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
