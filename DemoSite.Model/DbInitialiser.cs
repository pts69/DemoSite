using System.Data.Entity;

namespace DemoSite.Model
{
    internal class DbInitialiser : CreateDatabaseIfNotExists<MyDbContext>
    {
        protected override void Seed(MyDbContext context)
        {
        }
    }
}
