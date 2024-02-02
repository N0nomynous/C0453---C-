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
        public const int FEET_IN_MILES = 5280;

        public const double METRES_IN_MILES = 1609.34;

        private double miles;

        private double feet;

        private double metres;

        /// <summary>
        /// 
        /// </summary>
        public void MilesToFeet()
        {
            OutputHeading();
            InputMiles();
            CalculateFeet();
            OutputFeet();

        }

        public void FeetToMiles()
        {
            OutputHeading();
            InputMiles();
            CalculateFeet();
            OutputFeet();

        }

        public void MilesToMetres()
        {
            OutputHeading();
            InputMiles();
            CalculateFeet();
            OutputFeet();

        }

        private void OutputHeading()
        {
            Console.WriteLine("\n--------------------------------------------------");
            Console.WriteLine("            Distance Converter created by         ");
            Console.WriteLine("                    Noman Syed                    ");
            Console.WriteLine("--------------------------------------------------\n");
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
            Console.WriteLine(miles + " miles is " + feet + " feet!");
        }
    }
}
