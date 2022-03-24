using ConsoleAppProject.App01;
using ConsoleAppProject.App02;
using ConsoleAppProject.App03;
using ConsoleAppProject.Helpers;
using System;

namespace ConsoleAppProject
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine();
            Console.WriteLine(" =================================================");
            Console.WriteLine("    BNU CO453 Applications Programming 2021-2022! ");
            Console.WriteLine("        by Renato                                 ");
            Console.WriteLine(" =================================================");
            Console.WriteLine();

            SelectApp();
        }

        private static void SelectApp()
        {
            Console.WriteLine("1) App01 Distance Converter");
            Console.WriteLine("2) App02 BMI");
            Console.WriteLine("3) App03 Students Grades");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                DistanceConverter converter = new DistanceConverter();
                converter.ConvertDistance();
            }
            else if (choice == "2")
            {
                BMI bmi = new BMI();
                bmi.Run();
            }
            else if (choice == "3")
            {
                StudentGrades app = new StudentGrades();
                app.Run();
            }
            else
            {
                Console.WriteLine(" 1 or 2");
            }
        }
    }
}
