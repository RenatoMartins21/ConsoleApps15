using System;
using ConsoleAppProject.Helpers;

namespace ConsoleAppProject.App04
{
    public class SocialNetwork
    {
        private NewsFeed news = new NewsFeed();

        /// <summary>
        /// Displays the options for the user to select from. Repeatedly displays them after
        /// user makes an action until user wants to quit
        /// </summary>
        public void DisplayMenu()
        {
            bool exit = false;
            do
            {
                Console.WriteLine();
                Console.WriteLine(" ======================");
                Console.WriteLine("     Social Network    ");
                Console.WriteLine("        by Renato      ");
                Console.WriteLine(" ======================");
                Console.WriteLine();

                string[] choices = new string[] { "Add Message", "Add Photo", "Add Comment", "Show All Posts", "Show User Posts", "Delete Post", "Like Post", "Unlike Post", "EXIT" };
                int choice = ConsoleHelper.SelectChoice(choices);

                switch (choice)
                {
                    case 1: PostMessage(); break;
                    case 2: PostPhoto(); break;
                    case 3: AddComment(); break;
                    case 4: DisplayPosts(); break;
                    case 5: DisplayAuthorPosts(); break;
                    case 6: DeletePost(); break;
                    case 7: LikePost(); break;
                    case 8: UnlikePost(); break;
                    case 9: exit = true; break;
                }
            } while (!exit);
        }

        // Post Message
        public void PostMessage()
        {
            // Inputs
            Console.WriteLine(" ====================");
            Console.WriteLine(" Author of the post: ");
            string author = Console.ReadLine();
            Console.WriteLine(" ======================");
            Console.WriteLine(" Message to be posted: ");
            string message = Console.ReadLine();
            // Add inputs into system
            MessagePost messagePost = new MessagePost(author, message);
            news.AddPost(messagePost);
            Console.WriteLine(" ================");
            Console.WriteLine(" Text Post Added!");
            messagePost.Display();
        }

        // Post Image
        public void PostPhoto()
        {
            // Inputs
            Console.WriteLine(" ====================");
            Console.WriteLine(" Author of the post: ");
            string author = Console.ReadLine();
            Console.WriteLine(" ====================");
            Console.WriteLine(" Filename for image: ");
            string filename = Console.ReadLine();
            Console.WriteLine(" ==========================");
            Console.WriteLine(" Description of the Image: ");
            string caption = Console.ReadLine();
            // Add inputs into system
            PhotoPost photoPost = new PhotoPost(author, filename, caption);
            news.AddPost(photoPost);
            Console.WriteLine(" =================");
            Console.WriteLine(" Image Post Added!");
            photoPost.Display();
        }

        // Post Comment
        public void AddComment()
        {
            DisplayPosts();
            int number = (int)ConsoleHelper.
                InputNumber(" Post ID you would like to comment on: ", 1, news.Posts.Count);
            Console.WriteLine(" =====================");
            Console.WriteLine(" Comment to be added: ");
            string text = Console.ReadLine();
            news.Posts[number - 1].AddComment(text);
        }

        // Shows all posts
        public void DisplayPosts()
        {
            news.Display();
        }

        // Display posts from a User
        public void DisplayAuthorPosts()
        {
            Console.WriteLine(" ================");
            Console.WriteLine(" Enter Username: ");
            string author = Console.ReadLine();
            foreach (Post post in news.Posts)
            {
                if (post.Username == author)
                {
                    post.Display();
                }
            }
        }

        // Delete Post by ID
        public void DeletePost()
        {
            DisplayPosts();
            int number = (int)ConsoleHelper.
                InputNumber(" Post ID to be deleted: ", 1, news.Posts.Count);
            Console.WriteLine(" ====================");
            Console.WriteLine(" Post to be removed: ");
            news.Posts[number - 1].Display();
            news.Posts.RemoveAt(number - 1);
        }

        // Add Likes to a post by ID
        public void LikePost()
        {
            DisplayPosts();
            int number = (int)ConsoleHelper.
                InputNumber(" Post ID to Like: ", 1, news.Posts.Count);

            news.Posts[number - 1].Like();
            Console.WriteLine(" ====================");
            Console.WriteLine(" You like this post: ");
            news.Posts[number - 1].Display();
        }

        // Remove Likes from a post by ID
        public void UnlikePost()
        {
            DisplayPosts();
            int number = (int)ConsoleHelper.
                InputNumber(" Post ID to Unlike: ", 1, news.Posts.Count);

            news.Posts[number - 1].Unlike();
            Console.WriteLine(" =======================");
            Console.WriteLine(" You dislike this post: ");
            news.Posts[number - 1].Display();
        }

    }
}