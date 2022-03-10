using System;

namespace ConsoleAppProject.App01
{
    /// <summary>
    /// Converting units from a user input
    /// </summary>
    /// <author>
    /// Renato Martins version 0.1
    /// </author>
    public class DistanceConverter
    {
        //
        // Units!
        //
        public const double METRES_IN_MILES = 0.000621;
        public const double FEET_IN_METRES = 3.28084;
        public const int FEET_IN_MILES = 5280;

        private double fromDistance;
        private double toDistance;
        private string fromUnit;
        private string toUnit;

        //
        // Names!
        //
        public const string FEET = "Feet";
        public const string METRES = "Metres";
        public const string MILES = "Miles";

        public DistanceConverter()
        {
            fromUnit = MILES;
            toUnit = FEET;
        }

        public void ConvertDistance()
        {
            fromUnit = SelectUnit("Original Unit: ");

            toUnit = SelectUnit("Unit to be calculated: ");

            OutputHeading($"Converting {fromUnit} to {toUnit}");

            fromDistance = InputDistance($"Number of {fromUnit}: ");

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
                toDistance = fromDistance / METRES_IN_MILES;
            }
            else if (fromUnit == METRES && toUnit == MILES)
            {
                toDistance = fromDistance * METRES_IN_MILES;
            }
            else if (fromUnit == FEET && toUnit == METRES)
            {
                toDistance = fromDistance * FEET_IN_METRES;
            }
            else if (fromUnit == METRES && toUnit == FEET)
            {
                toDistance = fromDistance / METRES_IN_MILES;
            }
        }

        //
        // Show Choices on screen
        //
        private string SelectUnit(string prompt)
        {
            string choice = DisplayChoices(prompt);
            return ExecuteChoice(choice);
        }

        private static string ExecuteChoice(string choice)
        {

            if (choice.Equals("1"))
            {
                return METRES;
            }
            else if (choice.Equals("2"))
            {
                return MILES;
            }
            else if (choice.Equals("3"))
            {
                return FEET;
            }

            return null;
        }

        //
        //Console output display
        //
        private static string DisplayChoices(string prompt)
        {
            Console.WriteLine();
            Console.WriteLine($" 1. {METRES}");
            Console.WriteLine($" 2. {MILES}");
            Console.WriteLine($" 3. {FEET}");
            Console.WriteLine();

            Console.Write(prompt);
            string choice = Console.ReadLine();
            return choice;
        }


        private double InputDistance(string prompt)
        {
            Console.Write(prompt);
            string value = Console.ReadLine();
            return Convert.ToDouble(value);
        }

        //
        // Final Output with maths done
        //
        private void OutputDistance()
        {
            Console.WriteLine($" {fromDistance} {fromUnit}" +
            $" is {toDistance} {toUnit}");
        }

        private void OutputHeading(String prompt)
        {
            Console.WriteLine("\n============================");
            Console.WriteLine("      Distance Converter      ");
            Console.WriteLine("        Renato Martins        ");
            Console.WriteLine("============================\n");

            Console.WriteLine(prompt);
            Console.WriteLine("");
        }





    }
}
