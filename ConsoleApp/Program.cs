using ConsoleApp;
using Csharp.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
#nullable disable

//String sometext = "Hello, World!";

//List<string> textlist = new List<string>();

//Dictionary<string, string> textDictionary = new Dictionary<string, string>();

//textDictionary.Add("Car", "Bikes");
//textDictionary.Add("House", "Apartment");


//String[] textlist = {"Hello World!", "Hammad Rahil", "I am a software developer.", "I love coding in C#.", };

//textlist.Add(sometext);
//textlist.Add("Hammad Rahil");
//textlist.Add("I am a software developer.");
//textlist.Add("I love coding in C#.");

//Console.WriteLine("What is your name?");
//string fullname = Convert.ToString(Console.ReadLine());
//Console.WriteLine("What is your age?");
//int age = Convert.ToInt32(Console.ReadLine());

//List<string> carlist = new List<string>();

//Console.WriteLine("can you name a car company?");
//var givenCar = Convert.ToString(Console.ReadLine());
//carlist.Add(givenCar);

//Console.WriteLine("can you name a car company?");
//var givenCar2 = Convert.ToString(Console.ReadLine());
//carlist.Add(givenCar2);

//Console.WriteLine("can you name a car company?");
//var givenCar3 = Convert.ToString(Console.ReadLine());
//carlist.Add(givenCar3);

//Console.WriteLine("Your name is " + fullname + " and you are " + age + " years old.");
//Console.WriteLine(carlist[0]);
//Console.WriteLine(carlist[1]);
//Console.WriteLine(carlist[1]);

//Console.ReadLine();



//string fullname = AskForFullName();
//int age = AskForAge();

//List<string> carlist = new List<string>();

//carlist.Add(AskForCarCompany());
//carlist.Add(AskForCarCompany());
//carlist.Add(AskForCarCompany());

//Console.WriteLine("Your name is " + fullname + " and you are " + age + " years old.");
//Console.WriteLine(carlist[0]);
//Console.WriteLine(carlist[1]);
//Console.WriteLine(carlist[1]);

//Console.ReadLine();

//static string AskForFullName()
//{
//Console.WriteLine("What is your name?");
//string fullname = Convert.ToString(Console.ReadLine());
//return fullname;
//}

//static string AskForCarCompany()
//{
//Console.WriteLine("can you name a car company?");
//var givenCar = Convert.ToString(Console.ReadLine());
//return givenCar;
//}

//static int AskForAge()
//{
//Console.WriteLine("What is your age?");
//int age = Convert.ToInt32(Console.ReadLine());
//return age;
//}

public class Program
{
    public static ServiceProvider ServiceProvider { get; set; }

    public static void Main(string[] args)
    {
        _registerServiceProvider();

        Person person = new Person();

        person.AskForFullName();
        person.AskForAge();

        person.AskForCarCompany();
        person.AskForCarCompany();
        person.AskForCarCompany();

        person.DisplayInfo();

        private static void _registerServiceProvider()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddDbContext<Context>(options =>
            {
                options.UseSqlServer("Server=localhost;Database=CarCompanyDB;Trusted_Connection=True;");
            });

            services.AddTransient<Context>();
            
            ServiceProvider = services.BuildServiceProvider();
    }
    }


