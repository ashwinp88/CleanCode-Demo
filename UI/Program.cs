using System;

namespace AwesomeApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var bl = new BL();

            Console.WriteLine("Welcome to My Awesome Application..");
            Console.WriteLine("Available commands.. ");
            Console.WriteLine("\tlist - prints list of people");
            Console.WriteLine("\trefresh - refreshes list of people from web service");
            Console.WriteLine("\tclear - clears list of people from web service");
            Console.WriteLine("\tbye - quit");

            Console.WriteLine();
            bool done = false;
            while(!done)
            {
                var cmd = Console.ReadLine().ToLower().Trim();
                switch(cmd)
                {
                    case "list":
                        foreach(var person in bl.People)
                        {
                            Console.WriteLine($"\tId = {person.Id}, FirstName = {person.FirstName}, LastName = {person.LastName}");
                        }
                        break;
                    case "refresh":
                        bl.RefreshPeople();
                        Console.WriteLine("\tRefreshed list of people");
                        break;
                    case "clear":
                        bl.ClearPeople();
                        Console.WriteLine("\tCleared list of people");
                        break;
                    case "bye":
                        Console.WriteLine("\tBye");
                        done = true;
                        break;
                }
            }
        }      

    }
}
