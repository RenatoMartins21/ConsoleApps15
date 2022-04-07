using System;
using System.Collections.Generic;

namespace ConsoleAppProject.App04
{
    /// <author>
    /// Renato Martins
    /// version 1
    /// </author>
    
    // The base class for PhotoPost/MessagePost.
    public class Post
    {
        public List<String> comments;
        public int likes;
        
        public String Username { get; set; }
        public DateTime Timestamp { get; set; }
        public Post(String author)
        {
            this.Username = author;
            Timestamp = DateTime.Now;

            likes = 0;
            comments = new List<String>();
        }

        public void Like()
        {
            likes++;
        }
        public void Unlike()
        {
            if (likes > 0)
            {
                likes--;
            }
        }
        public void AddComment(String text)
        {
            comments.Add(text);
        }


        public String FormatElapsedTime(DateTime time)
        {
            DateTime current = DateTime.Now;
            TimeSpan timePast = current - time;

            long seconds = (long)timePast.TotalSeconds;
            long minutes = seconds / 60;

            if (minutes > 0)
            {
                return minutes + " minutes ago";
            }
            else
            {
                return seconds + " seconds ago";
            }
        }

        public virtual void Display()
        {
            Console.WriteLine();
            Console.WriteLine($"    Author: {Username}");
            Console.WriteLine($"    Time Elapsed: {FormatElapsedTime(Timestamp)}");
            Console.WriteLine();

            if (likes > 0)
            {
                Console.WriteLine($"    Likes:  {likes}  people like this.");
            }
            else
            {
                Console.WriteLine("    Likes:  0 people like this.");
            }

            if (comments.Count == 0)
            {
                Console.WriteLine("    0 comments.");
            }
            else
            {
                Console.WriteLine($"    Comment(s): {comments.Count}  Click here to view.");
            }
        }
    }
}