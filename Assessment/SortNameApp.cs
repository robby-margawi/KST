using System;
using Microsoft.Extensions.CommandLineUtils;
using System.IO;

namespace Assessment
{
    /// <summary>
    /// Sort name application class.
    /// </summary>
    public class SortNameApp
    {
        /// <summary>
        /// Gets or Sets command line application.
        /// </summary>
        private readonly CommandLineApplication commandLineApplication;

        

        /// <summary>
        /// the default constructor.
        /// </summary>
        /// <param name="commandLineApplication">The command line application instance.</param>
        public SortNameApp(CommandLineApplication commandLineApplication)
        {
            this.commandLineApplication = commandLineApplication;

            CommandArgument fileArgument = this.commandLineApplication.Argument("[file]", "names in text file for sort.");
            CommandArgument outputArgument = this.commandLineApplication.Argument("[output]", "save to a text file after sorted.");

            this.commandLineApplication.OnExecute(() =>
            {
                (new SortNameApp(this.commandLineApplication)).Process(fileArgument, outputArgument);
                return 0;
            });
        }

        /// <summary>
        /// Processing
        /// </summary>
        /// <param name="fileArgument">The input file.</param>
        /// <param name="outputArgument">The output file.</param>
        public void Process(CommandArgument fileArgument, CommandArgument outputArgument)
        {
            try
            {
                var file = fileArgument.Value;
                if (string.IsNullOrWhiteSpace(file))
                    this.commandLineApplication.ShowHelp();

                if (!File.Exists(file))
                    throw new Exception($"{file} not found.");

                var output = outputArgument.Value;
                if (string.IsNullOrWhiteSpace(output))
                {
                    var input = new FileInfo(file);
                    output = Path.Combine(input.Directory.FullName, "sorted-names-list.txt");
                }

                Console.WriteLine("Start processing...");
                Console.WriteLine("\r");

                var data = FileHelper.Read(file);
                Array.Sort(data, new SortNameComparer());
                FileHelper.Write(output, data);

                Array.ForEach(data, Console.WriteLine);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
