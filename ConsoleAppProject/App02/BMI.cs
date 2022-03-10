using System;

namespace ConsoleAppProject.App02
{
    /// <summary>
    /// App that will calculate Body Mass Index
    /// </summary>
    /// <author>
    /// Renato Martins version 0.1
    /// </author>

    public class BMI
    {
        public int Bmi { get; set; }

        public string Choice { get; set; }

        public double Weight { get; set; }
        public double WeightStones { get; set; }
        public double WeightPounds { get; set; }

        public double Height { get; set; }
        public double HeightFeet { get; set; }
        public double HeightInches { get; set; }

        public void Run()
        {
            do
            {
                Choice = SelectUnits();
            }
            while (Choice == null);

            if (Choice == "Imperial")
            {
                InputImperial();
            }
            else
            {
                InputMetric();
            }

            if (Choice == "Imperial")
            {
                CalcBMIImperial();
            }
            else
            {
                CalcBMIMetric();
            }

            OutputBMI();
            WHO();
        }

        public void OutputHeading()
        {
            Console.WriteLine("============================");
            Console.WriteLine("        BMI Calculator      ");
            Console.WriteLine("        Renato Martins      ");
            Console.WriteLine("============================");
        }

        public string SelectUnits()
        {
            Console.WriteLine("===============================================");
            Console.WriteLine("Please Select one of the Measurements shown bellow");
            Console.WriteLine("No.| NAME  |    WEIGHT     |  HEIGHT      ");
            Console.WriteLine("1) IMPERIAL - STONES+POUNDS FEET/INCH");
            Console.WriteLine("2) METRIC   - KILOGRAM      METRES");
            Console.WriteLine("===============================================");
            Console.WriteLine("Please enter 1 or 2");
            Choice = Console.ReadLine();

            if (Choice == "1")
            {
                return "Imperial";
            }
            else if (Choice == "2")
            {
                return "Metric";
            }
            else
            {
                Console.WriteLine("Select 1 or 2 please.");
                Console.WriteLine("=====================");
                return null;
            }
        }

        public double InputMeasurement(string prompt, double measurement)
        {
            Console.WriteLine(prompt);
            string value = Console.ReadLine();

            if (Double.TryParse(value, out measurement))
            {
                measurement = Convert.ToDouble(value);
                if (measurement < 0)
                {
                    measurement = InputMeasurement("Invalid input!", measurement);

                }
                return measurement;
            }
            else
            {
                measurement = InputMeasurement("Invalid input!", measurement);

                return measurement;
            }
        }

        //
        // Imperial Units
        //
        private void InputImperial()
        {
            Console.WriteLine("===========================================");
            Console.WriteLine("= WEIGHT STONES/POUNDS + HEIGHT FEET/INCH =");
            Console.WriteLine("===========================================");

            WeightStones = InputMeasurement("ENTER WEIGHT IN STONES: ", WeightStones);
            WeightPounds = InputMeasurement("ENTER WEIGHT IN POUNDS: ", WeightPounds);
            Console.WriteLine("=================");

            HeightFeet = InputMeasurement("ENTER HEIGHT IN FEET: ", HeightFeet);
            HeightInches = InputMeasurement("ENTER HEIGHT IN INCH: ", HeightInches);

        }

        public void CalcBMIImperial()
        {
            if (Weight == 0)
            {
                Weight = (WeightStones * 14 + WeightPounds) * 703;
                Height = HeightFeet * 12 + HeightInches;
            }
            Bmi = (int)(Weight / (Height * Height));
        }

        //
        // Metric Units
        //
        private void InputMetric()
        {
            Console.WriteLine("===========================================");
            Console.WriteLine("= WEIGHT KILOGRAMS    +   HEIGHT METRES   =");
            Console.WriteLine("===========================================");

            Weight = InputMeasurement("ENTER WEIGHT IN KILOS: ", Weight);
            Height = InputMeasurement("ENTER HEIGHT IN METRES: ", Height);
            Console.WriteLine("==================");
        }

        public void CalcBMIMetric()
        {
            if (Weight == 0)
            {
                Weight = Weight;
                Height = Height;
            }
            Bmi = (int)(Weight / (Height * Height));
        }


        //
        // BMI Output
        //
        private void OutputBMI()
        {
            Console.WriteLine("=========================");
            Console.WriteLine($"Your BMI totals to {Bmi}");
            Console.WriteLine("=========================");

            if (Bmi < 18.5)
            {
                Console.WriteLine("Underweight!");
            }
            else if (Bmi < 24.9)
            {
                Console.WriteLine("Healthy!");
            }
            else if (Bmi < 29.9)
            {
                Console.WriteLine("Overweight!");
            }
            else if (Bmi < 34.9)
            {
                Console.WriteLine("Obese class 1!");
            }
            else if (Bmi < 39.9)
            {
                Console.WriteLine("Obese class 2!");
            }
            else
            {
                Console.WriteLine("Obese class 3!");
            }

        }

        private void WHO()
        {
            Console.WriteLine("===================================");
            Console.WriteLine("=       BMI charts released       =");
            Console.WriteLine("=by the World Health Organuisation=");
            Console.WriteLine("===================================");
            Console.WriteLine("=WHO Weight Status      BMI kg/m^2=");
            Console.WriteLine("=Underweight               < 18.50=");
            Console.WriteLine("=Normal	               18.5 - 24.9=");
            Console.WriteLine("=Overweight	       25.0 - 29.9=");
            Console.WriteLine("=Obese Class I         30.0 - 34.9=");
            Console.WriteLine("=Obese Class II	       35.0 - 39.9=");
            Console.WriteLine("=Obese Class III           >= 40.0=");
            Console.WriteLine("===================================");
        }
    }
}
