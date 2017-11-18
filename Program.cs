using System;
using System.IO;
using System.Collections.Generic;
using System.Reflection;


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
            UserInput("");
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
        static void UserInput(string input)
        {
            if(input == "")
            {
                var options = new List<string> {"new list", "new task", "delete list", "delete task"};
                Console.WriteLine("What would you like to do? (" + String.Join(", ",options) + ")");
                UserInput(Console.ReadLine());
            }
            else
            {
                if(input == "new list")
                {
                    newTaskList();                
                }
                else if(input == "new task")
                {
                    newTask();                
                }
                else if(input == "delete list")
                {
                    deleteTaskList();                
                }
                else if(input == "delete task")
                {
                    deleteTask();                
                }
                else
                {
                    Console.WriteLine("This option does not exist or is a work in progress.");
                    UserInput("");
                }
            }
            
        }

        static void newTask()
        {
            Console.WriteLine("\nLet's CREATE a NEW TASK.");   
        }

        static void newTaskList()
        {
            Console.WriteLine("\nLet's CREATE a NEW TASK LIST.");   
        }

        static void deleteTask()
        {
            Console.WriteLine("\nWhich TASK would you like to DELETE?");   
        }

        static void deleteTaskList()
        {
            Console.WriteLine("\nWhich LIST would you like to DELETE?");   
        }

        static void saveTask(object task)
        {
        }
    }
}