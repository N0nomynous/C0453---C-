using ConsoleAppProject.Helpers;
using System;
using System.Collections.Generic;


namespace ConsoleAppProject.App04
{
    ///<summary>
    /// The NewsFeed class stores news posts for the news feed in a social network 
    /// application.
    ///</summary>
    ///<author>
    ///  Noman Syed
    ///  version 0.1
    ///</author> 
    public class NewsFeed
    {
        // A constant string to store the default author's name.
        public const string AUTHOR = "Noman Syed";

        // A private list to store all posts in the news feed.
        private readonly List<Post> posts;

        // Constructor initializes the news feed with predefined posts.
        public NewsFeed()
        {
            posts = new List<Post>();

            // Creates a new message post and adds it to the list.
            MessagePost post = new MessagePost(AUTHOR, "Samsung and Apple go hand in hand");
            AddMessagePost(post);
            post.AddComment("I agree!");

            // Creates a new photo post and adds it to the list.
            PhotoPost photoPost = new PhotoPost(AUTHOR, "Samsung&Apple.png", "Samsung and Apple");
            AddPhotoPost(photoPost);
        }

        // A property to get or set a Post object.
        public Post Post
        {
            get => default;
            set { }
        }

        //This adds a message post to the news feed.
        public void AddMessagePost(MessagePost message)
        {
            posts.Add(message);
        }

        //This adds a photo post to the news feed.
        public void AddPhotoPost(PhotoPost photo)
        {
            posts.Add(photo);
        }

        //This displays all posts by a specific author.
        public void DisplayAuthorPost(string author)
        {
            foreach (Post post in posts)
            {
                if (post.Username == author)
                {
                    post.Display();
                }
            }
        }

        // This finds posts by a specific date and displays them.
        public void FindDate(string date)
        {
            foreach (Post post in posts)
            {
                if (post.Timestamp.ToLongDateString().Contains(date))
                {
                    post.Display();
                }
            }
        }

        // This adds a comment to a post by post ID.
        public void AddPostComment(int id, string text)
        {
            Post post = FindPost(id);

            if (post == null)
            {
                Console.WriteLine($"\nPost with ID: {id} does not exist!\n");
            }
            else
            {
                Console.WriteLine($"\nThe comment has been added to the post {id}!\n");
                post.AddComment(text);
                post.Display();
            }
        }

        // This likes a post by ID.
        public void LikePost(int id)
        {
            Post post = FindPost(id);

            if (post == null)
            {
                Console.WriteLine($"\nThe Post with the ID: {id} does not exist!\n");
            }
            else
            {
                Console.WriteLine($"\nYou have liked the post {id}!\n");
                post.Like();
                post.Display();
            }
        }

        // Unlikes a post by ID.
        public void UnlikePost(int id)
        {
            Post post = FindPost(id);

            if (post == null)
            {
                Console.WriteLine($"\nThe Post with the ID: {id} does not exist!\n");
            }
            else
            {
                Console.WriteLine($"\nYou have unliked the post. {id}!\n");
                post.Unlike();
                post.Display();
            }
        }

        //This removes a post from the news feed by ID.
        public void RemovePost(int id)
        {
            Post post = FindPost(id);

            if (post == null)
            {
                Console.WriteLine($" \nThe Post with the ID: {id} does not exist!\n");
            }
            else
            {
                Console.WriteLine($" \nThe following Post {id} has been removed!\n");
                posts.Remove(post);
                post.Display();
            }
        }

        //This finds a post in the list by ID.
        public Post FindPost(int id)
        {
            foreach (Post post in posts)
            {
                if (post.PostId == id)
                {
                    return post;
                }
            }

            return null;
        }

        //This displays all posts in the news feed.
        public void Display()
        {
            ConsoleHelper.OutputTitle("Display All Posts");

            foreach (Post post in posts)
            {
                post.Display();
                Console.WriteLine();
            }
        }
    }
}