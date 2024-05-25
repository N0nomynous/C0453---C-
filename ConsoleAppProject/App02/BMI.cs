using System;
namespace ConsoleAppProject.App02
{
    /// <summary>
    /// The main feature of this app is being able
    /// to be used as a BMI (Body mass index) calculator
    /// so that the user can input their weight & height
    /// and get a analysis of his body as an output.
    /// </summary>
    /// <author>
    /// Noman Syed version 0.1
    /// </author>
        class BMI
        {
            public void Main()
            {

                Console.WriteLine("\n----------------------------------------------------------");
                Console.WriteLine("                  BMI Calculator                            ");
                Console.WriteLine("                  by Noman Syed                             ");
                Console.WriteLine("------------------------------------------------------------\n");

                Console.WriteLine("Choose your preferred unit system:");
                Console.WriteLine("1. Metric Units");
                Console.WriteLine("2. Imperial Units");
                Console.Write("Enter preferred system number: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                double weight, height;

                if (choice == 1)
                {
                    Console.Write("\nEnter your weight in kilograms: ");
                    weight = Convert.ToDouble(Console.ReadLine());

                    Console.Write("Enter your height in meters: ");
                    height = Convert.ToDouble(Console.ReadLine());
                }
                else if (choice == 2)
                {
                    Console.Write("\nEnter your weight in stones: ");
                    double weightStones = Convert.ToDouble(Console.ReadLine());

                    Console.Write("Enter your weight in pounds: ");
                    double weightPounds = Convert.ToDouble(Console.ReadLine());

                    Console.Write("Enter your height in feet: ");
                    double heightFeet = Convert.ToDouble(Console.ReadLine());

                    Console.Write("Enter your height in inches: ");
                    double heightInches = Convert.ToDouble(Console.ReadLine());

                    // Convert height and weight to metric units
                    weight = (weightStones * 6.35029) + (weightPounds * 0.453592);
                    height = (heightFeet * 0.3048) + (heightInches * 0.0254);
                }
                else
                {
                    Console.WriteLine("\nInvalid choice.");
                    return;
                }

                // Calculate BMI
                double bmi = CalculateBMI(weight, height);

                // Display BMI
                Console.WriteLine("\nYour BMI is: " + bmi.ToString("F2"));

                // Check BMI category
                string bmiCategory = GetBMICategory(bmi);
                Console.WriteLine("BMI Category: " + bmiCategory);

                // Display messages based on BMI category
                DisplayMessage(bmiCategory);

                Console.ReadLine();
            }

            public void DisplayMessage(string bmiCategory)
            {
                Console.WriteLine();

                switch (bmiCategory)
                {
                    case "Underweight":
                        Console.WriteLine("If you are Black, Asian, or other minority ethnic groups, " +
                            "you have a higher risk.");
                        Console.WriteLine("Adults at 23.0 or more are at increased risk.");
                        break;


                    case "Normal weight":
                        Console.WriteLine("You have a normal BMI. Keep at it!");
                        break;
                    case "Overweight":
                        Console.WriteLine("Adults at 23.0 or more are at increased risk.");
                        break;
                    case "Obese":
                        Console.WriteLine("Adults at 27.5 or more are at high risk.");
                        break;
                    default:
                        Console.WriteLine("Unknown BMI category.");
                        break;
                }
            }

            // Method to calculate BMI
            static double CalculateBMI(double weight, double height)
            {
                // BMI formula: weight / (height * height)
                double bmi = weight / (height * height);
                return bmi;
            }

            // Method to get BMI category
            static string GetBMICategory(double bmi)
            {
                if (bmi < 18.5)
                {
                    return "Underweight";
                }
                else if (bmi < 24.9)
                {
                    return "Normal weight";
                }
                else if (bmi < 29.9)
                {
                    return "Overweight";
                }
                else
                {
                    return "Obese";
                }
            }

        }
    }