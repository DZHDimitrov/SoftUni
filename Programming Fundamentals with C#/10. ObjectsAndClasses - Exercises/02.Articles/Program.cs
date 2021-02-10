using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Articles
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] article = Console.ReadLine().Split(", ",StringSplitOptions.RemoveEmptyEntries);
            Article currentArticle = new Article(article[0], article[1], article[2]);
            int commands = int.Parse(Console.ReadLine());

            for (int i = 0; i < commands; i++)
            {
                string[] data = Console.ReadLine().Split(new char[] { ' ', ':'},StringSplitOptions.RemoveEmptyEntries);
                List<string> modify = data.Skip(1).ToList();
                string text = string.Join(" ", modify);
                switch (data[0])
                {
                    case "Edit":
                        currentArticle.ChangeContent(text);
                        break;
                    case "ChangeAuthor":
                        currentArticle.ChangeAuthor(text);
                        break;
                    case "Rename":
                        currentArticle.Rename(text);
                        break;
                }
            }
            Console.Write(currentArticle);
        }
    }
    class Article
    {
        public Article(string title,string content,string author)
        {
            Title = title;
            Content = content;
            Author = author;
        }

        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public void ChangeContent(string content)
        {
            Content = content;
        }

        public void ChangeAuthor(string author)
        {
            Author = author;
        }

        public void Rename(string title)
        {
            Title = title;
        }

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }

    }
}
