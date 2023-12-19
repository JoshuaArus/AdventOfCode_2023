using System.Reflection;
using System.Text.RegularExpressions;

namespace AdventOfCode_2023
{
    class Program
    {
        static void Main(string[] args)
        {
            string classRegex = @"^AdventOfCode_2023\.Day_[0-9]{1,2}$";

            Console.WriteLine();
            Console.WriteLine();

            foreach (
                string classe in
                    Assembly
                    .GetExecutingAssembly()
                    .GetTypes()
                    .Select(t => t.FullName)
                    .Where(s => Regex.IsMatch(s, classRegex)))
            {
                try
                {
                    Console.WriteLine(classe.Split('.').Last().ToUpper());
                    Activator.CreateInstance(null, classe);
                }
                catch (Exception)
                {
                    //nvw
                }
                Console.WriteLine();
            }
        }
    }
}