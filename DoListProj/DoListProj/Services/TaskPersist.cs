using Newtonsoft.Json;
using DoListProj.Models;

namespace DoListProj.Services
{
    public class TaskPersist
    {
        private readonly string tasksFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "tasks.json");

        public List<TaskItem> GetTasksFromFile()
        {
            if (!File.Exists(tasksFilePath))
            {
                return new List<TaskItem>();
            }

            var jsonData = File.ReadAllText(tasksFilePath);
            return JsonConvert.DeserializeObject<List<TaskItem>>(jsonData) ?? new List<TaskItem>();
        }

        public void SaveTasksToFile(List<TaskItem> tasks)
        {
            var jsonData = JsonConvert.SerializeObject(tasks, Formatting.Indented);
            File.WriteAllText(tasksFilePath, jsonData);
        }

        public int GetNextId()
        {
            var tasks = GetTasksFromFile();
            return tasks.Count == 0 ? 1 : tasks.Max(t => t.Id) + 1;
        }
    }
}
