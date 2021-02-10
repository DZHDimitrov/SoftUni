using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Articles2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Article> articles = new List<Article>();

            int number = int.Parse(Console.ReadLine());

            for (int i = 0; i < number; i++)
            {
                string[] data = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
                Article article = new Article(data[0], data[1], data[2]);
                articles.Add(article);

            }
            string criteria = Console.ReadLine();
            switch (criteria)
            {
                case "title":
                    foreach (var item in articles.OrderBy(x => x.Title))
                    {
                        Console.WriteLine(item);
                    }
                    break;
                case "content":
                    foreach (var item in articles.OrderBy(x => x.Content))
                    {
                        Console.WriteLine(item);
                    }
                    break;
                case "author":
                    foreach (var item in articles.OrderBy(x => x.Author))
                    {
                        Console.WriteLine(item);
                    }
                    break;
            }

        }
    }
    class Article
    {
        public Article(string title, string content, string author)
        {
            Title = title;
            Content = content;
            Author = author;
        }

        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }


        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }

    }
}
