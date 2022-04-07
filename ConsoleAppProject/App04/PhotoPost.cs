using System;
namespace ConsoleAppProject.App04
{
    /// <author>
    /// Renato Martins
    /// version 1
    /// </author>
    
    // Stores info about Photo Posts 
    public class PhotoPost : Post
    {
        // File name of the image
        public String Filename { get; set; }

        // Image description
        public String Caption { get; set; }

        // All info for Photo Post
        public PhotoPost(String author, String filename, String caption) : base(author)
        {
            this.Filename = filename;
            this.Caption = caption;
        }

        public override void Display()
        {
            Console.WriteLine("    --------------------------------");
            Console.WriteLine($"    File: {Filename}                ");
            Console.WriteLine($"    Description: {Caption}          ");

            base.Display();
        }
    }
}