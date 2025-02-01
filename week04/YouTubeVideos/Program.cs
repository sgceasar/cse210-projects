using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the YouTubeVideos Project.");
    }using System;
using System.Collections.Generic;

public class Comment
{
    public string CommenterName { get; set; }
    public string CommentText { get; set; }

    public Comment(string commenterName, string commentText)
    {
        CommenterName = commenterName;
        CommentText = commentText;
    }
}

public class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Length { get; set; }
    public List<Comment> Comments { get; set; }

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
        Comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        Comments.Add(comment);
    }

    public int GetNumberOfComments()
    {
        return Comments.Count;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        // Criando vídeos
        Video video1 = new Video("Learn C# in 10 minutes", "TechGuru", 600);
        Video video2 = new Video("The Power of Abstraction", "CodeMaster", 900);
        Video video3 = new Video("Building Yout First API", "DevNinja", 1200);
        Video video4 = new Video("10 Tips For Devs", "ProGamer", 1300);

        // Adicionando comentários aos vídeos
        video1.AddComment(new Comment("User1", "You rocked!"));
        video1.AddComment(new Comment("User2", "Thats absolute useful!"));
        video1.AddComment(new Comment("User3", "I need to practice more."));
        video2.AddComment(new Comment("User4", "Thanks for your explanation."));
        video2.AddComment(new Comment("User5", "Abstraction is fundamental."));
        video2.AddComment(new Comment("User6", "I liked the approach."));
        video3.AddComment(new Comment("User7", "API is a challenge."));
        video3.AddComment(new Comment("User8", "Very well explained."));
        video3.AddComment(new Comment("User9", "I need to study more APIs."));
        video4.AddComment(new Comment("User10", "Very important tips."));
        video4.AddComment(new Comment("User11", "I loved it as tips."));
        video4.AddComment(new Comment("User12", "You practice all of this."));

        // Store the videos in a list
        List<Video> videos = new List<Video> { video1, video2, video3, video4 };

        // Iterating over the list of videos and displaying information
        foreach (var video in videos)
        {
            Console.WriteLine("Title: " + video.Title);
            Console.WriteLine("Author: " + video.Author);
            Console.WriteLine("Duration: " + video.Length + " seconds");
            Console.WriteLine("Number of Coments: " + video.GetNumberOfComments());
            Console.WriteLine("Coments:");
            foreach (var comment in video.Comments)
            {
                Console.WriteLine("  - " + comment.CommenterName + ": " + comment.CommentText);
            }
            Console.WriteLine("------------------------------");
        }
    }
}
}
