using System.Collections.Generic;
using System.Collections.ObjectModel;
using Core.DomainModel;
using System;
using System.Data.Entity;

namespace Infrastructure.Data
{
    public class SampleSeedInitializer : DropCreateDatabaseAlways<SampleContext>
    {
        protected override void Seed(SampleContext context)
        {
            var testTask1 = new Task()
            {
                HoursToComplete = 5,
                Completed = false,
                CreatedOn = DateTime.Today,
                Description = "This is a task that i am testing with",
                Headline = "Complete this page"
            };

            var taskList1 = new List<Task> {testTask1};

            var testProject1 = new Project()
            {
                Name = "My First Project",
                Tasks = taskList1
            };
            context.Projects.Add(testProject1);

            var testTask2 = new Task()
            {
                HoursToComplete = 2,
                Completed = false,
                CreatedOn = DateTime.Today,
                Description = "This is another task for another project",
                Headline = "Understand how a web api works"
            };

            var taskList2 = new List<Task> {testTask2};

            var testProject2 = new Project()
            {
                Name = "My Second Project",
                Tasks = taskList2
            };
            context.Projects.Add(testProject2);

            context.SaveChanges();
        }
    }
}
