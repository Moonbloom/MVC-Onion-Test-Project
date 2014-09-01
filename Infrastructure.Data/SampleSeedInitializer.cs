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
            var testTask = new Task()
            {
                HoursToComplete = 5,
                Completed = false,
                CreatedOn = DateTime.Today,
                Description = "This is a task that i am testing with",
                Headline = "Complete this page"
            };

            var taskList = new List<Task> {testTask};

            var testProject = new Project()
            {
                Name = "My Test Project",
                Tasks = taskList
            };
            context.Projects.Add(testProject);

            context.SaveChanges();
        }
    }
}
