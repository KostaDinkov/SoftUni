using System;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using BookShopSystem.Data;
using Models;

namespace BookShopSystem.ConsoleClient
{
    class BookShopMain
    {
        static void Main(string[] args)
        {
            var db = new BookShopContext();
            //db.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction, "ALTER DATABASE [" + db.Database.Connection.Database + "] SET SINGLE_USER WITH ROLLBACK IMMEDIATE");
            db.Database.Log = msg => Debug.WriteLine(msg);
            TestRelatedBooks(db);
        }

        private static void GetBooksAfter(BookShopContext context)
        {
            var query = context.Books.Where(b => b.ReleaseDate.Value.Year > 2000).Select(b => b.Title);

            foreach (string title in query)
            {
                Console.WriteLine(title);
            }
        }

        private static void GetAuthorsWithBookBeforeDate(BookShopContext context)
        {
            var query = context.Authors.Where(a => a.Books.Any(b => b.ReleaseDate.Value.Year < 1990));

            foreach (Author author in query)
            {
                Console.WriteLine(author.FirstName + " " + author.LastName);
            }
        }

        private static void GetAuthorsByBookCount(BookShopContext context)
        {
            var query =
                context.Authors
                       .Select(a => new {a.FirstName, a.LastName, BookCount = a.Books.Count})
                       .OrderByDescending(a => a.BookCount);

            foreach (var author in query)
            {
                Console.WriteLine($"{author.FirstName} {author.LastName} {author.BookCount}");
            }
        }

        private static void GetAllBooksByAuthor(BookShopContext context, string authorFirstName, string authorLastName)
        {
            var query = context.Books
                               .Where(
                                   b => (b.Author.FirstName == authorFirstName) && (b.Author.LastName == authorLastName))
                               .OrderByDescending(b => b.ReleaseDate)
                               .ThenBy(b => b.Title);

            foreach (var book in query)
            {
                Console.WriteLine($"{book.Title} {book.ReleaseDate} {book.Copies}");
            }
        }

        private static void GetMostRecentBookByCategory(BookShopContext context)
        {
            var query = context.Categories.OrderByDescending(c => c.Books.Count);

            foreach (var category in query)
            {
                Console.WriteLine($"--{category.Name}: {category.Books.Count} books");

                var booksByCategory =
                    category.Books.OrderByDescending(b => b.ReleaseDate.Value.Year).ThenBy(b => b.Title).Take(3);

                foreach (Book book in booksByCategory)
                {
                    Console.WriteLine($"{book.Title} ({book.ReleaseDate.Value.Year})");
                }
            }
        }

        private static void TestRelatedBooks(BookShopContext context)
        {
            //var books = context.Books
            //                   .Take(3)
            //                   .ToList();
            //books[0].RelatedBooks.Add(books[1]);
            //books[1].RelatedBooks.Add(books[0]);
            //books[0].RelatedBooks.Add(books[2]);
            //books[2].RelatedBooks.Add(books[0]);

            //context.SaveChanges();

            // TODO:
            var booksFromQuery = context.Books.Take(3).Include(b => b.RelatedBooks);

            foreach (var book in booksFromQuery)
            {
                Console.WriteLine("--{0}", book.Title);
                foreach (var relatedBook in book.RelatedBooks)
                {
                    Console.WriteLine(relatedBook.Title);
                }
            }
        }
    }
}