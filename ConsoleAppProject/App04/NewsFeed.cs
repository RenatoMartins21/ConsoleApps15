using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleAppProject.App04
{
    /// <author>
    /// Renato Martins
    /// version 1
    /// </author>

    // This class stores posts on the social network
    public class NewsFeed
    {
        public const string AUTHOR = "CyberUK";
        public List<Post> Posts { get; }
        public int itemNumber;

        // Create the news feed:
        public NewsFeed()
        {
            // Create a list called Posts:
            Posts = new List<Post>();
            // Create a MessagePost:
            MessagePost post = new MessagePost(AUTHOR, "Say everything is great, with the fakest smile hanging' out of my face. I'm done.");
            AddPost(post);
            // Create a PhotoPost
            PhotoPost photopost = new PhotoPost(AUTHOR, "AnimeWaifu.png", "Best Waifu");
            AddPost(photopost);
        }

        // Calls the Posts from above to be added:
        public void AddPost(Post post)
        {
            Posts.Add(post);
        }

        // Display the current News Feed with the posts:
        public void Display()
        {
            // show all posts
            foreach (var (item, index) in Posts.Select((value, i) => (value, i)))
            {
                itemNumber = index + 1;
                Console.WriteLine("    =========================");
                Console.WriteLine($"    Post number {itemNumber}");
                item.Display();
                Console.WriteLine();
            }
        }
    }
}