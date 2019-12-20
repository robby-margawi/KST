using Microsoft.Extensions.CommandLineUtils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Assessment
{
    class Program
    {
        static void Main(string[] args)
        {
            CommandLineApplication commandLineApplication = new CommandLineApplication();
            commandLineApplication.Name = "name-sorter";
            commandLineApplication.Description = "This command tool help to sort names by last name then given name.";
            commandLineApplication.HelpOption("-? | -h | --help");

            SortNameApp app = new SortNameApp(commandLineApplication);
            commandLineApplication.Execute(args);

            Console.WriteLine("\r");
            Console.WriteLine("Finished.");
            Console.ReadLine();
        }
    }
}
