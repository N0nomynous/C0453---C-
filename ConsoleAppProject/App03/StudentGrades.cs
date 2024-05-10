using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;
using ConsoleAppProject.Helpers;

namespace ConsoleAppProject.App03
{
    /// <summary>
    /// This program allows to let someone put marks 
    /// into the program and the program will then
    /// convert the marks into a grade
    /// </summary>
    public class StudentGrades
    {
        // Constants (Grade Boundaries)

        public const int LowestMark = 0;
        public const int LowestGradeD = 40;
        public const int LowestGradeC = 50;
        public const int LowestGradeB = 60;
        public const int LowestGradeA = 70;
        public const int HighestMark = 100;

        //Properties
        public string[] Students { get; set; }

        public int[] Marks { get; set; }

        public int[] GradeProfile { get; set; }

        public double Mean { get; set; }

        public int Minimum { get; set; }

        public int Maximum { get; set; }

        public StudentGrades()
        {
            Students = new string[]
            {
                "Abdul","Micah","Michael","Josephine",
                "Zaynab", "Hamza", "Balbir", "Leon",
                "Joelle", "Nadine"
            };

            GradeProfile = new int[(int)Grades.A + 1];
            Marks = new int[Students.Length];

        }

        public void Run()
        {
            int Choice;
            string[] choices = {
                $"Input Marks",
                $"Output Marks",
                $"Output Stats",
                $"Output Grade Profile",
                $"Quit"
            };
            do
            {
                ConsoleHelper.OutputHeading("Student Grades");
                Choice = ConsoleHelper.SelectChoice(choices);

                if (Choice == 1)
                {
                    InputMarks();
                }
                else if (Choice == 2)
                {
                    OutputMarks();
                }
                else if (Choice == 3)
                {
                    CalculateStats();
                    OutputStats();
                }
                else if (Choice == 4)
                {
                    CalculateGradeProfile();
                    OutputGradeProfile();
                }

            } while (Choice != 5);
        }

        public void OutputStats()
        {

            Console.WriteLine($" The lowest mark is {Minimum}");
            Console.WriteLine($" The Highest mark is {Maximum}");
            Console.WriteLine($" The average mark is {Mean}");
        }


        /// <summary>
        /// Marks will be put in here.
        /// User is supposed to input a marks from the range 0-100 for
        /// each student and also stores the marks array.
        /// </summary>
        public void InputMarks()
        {
            int currentMark;
            Console.WriteLine(" Please enter the marks for each student:");
            for (int i = 0; i < Students.Length; i++)
            {
                Console.Write($" Marks for {Students[i]}: ");
                while (!int.TryParse(Console.ReadLine(), out currentMark) || currentMark < 0 || currentMark > 100)
                {
                    ConsoleHelper.DisplayErrorMessage(" Invalid input. Please enter a valid mark between 0 and 100.");
                    Console.Write($" Marks for {Students[i]}: ");
                }
                Marks[i] = currentMark;
            }
            Console.WriteLine(" All marks have been inputted");
        }


        /// <summary>
        /// Lists all of the students and display their name as well as their current marks.
        /// </summary>
        public void OutputMarks()
        {
            Console.WriteLine("\n Student Marks and Grades");
            Console.WriteLine("----------------------------");

            for (int i = 0; i < Students.Length; i++)
            {

                string student = Students[i];

                int mark = Marks[i];

                Grades grade = ConvertToGrade(mark);

                Console.WriteLine($" {student} - Mark: {mark}, Grade: {grade}");
            }

            Console.WriteLine();
        }

        /// <summary>
        /// This converts student's marks to a grade
        /// from F (Fail) to A (Exceptional)
        /// </summary>
        public Grades ConvertToGrade(int mark)
        {
            if (mark >= 0 && mark < LowestGradeD)
            {
                return Grades.F;
            }
            else if (mark >= LowestGradeD && mark < LowestGradeC)
            {
                return Grades.D;
            }
            else if (mark >= LowestGradeC && mark < LowestGradeB)
            {
                return Grades.C;
            }
            else if (mark >= LowestGradeB && mark < LowestGradeA)
            {
                return Grades.B;
            }
            else if (mark >= LowestGradeA && mark <= HighestMark)
            {
                return Grades.A;
            }
            return Grades.F;

        }

        /// <summary>
        /// Calculates as well as displays the minimum, maximum
        /// and also overall marks for all the students.
        /// </summary>
        public void CalculateStats()
        {
            double total = 0;

            Minimum = HighestMark;
            Maximum = 0;

            foreach (int mark in Marks)
            {
                total = total + mark;
                if (mark > Maximum) Maximum = mark;
                if (mark < Minimum) Minimum = mark;
            }

            Mean = total / Marks.Length;
        }

        /// <summary>
        /// This method calculates the grade profile based on specified criteria.
        /// This method is intended to calculate a grade profile
        /// </summary>
        public void CalculateGradeProfile()
        {
            for (int i = 0; i < GradeProfile.Length; i++)
            {
                GradeProfile[i] = 0;
            }

            foreach (int mark in Marks)
            {
                Grades grade = ConvertToGrade(mark);
                GradeProfile[(int)grade]++;
            }
        }
        private void OutputGradeProfile()
        {
            Grades grade = Grades.F;
            Console.WriteLine();

            foreach (int count in GradeProfile)
            {
                int percentage = count * 100 / Marks.Length;
                Console.WriteLine($" Grade {grade} {percentage}% Count {count}");
                grade++;
            }
            Console.WriteLine();
        }

    }
}
