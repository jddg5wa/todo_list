using System;
using System.IO;
using System.Collections.Generic;


namespace todo_list
{
    public class TaskList
    {
        public List<Task> allTasks { get; set; }

        public TaskList()
        {
            allTasks = new List<Task>();
        }
    }
    public class Task
    {
        public string Title {get; set;}
        public DateTime startDate {get; set;}
        public DateTime dueDate {get; set;}

        public Task(string Title, DateTime startDate, DateTime dueDate)
        {
            
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            CreateFoldersAndFiles();
            UserInput();
        }

        static void CreateFoldersAndFiles()
        {
            string appDataPath = System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string dataPath = Path.Combine(appDataPath , "ToDo_List");
            string tasksFullPath = Path.Combine(dataPath, "tasks.xml");

            if(!File.Exists(tasksFullPath))
            {
                Directory.CreateDirectory(dataPath);
                File.Create(tasksFullPath);
            }
            else
            {
                Console.WriteLine("File Exists");
            }
        }
        static void UserInput()
        {
            var options = new List<string> {"new list", "new task", "delete list", "delete task"};
            Console.WriteLine("What would you like to do? (" + String.Join(", ",options) + ")");
        }

        static void saveTask(object task)
        {
        }
    }
}