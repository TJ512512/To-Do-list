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
        }
        static void Main(string[] args)
        {
            List<Task> ToDoList = new List<Task>();
            InputtingList(ToDoList);
            bool AddSomething = true;
            while (AddSomething == true)
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
                Console.WriteLine("Would you like to add somethine to your list?");
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
            Console.WriteLine("Add something to your to do list");
            string Task = Console.ReadLine();
            ToDoList.Add(Task);
            Console.WriteLine();
        }
        static void OutputtingList(List<string> ToDoList)
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
        static void RemovingTasks(List<string> ToDoList)
        {
            int Decision = 1;
            while (Decision == 1)
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
                Console.WriteLine("This is your updated list: ");
                OutputtingList(ToDoList);
                Console.WriteLine("Would you like to go again?");
                Console.WriteLine("1. Yes");
                Console.WriteLine("2. No");
                Decision = int.Parse(Console.ReadLine());
            }
        }
        static void InputtingList(List<Task> ToDoList)
        {
            StreamReader fileToRead = new StreamReader("C:/Numbers.txt");
            string txt = fileToRead.ReadToEnd(); // read entire contents
            while (fileToRead.ReadLine() != null)
            {
                string[] Sections = fileToRead.ReadLine().Split(',');
                Task temp = new Task(Sections[0], int.Parse(Sections[1]), int.Parse(Sections[2]), int.Parse(Sections[3]), int.Parse(Sections[4]));
                ToDoList.Add(temp);
            }
        }
    }
}