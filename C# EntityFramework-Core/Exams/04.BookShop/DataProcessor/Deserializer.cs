namespace BookShop.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using BookShop.Data.Models;
    using BookShop.Data.Models.Enums;
    using BookShop.Dtos.Import;
    using Data;
    using Newtonsoft.Json;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedBook
            = "Successfully imported book {0} for {1:F2}.";

        private const string SuccessfullyImportedAuthor
            = "Successfully imported author - {0} with {1} books.";

        public static string ImportBooks(BookShopContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(ImportBookDtoXML[]), new XmlRootAttribute("Books"));

            var books = (ImportBookDtoXML[])serializer.Deserialize(new StringReader(xmlString));

            var dbBooks = new List<Book>();

            var sb = new StringBuilder();

            foreach (var book in books)
            {
                if (!IsValid(book))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (!Enum.IsDefined(typeof(Genre),book.Genre))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime publishedOn;

                bool isValidDate = DateTime.TryParseExact(book.PublishedOn, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out publishedOn);

                if (!isValidDate)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var dbBook = new Book
                {
                    Name = book.Name,
                    Price = book.Price,
                    Pages = book.Pages,
                    Genre = (Genre)book.Genre,
                    PublishedOn = publishedOn
                };
                dbBooks.Add(dbBook);
                sb.AppendLine(string.Format(SuccessfullyImportedBook, book.Name, book.Price));
            }
            context.Books.AddRange(dbBooks);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportAuthors(BookShopContext context, string jsonString)
        {
            var authors = (ImportAuthorsDtoJSON[])JsonConvert.DeserializeObject<ImportAuthorsDtoJSON[]>(jsonString);

            var dbAuthors = new List<Author>();

            var sb = new StringBuilder();
            foreach (var author in authors)
            {
                if (!IsValid(author) || context.Authors.Any(a => a.Email == author.Email))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var dbAuthor = new Author
                {
                    FirstName = author.FirstName,
                    LastName = author.LastName,
                    Phone = author.Phone,
                    Email = author.Email,
                };

                foreach (var book in author.Books)
                {
                    var dbBook = context.Books.FirstOrDefault(x => x.Id == book.Id);
                    if (dbBook != null)
                    {
                        dbAuthor.AuthorsBooks.Add(new AuthorBook { BookId = dbBook.Id });
                    }
                }

                if (dbAuthor.AuthorsBooks.Count == 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                dbAuthors.Add(dbAuthor);
                sb.AppendLine(string.Format(SuccessfullyImportedAuthor, $"{author.FirstName} {author.LastName}", dbAuthor.AuthorsBooks.Count));
            }

            context.Authors.AddRange(dbAuthors);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}