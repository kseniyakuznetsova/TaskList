using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace TaskList.Models
{
    public class DbInitializer: CreateDatabaseIfNotExists<TaskContext>
    {
        protected override void Seed(TaskContext context)
        {
            context.Tasks.Add(new Task { Name = "Task1", IsCompleted = true });
            context.Tasks.Add(new Task { Name = "Task2", IsCompleted = false });
            context.Tasks.Add(new Task { Name = "Task3", IsCompleted = false });
            base.Seed(context);
        }
    }
}