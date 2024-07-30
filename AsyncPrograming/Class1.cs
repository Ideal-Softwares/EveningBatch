using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncPrograming
{
    public class Class1
    {
        public static string ReadFile(string path)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                return reader.ReadToEnd();
            }
        }

        public static async Task<string> ReadFileAsync(string path)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                return await reader.ReadToEndAsync();
            }
        }

        public static async Task RunAsync()
        {
            string cont = await ReadFileAsync("Abc.txt");
            Console.WriteLine(cont);
        }
        public static void Run()
        {
            string cont = ReadFile("Abc.txt");
            Console.WriteLine(cont);
        }
    }
}
