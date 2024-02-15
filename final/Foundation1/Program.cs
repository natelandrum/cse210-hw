using System;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video v1 = new Video();
        v1._title = "The Easiest Cake You'll Ever Bake";
        v1._author = "Jane The Baker";
        v1._length = 120;

        Comment c1 = new Comment();
        c1._text = "This is a great recipe!";
        c1._author = "Jim";
        v1._comments.Add(c1);

        Comment c2 = new Comment();
        c2._text = "I can't wait to try this!";
        c2._author = "John";
        v1._comments.Add(c2);

        Comment c3 = new Comment();
        c3._text = "I love this channel!";
        c3._author = "Jane";
        v1._comments.Add(c3);

        videos.Add(v1);


        Video v2 = new Video();
        v2._title = "Scruptious Apple Pie In 10 Minutes";
        v2._author = "Pies Galore";
        v2._length = 150;

        Comment c4 = new Comment();
        c4._text = "This looks delicious!";
        c4._author = "Sue";
        v2._comments.Add(c4);

        Comment c5 = new Comment();

        c5._text = "In 10 min?! It took me 2 hours!";
        c5._author = "Sally";
        v2._comments.Add(c5);

        Comment c6 = new Comment();
        c6._text = "I'm going to make this tomorrow!";
        c6._author = "Susan";

        v2._comments.Add(c6);

        videos.Add(v2);

        Video v3 = new Video();
        v3._title = "Prosciutto and Blue Cheese Pizza ";
        v3._author = "Italian At Heart";
        v3._length = 180;

        Comment c7 = new Comment();
        c7._text = "I feel like I'm in Italy!";
        c7._author = "Erica";

        v3._comments.Add(c7);

        Comment c8 = new Comment();
        c8._text = "This doesn't look that delicious.";
        c8._author = "Eduard";

        v3._comments.Add(c8);

        Comment c9 = new Comment();
        c9._text = "It doesn't look that hard to make. I'm going to try it!";
        c9._author = "Eva";

        v3._comments.Add(c9);

        videos.Add(v3);
       

        foreach (Video v in videos)
        {
            Console.WriteLine($"Title: {v._title}");
            Console.WriteLine($"Author: {v._author}");
            Console.WriteLine($"Length: {v._length}s");
            Console.WriteLine($"\nTotal Comments: {v.NumberOfComments()}");
            v.DisplayComments();
        }
    }
}