using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace To_do_list
{
    class Program
    {
        struct Task
        {
            public string Name;
            public int Importance;
            public int date;
            public int Month;
            public int year;

            public Task(string tName, int tImportance, int tdate, int tMonth, int tyear)
            {
                Name = tName;
                Importance = tImportance;
                date = tdate;
                Month = tMonth;
                year = tyear;
            }

            public override string ToString()
            {
                return $"Task Name: {Name}, Importance: {Importance}, Date: {date}/{Month}/{year}";
            }
        }

        static void Main(string[] args)
        {
            List<Task> ToDoList = new List<Task>();
            InputtingList(ToDoList);
            bool AddSomething = true;
            while (AddSomething)
            {
                if (ToDoList.Count == 0)
                {
                    Console.WriteLine("You have no tasks added");
                }
                else
                {
                    for (int i = 0; i < ToDoList.Count; i++)
                    {
                        Console.WriteLine(ToDoList[i]);
                    }
                }
                Console.WriteLine("Would you like to add something to your list?");
                Console.WriteLine("1. Yes");
                Console.WriteLine("2. No");
                int choice = int.Parse(Console.ReadLine());
                if (choice == 1)
                {
                    AddingThingsToList(ToDoList);
                }
                else
                {
                    AddSomething = false;
                }
            }
            OutputtingList(ToDoList);
            RemovingTasks(ToDoList);
        }

        static void AddingThingsToList(List<Task> ToDoList)
        {
            Console.WriteLine("Add something to your to-do list:");
            string taskName = Console.ReadLine();
            Console.WriteLine("Enter the importance out of 10:");
            int importance = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the date it needs to be completed by (dd/mm/yyyy):");
            string stringDate = Console.ReadLine();
            string[] stringDates = stringDate.Split('/');
            int date = int.Parse(stringDates[0]);
            int month = int.Parse(stringDates[1]);
            int year = int.Parse(stringDates[2]);
            Task addingTask = new Task(taskName, importance, date, month, year);
            ToDoList.Add(addingTask);
            Console.WriteLine();
        }

        static void OutputtingList(List<Task> ToDoList)
        {
            if (ToDoList.Count == 0)
            {
                Console.WriteLine("You have no tasks added");
            }
            else
            {
                for (int i = 0; i < ToDoList.Count; i++)
                {
                    Console.WriteLine((i + 1) + ". " + ToDoList[i]);
                }
            }
        }

        static void RemovingTasks(List<Task> ToDoList)
        {
            int decision = 1;
            while (decision == 1)
            {
                if (ToDoList.Count == 0)
                {
                    Console.WriteLine("You have no tasks left. Exiting Program...");
                    Environment.Exit(0);
                }
                Console.WriteLine("Which task would you like to mark as completed?");
                int choice = int.Parse(Console.ReadLine());
                choice--;
                ToDoList.RemoveAt(choice);
                Console.WriteLine("This is your updated list:");
                OutputtingList(ToDoList);
                Console.WriteLine("Would you like to go again?");
                Console.WriteLine("1. Yes");
                Console.WriteLine("2. No");
                decision = int.Parse(Console.ReadLine());
            }
        }

        static void InputtingList(List<Task> ToDoList)
        {
            StreamReader fileToRead = new StreamReader("C:/Numbers.txt");
            int numOfLines = 0;
            while (fileToRead.ReadLine() != null)
            {
                string[] sections = fileToRead.ReadLine().ToString().Split(',');
                Task temp = new Task(sections[0], int.Parse(sections[1]), int.Parse(sections[2]), int.Parse(sections[3]), int.Parse(sections[4]));
                ToDoList.Add(temp);
                Console.WriteLine(temp);
            }
            for (int i = 0; i < numOfLines; i++)
            {
                // Your additional logic here
            }
        }
    }
}
