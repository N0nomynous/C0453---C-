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
            Console.WriteLine("BMI Calculator");
            Console.WriteLine("--------------");
            Console.WriteLine("This program calculates your Body Mass Index (BMI) and determines your weight status.");
            Console.WriteLine();

            // Prompt the user to enter weight in kilograms
            Console.Write("Enter your weight in kilograms: ");
            double weight = Convert.ToDouble(Console.ReadLine());

            // Prompt the user to enter height in meters
            Console.Write("Enter your height in meters: ");
            double height = Convert.ToDouble(Console.ReadLine());

            // Calculate BMI
            double bmi = weight / (height * height);

            // Display BMI
            Console.WriteLine($"Your BMI is: {bmi:F2}");

            // Determine WHO weight status
            string weightStatus;
            if (bmi < 18.5)
            {
                weightStatus = "Underweight";
            }
            else if (bmi >= 18.5 && bmi <= 24.9)
            {
                weightStatus = "Normal";
            }
            else if (bmi >= 25.0 && bmi <= 29.9)
            {
                weightStatus = "Overweight";
            }
            else if (bmi >= 30.0 && bmi <= 34.9)
            {
                weightStatus = "Obese Class I";
            }
            else if (bmi >= 35.0 && bmi <= 39.9)
            {
                weightStatus = "Obese Class II";
            }
            else
            {
                weightStatus = "Obese Class III";
            }

            // Output WHO weight status
            Console.WriteLine($"WHO Weight Status: {weightStatus}");
        }
    }
}