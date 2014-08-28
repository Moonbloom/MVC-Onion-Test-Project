using Core.DomainModel;
using System;
using System.Data.Entity;

namespace Infrastructure.Data
{
    public class SampleSeedInitializer : DropCreateDatabaseIfModelChanges<SampleContext>
    {
        protected override void Seed(SampleContext context)
        {
            var item = new Test() { CreatedOn = DateTime.Now, ModifiedOn = DateTime.UtcNow };
            context.Tests.Add(item);

            var m = new Task()
            {
                Completed = false,
                CreatedOn = DateTime.Today,
                Description = "This is a task that i am testing with",
                Headline = "Complete this page"
            };
            context.Tasks.Add(m);

            context.SaveChanges();
        }
    }
}
