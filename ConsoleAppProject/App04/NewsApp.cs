using System;
using System.Collections.Generic;
using ConsoleAppProject.Helpers;

namespace ConsoleAppProject.App04
{
    public class NewsApp
    {

        /// <summary>
        /// The NewsApp class will run the app and give the
        /// user a list of choices and holds the functionality
        /// to create a social network app.
        /// </summary>

        public NewsList NewsList { get; set; } = new NewsList();

        string[] choices =
        {
            "Add a Message Post",
            "Add a Photo Post",
            "Display All Posts",
            "Display User's Post",
            "Comment",
            "Like",
            "Unlike",
            "Remove Post",
            "Quit"
        };

        private string user;
        private string message;
        private string filename;
        private string caption;
        private bool quit;

        /// <summary>
        /// This method will run the program, outputs a heading
        /// and gives a list of choices to execute and also
        /// gives the user the option to quit.
        /// </summary>
        public void Run()
        {
            quit = false;
            do
            {
                ConsoleHelper.OutputHeading(" Maarten's NewsFeed");
                int choice = ConsoleHelper.SelectChoice(choices);
                switch (choice)
                {
                    case 1: AddMessage(); break;
                    case 2: AddPhoto(); break;
                    case 3: DisplayAllPosts(); break;
                    case 4: DisplayUsersPost(); break;
                    case 5: AddComment(); break;
                    case 6: LikePost(); break;
                    case 7: UnlikePost(); break;
                    case 8: RemovePost(); break;
                    case 9: quit = true; break;
                }
            } while (!quit);
        }

        /// <summary>
        /// Allows the user to post a message by entering their name
        /// and then entering a message.
        /// </summary>
        private void AddMessage()
        {
            ConsoleHelper.OutputTitle(" Adding a new message post");
            Console.Write(" Please enter your name > ");
            user = Console.ReadLine();

            Console.Write(" Please enter your message > ");
            message = Console.ReadLine();

            MessagePost post = new MessagePost(user, message);
            NewsList.AddPost(post);
            ConsoleHelper.OutputTitle(" Your message has been posted!");
        }

        /// <summary>
        /// Allows the user to post an image by entering their name
        /// and then the filename and caption.
        /// </summary>
        private void AddPhoto()
        {
            Console.Write(" Please enter your name > ");
            user = Console.ReadLine();

            Console.Write(" Please enter the photo filename > ");
            filename = Console.ReadLine();

            Console.Write(" Please enter a caption > ");
            caption = Console.ReadLine();

            PhotoPost post = new PhotoPost(user, filename, caption);
            NewsList.AddPost(post);
            ConsoleHelper.OutputTitle(" Your photo has been posted!");

        }

        /// <summary>
        /// This will display all the posts entered by every user.
        /// </summary>
        private void DisplayAllPosts()
        {
            ConsoleHelper.OutputTitle(" Displaying all user's posts:");
            NewsList.Display();
        }

        /// <summary>
        /// This will display a specific post by entering a username. 
        /// </summary>
        private void DisplayUsersPost()
        {
            Console.Write(" Please Enter a Username > ");
            user = Console.ReadLine();

            ConsoleHelper.OutputTitle($"Displayng {user}'s Post");
            NewsList.DisplayUsersPost(user);
        }

        /// <summary>
        /// Allows the user to add comments on existing posts by entering the ID.
        /// </summary>
        private void AddComment()
        {
            int id = (int)ConsoleHelper.InputNumber(" Please enter " + "the ID of the post you wish to comment on > ");
            Post post = NewsList.FindPost(id);

            if (post != null)
            {
                Console.Write(" Please enter your comment > ");
                string comment = Console.ReadLine();
                post.AddComment(comment);
            }
            else
            {
                Console.WriteLine(" This Post does not exist...");
            }

            ConsoleHelper.OutputTitle(" Comment Added Successfully!");
        }

        /// <summary>
        /// Allows the user to 'like' a post based on its ID.
        /// </summary>
        private void LikePost()
        {
            int id = (int)ConsoleHelper.InputNumber(" Please enter " + "the ID of the post you wish to Like > ");
            Post post = NewsList.FindPost(id);

            if (post != null)
            {
                post.Like();
            }
            else
            {
                Console.WriteLine(" This post does not exist...");
            }

            ConsoleHelper.OutputTitle(" Liked!");
        }

        /// <summary>
        /// Allows the user to 'unlike' a post based on ID.
        /// </summary>
        private void UnlikePost()
        {
            int id = (int)ConsoleHelper.InputNumber(" Please enter " + "the ID of the post you wish to Unlike > ");
            Post post = NewsList.FindPost(id);

            post.Unlike();

            ConsoleHelper.OutputTitle(" Unliked");
        }

        /// <summary>
        /// Allows the user to remove a comment based on ID.
        /// </summary>
        private void RemovePost()
        {
            int id = (int)ConsoleHelper.InputNumber(" Please enter " + "the ID of the post you wish to remove > ");
            Post post = NewsList.FindPost(id);

            if (post != null)
            {
                Console.WriteLine($" Removing post number {post.PostID}");
                NewsList.RemoveComment(id);
            }
            else
            {
                Console.WriteLine(" This post does not exist...");
            }

            ConsoleHelper.OutputTitle(" Comment removed");
        }
    }
}
