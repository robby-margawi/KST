using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Assessment
{
    /// <summary>
    /// File reader class.
    /// </summary>
    public static class FileHelper
    {
        /// <summary>
        /// Read file.
        /// </summary>
        /// <param name="filePath">The given file path.</param>
        /// <returns>Collection of string.</returns>
        public static string[] Read(string filePath)
        {
            var names = new List<string>();
            using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
            {
                using (var reader = new StreamReader(fileStream))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (!string.IsNullOrWhiteSpace(line))
                            names.Add(line.Trim());
                    }
                }
            }           

            return names.ToArray();
        }

        /// <summary>
        /// Write names to a text file
        /// </summary>
        /// <param name="data">name array</param>
        public static void Write(string filePath, string[] data)
        {
            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                using (var writer = new StreamWriter(fileStream))
                {
                    writer.NewLine = "\r\n";

                    foreach (var line in data)
                    {
                        writer.WriteLine(line);
                    }
                }
            }
        }
    }
}
