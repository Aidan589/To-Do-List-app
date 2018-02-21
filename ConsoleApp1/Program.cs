using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Options opt = new Options();
            Console.WriteLine("To Do list");
            char userInput;
            do
            {
                Console.WriteLine("\nOptions: \nAdd - A \nDelete - D \nDisplay List - L \nOpen - O \nSave - S \nExit - E");
                userInput = char.ToUpper(Console.ReadKey().KeyChar);

                if (userInput == 'A')
                {
                    opt.AddToList();
                }

                if (userInput == 'D')
                {
                    opt.DeleteFromList();
                }

                if (userInput == 'L')
                {
                    opt.DisplayList();
                }

                if (userInput == 'O')
                {
                    Console.Write("\nEnter a file name to open a list: ");
                    string fileName = Console.ReadLine();
                    opt.LoadFromFile(fileName);
                }

                if (userInput == 'S')
                {
                    Console.Write("\nEnter a file name to save a list: ");
                    string fileName = Console.ReadLine();
                    opt.SaveToFile(fileName);
                }

            } while (userInput != 'E');
        }
    }

    class Options
    {
        private List<string> toDo = new List<string>();

        public void AddToList()
        {
            Console.WriteLine("\nType in what you need to do: ");
            toDo.Add(Console.ReadLine());
            Console.WriteLine("\nSuccessfully added");
        }

        public void DeleteFromList()
        {
            if (IsEmpty() == false)
            {
                DisplayList();
            }
            else
            {
                DisplayList();
                Console.WriteLine("\nEnter the number of the one you want to delete: ");
                bool pass = false;

                while (pass == false)
                {
                    string userInput = Console.ReadLine();
                    int inputNumber;
                    if (!int.TryParse(userInput, out inputNumber))
                    {
                        Console.WriteLine("{0} is not an integer", userInput);
                    }
                    else if (inputNumber > toDo.Count)
                    {
                        Console.WriteLine("Number is out of range");
                    }
                    else
                    {
                        pass = true;
                        toDo.RemoveAt((inputNumber-1));
                        Console.WriteLine("\nSuccessfully deleted");
                    }
                }
            }
        }
        public void DisplayList()
        {
            if (IsEmpty() == false)
            {
                Console.WriteLine("The current list is empty. Try adding a to-do or load a to-do");
            }
            else
            {
                for (int i = 0; i < toDo.Count; i++)
                {
                    string number = (i + 1).ToString();
                    Console.WriteLine($"\n{number}. {toDo[i]}");
                }
            }
        }

        public void SaveToFile(string fileName)
        {
            var csv = "";
            for (int i = 0; i < toDo.Count; i++)
            {
                csv += toDo[i];
                if (i < toDo.Count - 1) csv += "\n";
            }
            fileName += ".txt";
            File.WriteAllText(fileName, csv);
        }
        public void LoadFromFile(string fileName)
        {
            toDo.Clear();
            string content = File.ReadAllText((fileName += ".txt"));
            string[] recs = content.Split('\n');

            for (int i = 0; i < recs.Count(); i++)
            {
                toDo.Add(recs[i]);
            }
        }

        public bool IsEmpty()
        {
            if (!toDo.Any())
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
