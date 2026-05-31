using Csharp.Entites;
using Csharp.Entites.Model;
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

        public PersonEntity AskForUserName(Context context)
        {
           Console.WriteLine("What is your name?");
           string givenName = Console.ReadLine() ?? string.Empty;

            var foundPerson = context.PersonEntity.FirstOrDefault(x => x.FullName == givenName);
            FullName = foundPerson.FullName;
            Age = foundPerson.Age;
            return foundPerson;
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

        public void SaveCarCompanyInDatabase(Context context, PersonEntity personEntity)
        {
            foreach (var carItem in CarList)
            {
                context.CarCompanies.Add(new CarCompany()
                {
                    CarID = Guid.NewGuid(),
                    CarCompanyName = carItem,
                    PersonEntityID = personEntity.PersonEntityID
                });
            }
            context.SaveChanges();
        }

        public PersonEntity SavePersonInDatabase(Context Context)
        {
            var newPersonEntity = new Csharp.Entites.Model.PersonEntity()
            {
                PersonEntityID = Guid.NewGuid(),
                FullName = FullName,
                Age = Age
            };
            Context.PersonEntity.Add(newPersonEntity);
            Context.SaveChanges();
            return newPersonEntity;
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