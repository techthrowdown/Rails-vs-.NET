using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Helpers;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Crypto.HashPassword("password"));

            Console.WriteLine("Done");
            Console.ReadLine();
        }
    }
}
