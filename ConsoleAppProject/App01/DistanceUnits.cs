using System;
using System.ComponentModel.DataAnnotations;

namespace ConsoleAppProject.App01
{
    /// <summary>
    /// List of units used to measure distance
    /// </summary>
    using System;

    namespace ConsoleAppProject.App01
    {
        public enum DistanceUnit
        {
            Feet,
            Metres,
            Miles,
        }

        public class DistanceConverter
        {
            private const int FEET_IN_MILES = 5280;
            private const double METRES_IN_MILES = 1609.34;
            private const double FEET_IN_METRES = 3.28084;

            private double fromDistance;
            private double toDistance;

            private DistanceUnit fromUnit;
            private DistanceUnit toUnit;

            public DistanceConverter()
            {
                fromUnit = DistanceUnit.Miles;
                toUnit = DistanceUnit.Feet;
            }

            public void ConvertDistance()
            {
                OutputHeading();

                fromUnit = SelectUnit("Please select the from distance unit > ");
                toUnit = SelectUnit("Please select the to distance unit > ");

                Console.WriteLine($"\nConverting {fromUnit} to {toUnit}");

                fromDistance = InputDistance($"Please enter the number of {fromUnit} > ");

                CalculateDistance();

                OutputDistance();
            }

            private void CalculateDistance()
            {
                switch (fromUnit)
                {
                    case DistanceUnit.Miles:
                        toDistance = toUnit switch
                        {
                            DistanceUnit.Feet => fromDistance * FEET_IN_MILES,
                            DistanceUnit.Metres => fromDistance * METRES_IN_MILES,
                            _ => 0,
                        };
                        break;
                    case DistanceUnit.Feet:
                        toDistance = toUnit switch
                        {
                            DistanceUnit.Miles => fromDistance / FEET_IN_MILES,
                            DistanceUnit.Metres => fromDistance / FEET_IN_METRES,
                            _ => 0,
                        };
                        break;
                    case DistanceUnit.Metres:
                        toDistance = toUnit switch
                        {
                            DistanceUnit.Miles => fromDistance / METRES_IN_MILES,
                            DistanceUnit.Feet => fromDistance * FEET_IN_METRES,
                            _ => 0,
                        };
                        break;
                }
            }

            private DistanceUnit SelectUnit(string prompt)
            {
                DistanceUnit unit;
                string choice;

                do
                {
                    choice = DisplayChoices(prompt);
                    unit = ExecuteChoice(choice);

                    if (unit == DistanceUnit.Miles || unit == DistanceUnit.Feet || unit == DistanceUnit.Metres)
                    {
                        Console.WriteLine($"\nYou have chosen {unit}");
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid choice! Please select a valid option.");
                    }
                } while (unit != DistanceUnit.Miles && unit != DistanceUnit.Feet && unit != DistanceUnit.Metres);

                return unit;
            }

            private static string DisplayChoices(string prompt)
            {
                Console.WriteLine();
                Console.WriteLine("1. Feet");
                Console.WriteLine("2. Metres");
                Console.WriteLine("3. Miles");
                Console.WriteLine();

                Console.Write(prompt);
                return Console.ReadLine();
            }

            private static DistanceUnit ExecuteChoice(string choice)
            {
                return choice switch
                {
                    "1" => DistanceUnit.Feet,
                    "2" => DistanceUnit.Metres,
                    "3" => DistanceUnit.Miles,
                    _ => 0,
                };
            }

            private double InputDistance(string prompt)
            {
                Console.Write(prompt);
                string value = Console.ReadLine();
                return Convert.ToDouble(value);
            }

            private void OutputDistance()
            {
                Console.WriteLine($"\n{fromDistance} {fromUnit} is {toDistance} {toUnit}!\n");
            }

            private void OutputHeading()
            {
                Console.WriteLine("\n---------------------------------------------------");
                Console.WriteLine("             Distance Converter created           ");
                Console.WriteLine("                    Noman Syed                    ");
                Console.WriteLine("-----------------------------------------------------\n");
            }
        }
    }
}