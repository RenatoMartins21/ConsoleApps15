using System;

namespace ConsoleAppProject.App04
{
    /// <author>
    /// Renato Martins
    /// version 1
    /// </author>
    
    // This class posts to be stored in a Social Network
    public class MessagePost : Post
    {
        public String Message { get; }
        public MessagePost(String author, String text) : base(author)
        {
            this.Message = text;
        }
        public override void Display()
        {
            Console.WriteLine("    ---------------------------------");
            Console.WriteLine($"    Post: {Message}                  ");

            base.Display();
        }
    }
}
