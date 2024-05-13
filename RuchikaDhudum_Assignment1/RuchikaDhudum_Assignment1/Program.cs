using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuchikaDhudum_Assignment1
{
    public class Program
    {
        static List<String> taskList = new List<String>();
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Simple Task List Apllication...");
            int option = 5;
    
            while (option <= 5)
            {
                Console.WriteLine("Enter option 1 : To create the task.");
                Console.WriteLine("Enter option 2 : To Read the task.");
                Console.WriteLine("Enter option 3 : To update the task.");
                Console.WriteLine("Enter option 4 : To delete the task.");
                Console.WriteLine("Enter option 5 : To exit the application.");
                Console.WriteLine();
                Console.WriteLine("Enter your choice.");
                int Choice = Convert.ToInt32(Console.ReadLine());
                switch (Choice)
                {

                    case 1:
                        createTask();
                        break;
                   
                    case 2:
                        readTask();
                        break;
                    
                    case 3:
                        updateTask();
                        break;
                    
                    case 4:
                        deleteTask();
                        break;
                    
                    case 5:
                        Console.WriteLine("Exiting... The application.");
                        Console.WriteLine("Thank You So Much ...");
                        return;
                       
                    default:
                        Console.WriteLine("Invalid input!!!..Please select the choice between range 1 to 5.");
                        break;
                        

                }

            }
        }

        static void createTask()
        {
            Console.WriteLine("Enter the title of the task. ");
            String title = Console.ReadLine();
            taskList.Add(title);
            Console.WriteLine("Enter the task description.");
            String desc = Console.ReadLine();
            taskList.Add(desc);
            Console.WriteLine("Task is created successfully....");
            Console.ReadLine();
        }

        static void readTask()
        {
            Console.WriteLine("list of Tasks with their title and descriptions :");
            Console.WriteLine();
            if(taskList.Count == 0)
            {
                Console.WriteLine("There are no tasks present in the list.");
            }
            else
            {
                foreach(var tasks in taskList)
                {
                    
                    Console.WriteLine("- " + tasks);
                   
                }
            }
            Console.ReadLine();
        }

        static void updateTask()
        {
            Console.WriteLine("Enter the index number of the task to update.");
            int iNum = Convert.ToInt32(Console.ReadLine());
            if(iNum >= 0 && iNum < taskList.Count)
            {
                Console.WriteLine("Enter the updated task name.");
                String newTask = Console.ReadLine();
                taskList[iNum] = newTask;
                Console.WriteLine("Task name is updated successfully..");

            }
            else
            {
                Console.WriteLine("Invalid input !!...Please give valid number of task.");
            }
            Console.ReadLine();

        }

        static void deleteTask()
        {
            Console.WriteLine("Enter the index number of task that needs to be deleted....");
            int iNum1 = Convert.ToInt32(Console.ReadLine());
            if(iNum1 >= 0 && iNum1 < taskList.Count)
            {
                taskList.RemoveAt(iNum1);
                Console.WriteLine("task is deleted successfully....");
            }
            else
            {
                Console.WriteLine("Invalid input !!...Please give valid number of task.");
            }
            Console.ReadLine();

        }

        
    }
}


