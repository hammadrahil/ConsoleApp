using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    public class Person
    {
        public string FullName { get; set; } = string.Empty;
        public int Age { get; set; }
        public List<string> CarList { get; set; }

        public Person()
        {
            CarList = new List<string>();
           // Program.Main(null);
        }

        public void AskForFullName()
        {
            Console.WriteLine("What is your name?");
            string fullname = Console.ReadLine() ?? string.Empty;
            FullName = fullname;
        }

        public void AskForCarCompany()
        {
            Console.WriteLine("Can you name a car company?");
            var givenCar = Console.ReadLine() ?? string.Empty;

            CarList.Add(givenCar);
        }

        public void AskForAge()
        {
            Console.WriteLine("What is your age?");
            int age = Convert.ToInt32(Console.ReadLine());
            Age = age;
        }

        public void DisplayInfo()
        {
            Console.WriteLine("Your name is " + FullName + " and you are " + Age + " years old.");
            foreach (var car in CarList) 
            {
                Console.WriteLine(car);
            }
        }
    }
}