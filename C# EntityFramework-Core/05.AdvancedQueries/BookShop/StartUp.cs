namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using System;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            DbInitializer.ResetDatabase(db);
            var result = GetGoldenBooks(db);
            Console.WriteLine(result);
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            AgeRestriction ageRestriction = Enum.Parse<AgeRestriction>(command, true);
            var sb = new StringBuilder();
            var books = context
                .Books
                .Where(x => x.AgeRestriction == ageRestriction)
                .Select(x => x.Title)
                .OrderBy(x => x)
                .ToList();


            return string.Join(Environment.NewLine, books);
        }
        public static string GetGoldenBooks(BookShopContext context)
        {
            var sb = new StringBuilder();
            var books = context
                .Books
                .Where(b => b.EditionType == EditionType.Gold && b.Copies < 5000)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToList();

            return string.Join(Environment.NewLine, books);
        }
        
         public static string GetBooksByPrice(BookShopContext context)
        {
            var sb = new StringBuilder();
            var books = context
                .Books
                .Where(b => b.Price > 40)
                .Select(b => new
                {
                    Title = b.Title,
                    Price = b.Price
                })
                .OrderByDescending(b => b.Price)
                .ToList();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - ${book.Price:f2}");
            }
            return sb.ToString().TrimEnd();
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var books = context
                .Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToList();

            return string.Join(Environment.NewLine, books);
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var categories = input.Split().Select(x => x.ToLower()).ToArray();
            var books = context
                .Books
                .Where(b => b.BookCategories.Any(bc => categories.Contains(bc.Category.Name.ToLower())))
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToList();

            return string.Join(Environment.NewLine, books);
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var sb = new StringBuilder();
            var currentDate = DateTime.ParseExact(date, "dd-MM-yyyy", null);

            var books = context
                .Books
                .Where(b => b.ReleaseDate < currentDate)
                .Select(b => new
                {
                    Title = b.Title,
                    EditionType = b.EditionType,
                    Price = b.Price,
                    ReleaseDate = b.ReleaseDate
                })
                .OrderByDescending(b => b.ReleaseDate)
                .ToList();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var sb = new StringBuilder();

            var authors = context
                .Authors
                .ToList()
                .Where(a => a.FirstName.EndsWith(input.ToLower()))
                .Select(a => new
                {
                    FullName = string.Join(" ", new string[] { a.FirstName, a.LastName })
                })
                .OrderBy(a => a.FullName)
                .ToList();

            foreach (var author in authors)
            {
                sb.AppendLine(author.FullName);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var books = context
                .Books
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToList();

            return string.Join(Environment.NewLine, books);
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var sb = new StringBuilder();
            var books = context
                .Books.Where(x => x.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .Select(b => new
                {
                    BookId = b.BookId,
                    BookTitle = b.Title,
                    AuthrFullName = string.Join(" ", new string[] { b.Author.FirstName, b.Author.LastName })

                })
                .OrderBy(b => b.BookId)
                .ToList();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.BookTitle} ({book.AuthrFullName})");
            }

            return sb.ToString().TrimEnd();
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            return context.Books.Where(b => b.Title.Length > lengthCheck).Count();
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var sb = new StringBuilder();

            var authors = context
                .Authors
                .Select(x => new
                {
                    AuthorFullName = string.Join(" ", new string[] { x.FirstName, x.LastName }),
                    Copies = x.Books.Sum(b => b.Copies)
                })
                .OrderByDescending(b => b.Copies)
                .ToList();

            foreach (var book in authors)
            {
                sb.AppendLine($"{book.AuthorFullName} - {book.Copies}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var sb = new StringBuilder();

            var bookCategories = context
                .BooksCategories
                .Select(bc => new
                {
                    BookCategoryId = bc.CategoryId,
                    BookCategory = bc.Category.Name,
                    PriceForAllCopies = bc.Book.Price * bc.Book.Copies
                })
                .GroupBy(x => new
                {
                    x.BookCategoryId,
                    x.BookCategory
                })
                .Select(b => new
                {
                    BookCategory = b.Key.BookCategory,
                    SumPerCategory = b.Sum(p => p.PriceForAllCopies)
                })
                .OrderByDescending(b => b.SumPerCategory)
                .ThenBy(b => b.BookCategory)
                .ToList();

            foreach (var bookCategory in bookCategories)
            {
                sb.AppendLine($"{bookCategory.BookCategory} ${bookCategory.SumPerCategory:f2}");
            }

            return sb.ToString().TrimEnd();
        }
        public static string GetMostRecentBooks(BookShopContext context)
        {
            var sb = new StringBuilder();

            var bookCategories = context
                .Categories
                .Select(b => new
                {
                    Category = b.Name,
                    CategoryBooks = b.CategoryBooks
                    .Select(cb => new
                    {
                        Title = cb.Book.Title,
                        RelaseDate = cb.Book.ReleaseDate
                    })
                    .OrderByDescending(cb => cb.RelaseDate)
                    .Take(3)
                    .ToList()
                })
                .OrderBy(c=>c.Category)
                .ToList();

            foreach (var category in bookCategories)
            {
                sb.AppendLine($"--{category.Category}");
                foreach (var book in category.CategoryBooks)
                {
                    sb.AppendLine($"{book.Title} ({book.RelaseDate.Value.Year})");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static void IncreasePrices(BookShopContext context)
        {
            var books = context.Books.Where(b => b.ReleaseDate.Value.Year < 2010).ToList();
            foreach (var book in books)
            {
                book.Price += 5;
            }

            context.SaveChanges();
        }

        public static int RemoveBooks(BookShopContext context)
        {
            var books = context.Books.Where(b => b.Copies < 4200).ToList();
            foreach (var book in books)
            {
                context.Books.Remove(book);
            }
            context.SaveChanges();
            return books.Count();
        }
    }
}
