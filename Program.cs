using System;
using System.IO;
using System.Collections.Generic;
using System.Reflection;
using System.Diagnostics;
using System.Xml;


namespace todo_list
{
    public class TaskList
    {
        public List<Task> tasks { get; set; }

        public TaskList()
        {
            tasks = new List<Task>();
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

    public class SaveableData 
    {
        public List<Task> allTasks = new List<Task>();
        public List<TaskList> allTaskLists = new List<TaskList>();
    }

    
    public class Program
    {
        static void Main(string[] args)
        {
            var options = new List<string> {"new list", "new task", "delete list", "delete task"};
            Console.WriteLine("What would you like to do? (" + String.Join(", ",options) + ")");
            UserInputs(Console.ReadLine());

            Task testTask = new Task();
            testTask.Description = "Test Saving Functionality";
            testTask.setStartDate("05/20/1993", "12:00");
            testTask.setDueDate("05/20/1993", "12:00");

            saveData(testTask);
            printTask(loadData());
        }

        static void UserInputs(string input)
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

        static void newTask()
        {
            Task newTask = new Task();
            Console.WriteLine("\nLet's CREATE a NEW TASK.");  

            // Task Description
            Console.WriteLine("Task Description:");
            newTask.Description = Console.ReadLine();  

            // Task Start Date
            Console.WriteLine("\nTask Start Date (MM/DD/YEAR):");
            string taskStartDate = Console.ReadLine();  

            // Task Start Time
            Console.WriteLine("\nTask Start Time (HR:MN):");
            string taskStartTime = Console.ReadLine(); 
            newTask.setStartDate(taskStartDate, taskStartTime);

            // Task Due Date
            Console.WriteLine("\nTask Due Date (MM/DD/YEAR):");
            string taskDueDate = Console.ReadLine();  

            // Task Due Time
            Console.WriteLine("\nTask Due Time (HR:MN):");
            string taskDueTime = Console.ReadLine(); 
            newTask.setStartDate(taskDueDate, taskDueTime);

            saveData(newTask);
            Console.WriteLine("\nThat's all. Your task is now saved.");  
            printTask(newTask);
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

        static void saveData(Task task)
        {
            string tasksFilePath = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "ToDo_List", "tasks.xml");

            System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(task.GetType());
            using (FileStream file = File.Create(tasksFilePath))
            {
                xmlSerializer.Serialize(file, task);
            }
            
            // Process.Start(tasksFilePath);
            Console.WriteLine("\nTasks Saved ------------");
            printTask(task);
        }

        static Task loadData()
        {
            string tasksFilePath = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "ToDo_List", "tasks.xml");
            object obj = new Object();
            Task newTask = new Task();

            System.Xml.Serialization.XmlSerializer xmlDeserializer = new System.Xml.Serialization.XmlSerializer(typeof(Task));
            using (FileStream file = new FileStream(tasksFilePath, FileMode.Open))
            {  
                obj = xmlDeserializer.Deserialize(file);
                newTask = (Task)obj;
            }

            Console.WriteLine("\nTasks Loaded -------");
            return newTask;
        }

        static void printTask(Task task)
        {
            Console.WriteLine("Task Description: {0} \nStart Date: {1} \nDue Date: {2}\n", 
                                task.Description, task.startDate, task.dueDate.ToString()); 
        }
    }
}