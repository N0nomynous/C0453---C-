using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;
using ConsoleAppProject.Helpers;

namespace ConsoleAppProject.App03
{
    /// <summary>
    /// At the moment this class just tests the
    /// Grades enumeration names and descriptions
    /// </summary>
    public class StudentGrades
    {
        public string [] Students { get; set; }

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
                "Zaynab", "Hamza", "Balbir", "Leon"
            };

            GradeProfile = new int[(int)Grades.A + 1];
            Marks = new int[Students.Length];

        }

        /// <summary>
        /// Marks will be put in here.
        /// User is supposed to input a marks from the range 0-100 for
        /// each student and also stores the marks array.
        /// </summary>
        public void InputMarks()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Lists all of the students and display their name as well as their current marks.
        /// </summary>
        public void OutputMarks()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This converts student's marks to a grade
        /// from F (Fail) to A (Exceptional)
        /// </summary>
        public Grades ConvertToGrade(int mark)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Calculates as well as displays the minimum, maximum
        /// and also overall marks for all the students.
        /// </summary>
        public void CalculateStats()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This method calculates the grade profile based on specified criteria.
        /// This method is intended to calculate a grade profile
        /// </summary>
        public void CalculateGradeProfile()
        {
            throw new NotImplementedException();
        }
    }
}
