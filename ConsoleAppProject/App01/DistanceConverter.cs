using System;

namespace ConsoleAppProject.App01
{
    /// <summary>
    /// This App will be prompting the user to input a distance
    /// measured in one unit (fromUnit) and it will then calculate and
    /// output the equivalent distance in another unit (toUnit).
    /// </summary>
    /// <author>
    /// Noman Syed version 0.1
    /// </author>
    public class DistanceConverter
    {
        public const int FEET_IN_MILES = 5280;

        public const double METRES_IN_MILES = 1609.34;

        public const double FEET_IN_METRES = 3.28084;

        public const string FEET = "Feet";
        public const string METRES = "Metres";
        public const string MILES = "Miles";

        private double fromDistance;
        private double toDistance;

        private string fromUnit;
        private string toUnit;

        public DistanceConverter()
        {
            fromUnit = MILES;
            toUnit = FEET;
        }

        /// <summary>
        /// This method will input thee distance measured in miles
        /// calculate the same distance in feet, and output the 
        /// distance in feet.
        /// </summary>



        public void ConvertDistance()
        {
            OutputHeading();

            fromUnit = SelectUnit(" Please select the from distance unit > ");
            toUnit = SelectUnit(" Now please select the distance unit your selected unit should be converted to > ");


            Console.WriteLine($"\n Converting {fromUnit} to {toUnit}");

            fromDistance = InputDistance($" Please enter the number of {fromUnit} > ");

            CalculateDistance();

            OutputDistance();

        }

        private void CalculateDistance()
        {
            if (fromUnit == MILES && toUnit == FEET)
            {
                toDistance = fromDistance * FEET_IN_MILES;
            }
            else if (fromUnit == FEET && toUnit == MILES)
            {
                toDistance = fromDistance / FEET_IN_MILES;
            }
            else if (fromUnit == MILES && toUnit == METRES)
            {
                toDistance = fromDistance * METRES_IN_MILES;
            }
            else if (fromUnit == METRES && toUnit == MILES)
            {
                toDistance = fromDistance / METRES_IN_MILES;
            }
            else if (fromUnit == FEET && toUnit == METRES)
            {
                toDistance = fromDistance / FEET_IN_METRES;
            }
            else if (fromUnit == METRES && toUnit == FEET)
            {
                toDistance = fromDistance * FEET_IN_METRES;
            }

            // Round the toDistance to 2 decimal places
            toDistance = Math.Round(toDistance, 2);
        }

        private string SelectUnit(string prompt)
        {
            string choice;
            string unit;

            do
            {
                choice = DisplayChoices(prompt);
                unit = ExecuteChoice(choice);

                if (unit == null)
                {
                    Console.WriteLine("\nInvalid choice! Please select a valid option.");
                }

            } while (unit == null);

            Console.WriteLine($"\nYou have chosen {unit}");
            return unit;
        }

        private static string ExecuteChoice(string choice)
        {
            if (choice.Equals("1"))
            {
                return FEET;
            }
            else if (choice == "2")
            {
                return METRES;
            }

            else if (choice.Equals("3"))
            {
                return MILES;
            }
            return null;
        }

        private static string DisplayChoices(string prompt)
        {
            Console.WriteLine();
            Console.WriteLine($" 1. {FEET}");
            Console.WriteLine($" 2. {METRES}");
            Console.WriteLine($" 3. {MILES}");
            Console.WriteLine();

            Console.Write(prompt);
            string choice = Console.ReadLine();
            return choice;
        }



        /// <summary>
        /// Prompt the user to enter thew distance in miles
        /// Input the miles as a double number
        /// </summary>
        private double InputDistance(string prompt)
        {
            double enteredDistance = 0.00;
            bool isValidInput = false;
            do
            {
                Console.Write(prompt);
                string value = Console.ReadLine();
                try
                {
                    enteredDistance = Convert.ToDouble(value);
                    isValidInput = true;
                    if (enteredDistance < 0)
                    {
                        isValidInput = false;
                        Console.WriteLine("Invalid Input");
                    }
                }
                catch (Exception E)
                {
                    Console.WriteLine("Invalid Input! Please enter a valid number.");
                }
            } while (!isValidInput);

            return enteredDistance;
        }


        private void OutputDistance()
        {
            Console.WriteLine($"\n {fromDistance}  {fromUnit}" +
                $" is  {toDistance} {toUnit} !\n");
        }


        private void OutputHeading()
        {
            Console.WriteLine("\n----------------------------------------------------------");
            Console.WriteLine("            Distance Converter created by                  ");
            Console.WriteLine("                    Noman Syed                             ");
            Console.WriteLine("-----------------------------------------------------------\n");

        }
    }
}