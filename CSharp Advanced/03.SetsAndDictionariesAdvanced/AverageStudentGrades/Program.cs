using System;
using System.Threading;
using System.Linq;
using System.Collections.Generic;

namespace AverageStudentGrades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.GetCultureInfo("en-US");

            Dictionary<string, List<decimal>> students = new Dictionary<string, List<decimal>>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] line = Console.ReadLine().Split(' ');

                if (!students.ContainsKey(line[0]))
                {
                    students.Add(line[0], new List<decimal>());
                }

                students[line[0]].Add(decimal.Parse(line[1]));
            }

            foreach (KeyValuePair<string, List<decimal>> student in students)
            {
                Console.WriteLine($"{student.Key} -> {string.Join(' ', student.Value)} (avg: {student.Value.Average():f2})");
            }
        }
    }
}
