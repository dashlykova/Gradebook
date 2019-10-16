﻿using System;
using System.Collections.Generic;

namespace GradeBook
{
  class Program
  {
    static void Main(string[] args)
    {
      var book = new Book("Dash Grade Book");


      while (true)
      {
        Console.WriteLine("Enter a grade or 'q' to quit");
        var input = Console.ReadLine();
        if (input == "q")
        {
          break;
        }

        try
        {
          var grade = double.Parse(input);
          book.AddGrade(grade);
        }
        catch (ArgumentException ex)
        {
          Console.WriteLine(ex.Message);
        }
        catch (FormatException ex)
        {
          Console.WriteLine(ex.Message);
        }
        finally
        {
          Console.WriteLine("**");
        }

      }
      book.GetStatistiscs();

      var stats = book.GetStatistiscs();

      Console.WriteLine($"The lowest grade is {stats.Low}");
      Console.WriteLine($"The avarage grade is {stats.Average}");
      Console.WriteLine($"The highest grade is {stats.High:N1}");
      Console.WriteLine($"The letter grade is {stats.Letter}");

    }

  }
}
