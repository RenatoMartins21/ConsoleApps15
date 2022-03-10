using ConsoleAppProject.App01;
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

            DistanceConverter converter = new DistanceConverter();
            converter.ConvertDistance();
        }
    }
}
