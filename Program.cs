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
        public string Description { get; set; }
        public DateTime startDate;
        public DateTime dueDate;

        public void setStartDate(string inputDate, string inputTime)
        {
            startDate = Convert.ToDateTime(string.Format("{0} {1}:00.00", inputDate, inputTime));
        }

        public void setDueDate(string inputDate, string inputTime)
        {
            dueDate = Convert.ToDateTime(string.Format("{0} {1}:00.00", inputDate, inputTime));
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
            Task userTask = new Task();
            Console.WriteLine("\nLet's CREATE a NEW TASK.");  

            // Task Description
            Console.WriteLine("Task Description:");
            userTask.Description = Console.ReadLine();  

            // Task Start Date
            Console.WriteLine("\nTask Start Date (MM/DD/YEAR):");
            string taskStartDate = Console.ReadLine();  

            // Task Start Time
            Console.WriteLine("\nTask Start Time (HR:MN):");
            string taskStartTime = Console.ReadLine(); 
            userTask.setStartDate(taskStartDate, taskStartTime);

            // Task Due Date
            Console.WriteLine("\nTask Due Date (MM/DD/YEAR):");
            string taskDueDate = Console.ReadLine();  

            // Task Due Time
            Console.WriteLine("\nTask Due Time (HR:MN):");
            string taskDueTime = Console.ReadLine(); 
            userTask.setStartDate(taskDueDate, taskDueTime);

            // saveTask(userTask);
            Console.WriteLine("\nThat's all. Your task is now saved.");   
            printTask(userTask);
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

        static void saveTask(Task task)
        {
        }

        static void printTask(Task task)
        {
            Console.WriteLine("\nTask Description: {0} \nStart Date: {1} \nDue Date: {2}", 
                                task.Description, task.startDate, task.dueDate.ToString()); 
        }
    }
}