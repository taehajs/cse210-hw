using System;
using System.Collections.Generic;

namespace YouTubeVideos
{
     public class Comment
    {
        public string Name { get; set; }
        public string Text { get; set; }

        public Comment(string name, string text)
        {
            Name = name;
            Text = text;
        }
    }

    public class Video
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int LengthInSeconds { get; set; }
        private List<Comment> Comments { get; set; }

        public Video(string title, string author, int lengthInSeconds)
        {
            Title = title;
            Author = author;
            LengthInSeconds = lengthInSeconds;
            Comments = new List<Comment>();
        }
      
        public void AddComment(Comment comment)
        {
            Comments.Add(comment);
        }

        
        public int GetCommentCount()
        {
            return Comments.Count;
        }

     
        public void DisplayVideoInfo()
        {
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Author: {Author}");
            Console.WriteLine($"Length: {LengthInSeconds} seconds");
            Console.WriteLine($"Number of Comments: {GetCommentCount()}");

            foreach (Comment comment in Comments)
            {
                Console.WriteLine($" - {comment.Name}: {comment.Text}");
            }
            Console.WriteLine();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            
            List<Video> videos = new List<Video>();
            
            Video video1 = new Video("Learning C#", "CodeMaster", 600);
            video1.AddComment(new Comment("Alice", "Great explanation!"));
            video1.AddComment(new Comment("Bob", "Really helpful, thanks!"));
            video1.AddComment(new Comment("Charlie", "Could you cover Python next?"));
            videos.Add(video1);

            
            Video video2 = new Video("Cooking Pasta", "Chef John", 450);
            video2.AddComment(new Comment("Daisy", "Great and simple recipe!"));
            video2.AddComment(new Comment("Ethan", "Tried it today, delicious."));
            video2.AddComment(new Comment("Fiona", "Can you make this for vegan version?"));
            videos.Add(video2);

            
            Video video3 = new Video("Travel Vlog: LA", "Big City", 900);
            video3.AddComment(new Comment("George", "USA and LA is on my bucket list!"));
            video3.AddComment(new Comment("Hannah", "Beautiful shots, love it."));
            video3.AddComment(new Comment("Ian", "What camera are you using?"));
            videos.Add(video3);

           
            foreach (Video v in videos)
            {
                v.DisplayVideoInfo();
            }
        }
    }
}
