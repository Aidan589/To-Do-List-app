using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                Console.WriteLine("Options: \nAdd - A \nDelete - D \nDisplay List - L \nOpen - O \nSave - S \nExit - E");
                userInput = char.ToUpper(Console.ReadKey().KeyChar);

                if(userInput == 'A')
                {
                    opt.AddToList();
                }

                if(userInput == 'D')
                {
                    opt.DeleteFromList();
                }

                if (userInput == 'L')
                {
                    opt.DisplayList();
                }

                if(userInput == 'O')
                {

                }

                if(userInput == 'S')
                {

                }

            } while(userInput != 'E');
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
            DisplayList();
            Console.WriteLine("\nEnter the number of the one you want to delete: ");
            bool pass = false;

            while(pass == false)
            {
                string userInput = Console.ReadLine();
                int inputNumber;
                if (!int.TryParse(userInput, out inputNumber))
                {
                    Console.WriteLine("{0} is not an integer", userInput);
                }
                else if(inputNumber > toDo.Count())
                {
                    Console.WriteLine("Number is out of range");
                }
                else
                {
                    pass = true;
                }
            }

            //toDo.Remove(Console.ReadLine().toint());
            Console.WriteLine("\nSuccessfully deleted");
        }
        public void DisplayList()
        {
            if (IsEmpty() == false) {  }
            else
            {
                for (int i = 0; i < toDo.Count(); i++)
                {
                    string number = (i + 1).ToString();
                    Console.WriteLine($"\n{number}. {toDo[i]}");
                }
            }
        }
        public bool IsEmpty()
        {
            if (!toDo.Any())
            {
                Console.WriteLine("The current list is empty. Try adding a to-do or load a to-do");
                return false;
            }
            else
            {
                return true;
            }
        }


    }
}
