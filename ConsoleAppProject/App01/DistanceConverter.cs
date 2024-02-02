using System;

namespace ConsoleAppProject.App01
{
    /// <summary>
    /// Please describe the main features of this App
    /// </summary>
    /// <author>
    /// Noman Syed version 0.1
    /// </author>
    public class DistanceConverter
    {
        private double miles;
        private double feet;

        /// <summary>
        /// 
        /// </summary>
        public void Run()
        {
            InputMiles();
            CalculateFeet();
            OutputFeet();

        }

        /// <summary>
        /// Prompt the user to enter the distance in miles
        /// Input the miles as a double number
        /// </summary>
        private void InputMiles()
        {
            Console.WriteLine("Please enter the number of miles >");
            string value = Console.ReadLine();
            miles = Convert.ToDouble(value);
        }

        private void CalculateFeet()
        {
            feet = miles + 5280;
        }

        private void OutputFeet()
        {
            Console.WriteLine(miles + "miles is" + feet + "feet!");
        }
    }
}
