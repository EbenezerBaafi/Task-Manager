using System.Threading.Tasks.Sources;
using System.Transactions;

namespace MyTaskManager
{
    internal class Program
    {
        internal static List<Task> taskList = new List<Task>();

        static void Main(string[] args)
        {

            // Initial sample task
            taskList.Add(new Task(1, "C# project", DateTime.Now.AddDays(3)));

            DisplayMenu();

            while(true)
            {
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();
                switch(choice)
                {
                    case "1":
                        AddTask();
                        break;
                    case "2":
                        ReadTask();
                        break;
                    case "3":
                        MarkAsCompleted();
                        break;
                    case "4":
                        Console.WriteLine("Exiting.....");
                        return;
                    default:
                        Console.WriteLine("Invalid Choice.");
                        break;


                }
            }
            void AddTask()
            {
                int taskId = taskList.Count + 1;
                Console.Write("Enter task description: ");
                string description = Console.ReadLine();
                Console.Write("Enter due date (YYYY-MM-DD): ");
                DateTime dueDate = DateTime.Parse(Console.ReadLine());
                taskList.Add(new Task(taskId, description, dueDate));
                Console.WriteLine("Task Added!!");
            }

            void ReadTask()
            {
                if ( taskList.Count == 0)
                {
                    Console.WriteLine("No task found");
                    return;
                }

                Console.WriteLine("*****TaskList******");
                Console.WriteLine("| Task ID | Description | Due Date | Completed |");
                Console.WriteLine("----------| ------------| ---------|--------|");

                foreach (Task task in taskList)
                {
                    string status = task.IsCompleted ? "Yes" : "No";
                    Console.WriteLine($"|{task.TaskID}| {task.Description} | {task.DueDate.Year}|{task.DueDate:MM}|{task.DueDate:DD}| {status}|");
                }

                // Sort
                Console.Write("Enter sorting criteria (id, description, due date, completed): ");
                String sortBy = Console.ReadLine();

                SortTask(sortBy);

            }

            void  SortTask(string sortBy)
            {
                switch (sortBy.ToLower())
                {
                    case "id":
                        taskList.Sort((t1, t2) => t1.TaskID.CompareTo(t2.TaskID));
                        break;
                    case "description":
                        taskList.Sort((t1, t2) => t1.TaskID.CompareTo(t2.TaskID));
                        break;
                    case "due date":
                        taskList.Sort((t1, t2) => t1.TaskID.CompareTo(t2.TaskID));
                        break;
                    case "completed":
                        taskList.Sort((t1, t2) => t1.TaskID.CompareTo(t2.TaskID));
                        break;
                        
                }
            }

            void MarkAsCompleted ()
            {
                // Get the task id from the user
                Console.Write("Enter task id");
                // handle potential parsing errors
                int taskId = Convert.ToInt32(Console.ReadLine());

                //find the task in the list
                Task taskToMark = taskList.Find(task => task.TaskID == taskId);

                //check if task exist
                if(taskToMark == null)
                {
                    Console.WriteLine("Task does not exist!");
                    return;
                }
                taskToMark.IsCompleted = true;
                Console.WriteLine($"The task {taskId} has been completed");

            }
            
        }

        
        
        private static void DisplayMenu()
        {
            Console.WriteLine("*******Task Manager*******");
            Console.WriteLine("1. Add Task.");
            Console.WriteLine("2. Read Tasks.");
            Console.WriteLine("3. Mark Tasks as completed.");
            Console.WriteLine("4. Exit.");
        }
    }
}
