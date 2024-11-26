using Microsoft.AspNetCore.Mvc;
using DoListProj.Models;
using DoListProj.Services;

namespace DoListProj.Controllers
{
    public class TaskItemsController : Controller
    {
        private readonly TaskPersist _taskPersist;

        public TaskItemsController(TaskPersist taskPersist)
        {
            _taskPersist = taskPersist; 
        }

        public IActionResult AllTasks()
        {
            var tasks = _taskPersist.GetTasksFromFile(); 
            return View(tasks);
        }

        [HttpGet]
        public IActionResult AddTask()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddTask(string Title)
        {
            if (!string.IsNullOrWhiteSpace(Title))
            {
                var task = new TaskItem
                {
                    Id = _taskPersist.GetNextId(), 
                    Title = Title,
                    IsCompleted = false
                };

                var tasks = _taskPersist.GetTasksFromFile();
                tasks.Add(task);
                _taskPersist.SaveTasksToFile(tasks);
            }
            return RedirectToAction("AllTasks");
        }

        [HttpPost]
        public IActionResult DeleteTask(int id)
        {
            var tasks = _taskPersist.GetTasksFromFile();
            tasks.RemoveAll(t => t.Id == id);
            _taskPersist.SaveTasksToFile(tasks);
            return Ok();
        }

        [HttpPost]
        public IActionResult ToggleCompletion(int id)
        {
            var tasks = _taskPersist.GetTasksFromFile();
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task != null)
            {
                task.IsCompleted = !task.IsCompleted;
                _taskPersist.SaveTasksToFile(tasks);
            }
            return Ok();
        }
    }
}
