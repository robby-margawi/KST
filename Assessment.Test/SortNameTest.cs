using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assessment.Test
{
    [TestClass]
    public class SortNameTest
    {
        [TestMethod]
        public void SortName()
        {
            try
            {
                string fileName = "unsorted-name-list.txt";

                if (!File.Exists(fileName))
                    throw new Exception($"{fileName} not found.");

                string output = null;
                if (string.IsNullOrWhiteSpace(output))
                {
                    var input = new FileInfo(fileName);
                    output = Path.Combine(input.Directory.FullName, "sorted-names-list.txt");
                }

                var data = FileHelper.Read(fileName);
                Array.Sort(data, new SortNameComparer());
                FileHelper.Write(output, data);

                Assert.AreEqual(File.Exists(output), true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
