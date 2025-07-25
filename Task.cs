using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTaskManager
{
    internal class Task
    {
        public int TaskID;
        public string Description;
        public DateTime DueDate;
        public bool IsCompleted;

        // Add constructor to simplify task creation

        public Task(int taskId, string description, DateTime dueDate)
        {
            TaskID = taskId;
            Description = description;
            DueDate = dueDate;
            IsCompleted = false; // Default to not completed
        }

    }
}
