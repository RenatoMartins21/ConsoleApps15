using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ConsoleAppProject.Helpers;

namespace ConsoleAppProject.App03
{
    /// <summary>
    /// This class has methods that allow the user to input
    /// marks for a list/array of students. Marks can be
    /// displayed, converted to grades and also can convert
    /// to show the precentages of students for each grade.
    /// </summary>
    /// <author>
    /// Renato Martins version 0.1
    /// </author>
    public class StudentGrades
    {
        public const int NUMBEROFSTUDENTS = 10;

        public string[] Students { get; set; }
        public int[] Marks { get; set; }
        public Grades[] Grades { get; set; }
        public int[] Gradeprofile { get; set; }


        public int Total { get; set; }
        public double Mean { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }

        //
        // This displays the array of choices on the console.
        //
        public void Run()
        {
            Console.Clear();
            OutputHeading();
            string[] choices = { "Input marks", "Output marks", "Output stats", "Output grade profile", "Exit" };
            int choice = ConsoleHelper.SelectChoice(choices);
            ChooseOptions(choice);
        }

        //
        // This displays a little heading above the choices
        //
        public void OutputHeading()
        {
            Console.WriteLine("============================");
            Console.WriteLine("       Students Grades      ");
            Console.WriteLine("        Renato Martins      ");
            Console.WriteLine("============================");
        }

        //
        // When choices are selected it will find out which
        // option the user typed by using If statments
        //
        private void ChooseOptions(int choice)
        {
            if (choice == 1)
            {
                Console.Clear();
                InputMarks();
                Console.WriteLine("============================");
                Console.WriteLine("      Console will be       ");
                Console.WriteLine("   cleared in 10 seconds!   ");
                Console.WriteLine("============================");
                System.Threading.Thread.Sleep(10000);
                Run();
            }
            else if (choice == 2)
            {
                Console.Clear();
                OutputMarks();
                Console.WriteLine("============================");
                Console.WriteLine("      Console will be       ");
                Console.WriteLine("   cleared in 10 seconds!   ");
                Console.WriteLine("============================");
                System.Threading.Thread.Sleep(10000);
                Run();
            }
            else if (choice == 3)
            {
                Console.Clear();
                CalculateMean();
                CalculateMinMax();
                OutputStats();
                Console.WriteLine("============================");
                Console.WriteLine("      Console will be       ");
                Console.WriteLine("   cleared in 10 seconds!   ");
                Console.WriteLine("============================");
                System.Threading.Thread.Sleep(10000);
                Run();
            }
            else if (choice == 4)
            {
                Console.Clear();
                CalculateGradeProfile();
                OutputGradeProfile();
                Console.WriteLine("============================");
                Console.WriteLine("      Console will be       ");
                Console.WriteLine("   cleared in 10 seconds!   ");
                Console.WriteLine("============================");
                System.Threading.Thread.Sleep(10000);
                Run();
            }
            else
            {
                Environment.Exit(0);
            }
        }

        //
        // User Input marks for each of the students in the array
        // marks are enforced to be between 0 and 100
        //
        private void InputMarks()
        {
            for (int i = 0; i < NUMBEROFSTUDENTS; i++)
            {
                Marks[i] = (int)ConsoleHelper.InputNumber($"Please enter mark for {Students[i]} : ", 0, 100);
                //Make the convert mark grade thing
                Grades[i] = ConvertMarktoGrade(Marks[i]);
            }
        }

        //
        // Convert the marks to grades by using if statements
        // to seperate each mark to each grade
        //
        public Grades ConvertMarktoGrade(int mark)
        {
            if (mark < 40)
            {
                return App03.Grades.F;
            }

            else if (mark < 50)
            {
                return App03.Grades.D;
            }

            else if (mark < 60)
            {
                return App03.Grades.C;
            }

            else if (mark < 70)
            {
                return App03.Grades.B;
            }

            else
            {
                return App03.Grades.A;
            }
        }

        //
        // Array of students
        //
        public StudentGrades()
        {
            Students = new string[NUMBEROFSTUDENTS] { "Renato", "Jack", "Daniel", "Tony", "Emma", "Jonh", "Coby", "James", "Harison", "Megan" };
            Marks = new int[NUMBEROFSTUDENTS] { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };
            Grades = new Grades[NUMBEROFSTUDENTS] {App03.Grades.F, App03.Grades.F, App03.Grades.F,
                                                   App03.Grades.D, App03.Grades.C,App03.Grades.B,
                                                   App03.Grades.A, App03.Grades.A, App03.Grades.A, App03.Grades.A};
            Gradeprofile = new int[5];
        }

        //
        // Output marks along side the student name
        //
        private void OutputMarks()
        {
            for (int i = 0; i < NUMBEROFSTUDENTS; i++)
            {
                Console.WriteLine($"{Students[i]}'s Mark is {Marks[i]} | Grade = {Grades[i]}");
            }
        }

        //
        // Mean Calculator
        //
        public void CalculateMean()
        {
            foreach (int mark in Marks)
            {
                Total += mark;
            }

            Mean = Total / NUMBEROFSTUDENTS;
        }

        //
        // Min and Max Grades are calculated here
        //
        public void CalculateMinMax()
        {
            Min = Marks[0];
            Max = Marks[0];
            foreach (int mark in Marks)
            {
                if (mark < Min)
                {
                    Min = mark;
                }
                else if (mark > Max)
                {
                    Max = mark;
                }
            }
        }

        //
        // Console Output the Stats
        //
        private void OutputStats()
        {
            Console.WriteLine($"Mean mark is {Mean}");
            Console.WriteLine($"Minimum mark is {Min}");
            Console.WriteLine($"Maximum mark is {Max}");
        }

        private void OutputGradeProfile()
        {
            foreach (Grades val in Enum.GetValues(typeof(Grades)))
            {
                Console.WriteLine($"The percentage of students that got {val} is {Gradeprofile[(int)val]}%");
            }
        }

        //
        // Calculate how many students got each marks
        //
        public void CalculateGradeProfile()
        {
            foreach (Grades grade in Grades)
            {
                Gradeprofile[(int)grade] += 1;
            }

            for (int i = 0; i < Gradeprofile.Length; i++)
            {
                Gradeprofile[i] = Gradeprofile[i] * 100 / NUMBEROFSTUDENTS;
            }
        }


    }
}