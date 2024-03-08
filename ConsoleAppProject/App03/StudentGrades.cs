using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;
using ConsoleAppProject.Helpers;

namespace StudentGradeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Student Grade Application\n");

            // Input student names and marks with error handling
            Dictionary<string, int> studentMarks = new Dictionary<string, int>();
            for (int i = 1; i <= 10; i++)
            {
                int mark;
                bool validInput = false;
                do
                {
                    Console.Write($"Enter mark for Student {i}: ");
                    string input = Console.ReadLine();
                    if (int.TryParse(input, out mark))
                    {
                        validInput = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input! Please enter a valid integer mark.");
                    }
                } while (!validInput);

                studentMarks.Add($"Student {i}", mark);
            }

            Console.WriteLine("\nStudent\t\tMark\tGrade");
            Console.WriteLine("--------------------------------");

            // Displaying student names, marks, and grades
            foreach (var student in studentMarks)
            {
                string grade = GetGrade(student.Value);
                Console.WriteLine($"{student.Key}\t{student.Value}\t{grade}");
            }

            Console.ReadLine(); // To keep the console window open
        }

        // Function to determine the grade based on the mark
        static string GetGrade(int mark)
        {
            if (mark >= 90)
                return "A";
            else if (mark >= 80)
                return "B";
            else if (mark >= 70)
                return "C";
            else if (mark >= 60)
                return "D";
            else
                return "F";
        }
    }
}