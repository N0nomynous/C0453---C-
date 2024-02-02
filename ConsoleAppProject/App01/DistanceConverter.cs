using System;

namespace ConsoleAppProject.App01
{
    /// <summary>
    /// This App has been designed & created to simply use the three main distance measurement units to let the user enter a distance in numbers and the application will then convert the distance to the measurement unit chosen by the user.
    /// </summary>
    /// <author>
    /// Noman Syed version 1
    /// </author>
    public class DistanceConverter
    {
        private double distance;
        private string inputUnit;
        private string outputUnit;

        public const double METERS_IN_MILE = 1609.34;
        public const int FEET_IN_MILE = 5280;

        public void Run()
        {
            OutputHeading();
            InputDistance();
            InputUnits();
            CalculateDistance();
            OutputDistance();
        }

        private void OutputHeading()
        {
            Console.WriteLine("\n------------------------------------");
            Console.WriteLine("        Distance Converter         ");
            Console.WriteLine("          by Noman Syed             ");
            Console.WriteLine("------------------------------------\n");
        }

        private void InputDistance()
        {
            int maxAttempts = 3;
            int attempts = 0;

            do
            {
                Console.Write("Please enter the distance in numbers: ");
                string value = Console.ReadLine();

                try
                {
                    distance = Convert.ToDouble(value);
                    break; // Break out of the loop if conversion is successful
                }
                catch (FormatException)
                {
                    attempts++;
                    Console.WriteLine("Invalid input. Please enter a valid number.");

                    if (attempts >= maxAttempts)
                    {
                        Console.WriteLine($"Exceeded maximum attempts ({maxAttempts}). Exiting program.");
                        Environment.Exit(0); // Exit the program if max attempts are reached
                    }
                }
            } while (true);
        }

        private void InputUnits()
        {
            Console.Write("Enter the input unit (miles, feet, meters): ");
            inputUnit = Console.ReadLine().ToLower();

            Console.Write("Enter the output unit (miles, feet, meters): ");
            outputUnit = Console.ReadLine().ToLower();
        }

        private void CalculateDistance()
        {
            if (inputUnit == "miles" && outputUnit == "feet")
            {
                distance *= FEET_IN_MILE;
            }
            else if (inputUnit == "miles" && outputUnit == "meters")
            {
                distance *= METERS_IN_MILE;
            }
            else if (inputUnit == "feet" && outputUnit == "miles")
            {
                distance /= FEET_IN_MILE;
            }
            else if (inputUnit == "feet" && outputUnit == "meters")
            {
                distance /= 3.281; // 1 foot = 0.3048 meters
            }
            else if (inputUnit == "meters" && outputUnit == "miles")
            {
                distance /= METERS_IN_MILE;
            }
            else if (inputUnit == "meters" && outputUnit == "feet")
            {
                distance *= 3.281; // 1 meter = 3.281 feet
            }
        }

        private void OutputDistance()
        {
            Console.WriteLine($"{distance} {outputUnit}");
        }
    }
}
