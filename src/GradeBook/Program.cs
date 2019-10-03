using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Dash Grade Book");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.5);
            book.GetStatistiscs();

            var stats = book.GetStatistiscs();

            Console.WriteLine($"The lowest grade is {stats.Low}");
            Console.WriteLine($"The avarage grade is {stats.Average}");
            Console.WriteLine($"The highest grade is {stats.High:N1}");

        }

    }
}
