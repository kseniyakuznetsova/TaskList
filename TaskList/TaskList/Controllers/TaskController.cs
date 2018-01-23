using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskList.Models;

namespace TaskList.Controllers
{
    public class TaskController : Controller
    {
        TaskContext context = new TaskContext();
        public ActionResult Index()
        {
            IEnumerable<Task> tasks = context.Tasks;
            ViewBag.Tasks = tasks;
            ViewBag.Count = tasks.ToList().Count;
            return View();
        }

        [HttpPost]
        public ActionResult Update(int id, bool isCompleted = true)
        {
            Task task = context.Tasks.Find(id);
            task.IsCompleted = !isCompleted;

            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Insert(Task task)
        {
            if (ModelState.IsValid)
            {
                context.Tasks.Add(task);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}