using System.Collections.Generic;
using System.Collections.ObjectModel;
using Core.DomainModel;
using System;
using System.Data.Entity;

namespace Infrastructure.Data
{
    public class SampleSeedInitializer : DropCreateDatabaseIfModelChanges<SampleContext>
    {
        protected override void Seed(SampleContext context)
        {
            var testTask1 = new Task()
            {
                HoursToComplete = 5,
                Completed = false,
                CreatedOn = DateTime.Now,
                Description = "This is a task that i am testing with",
                Headline = "Complete this page"
            };

            var testTask2 = new Task()
            {
                HoursToComplete = 2,
                Completed = false,
                CreatedOn = DateTime.Now,
                Description = "This is another task for another project",
                Headline = "Understand how a web api works"
            };

            var testTask3 = new Task()
            {
                HoursToComplete = 1337,
                Completed = true,
                CreatedOn = DateTime.Now,
                Description = "Use more complicated KnockoutJS elements",
                Headline = "KnockoutJS"
            };

            var taskList1 = new List<Task> { testTask1, testTask2 };
            var taskList2 = new List<Task> { testTask3 };

            var testProject1 = new Project()
            {
                Name = "My First Project",
                Tasks = taskList1
            };

            var testProject2 = new Project()
            {
                Name = "My Second Project",
                Tasks = taskList2
            };

            context.Projects.Add(testProject1);
            context.Projects.Add(testProject2);

            context.SaveChanges();
        }
    }
}
