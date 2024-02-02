using System;
namespace ConsoleAppProject.App01
{
    /// <summary>
    /// This application can be used to convert one of the three measurement units
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
            OutputHeading();
            InputMiles();
            CalculateFeet();
            OutputFeet();
        }

        private void OutputHeading()
        {
            Console.WriteLine(" \n=================================================");
            Console.WriteLine("    Distance Converter by Noman Syed! ");
            Console.WriteLine(" =================================================");
            Console.WriteLine("                                                  \n");
        }

        /// <summary>
        /// Prompt the user to enter the distance in miles
        /// Input the miles as a double number
        /// </summary>
        private void InputMiles()
        {
            Console.Write("Please enter the number of miles you would like to get converted");
            string value = Console.RedLine();
            miles = Convert.ToDouble(value);
        }

        private void CalculateFeet()
        {
            feet = miles * 5280;
        }

        private void OutputFeet()
        {
            Console.WriteLine(miles + "miles is" + feet + "feet!");
        }
    }
}