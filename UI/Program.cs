using System;
using AwesomeApplication.BL;
using AwesomeApplication.DataAccess;
using AwesomeApplication.Domain;

namespace AwesomeApplication.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var webDataService = new WebDataService("http://localhost:5000/api");
            var bl = new BL.BL(webDataService);

            // Coded UI
        }      

    }
}
