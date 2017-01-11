using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.IO;
using Models;

namespace BookShopSystem.Data
{
    class BookShopDBInitializer : DropCreateDatabaseIfModelChanges<BookShopContext>
    {
        protected override void Seed(BookShopContext context)
        {
            ImportData(context);
            base.Seed(context);
        }

        private static List<Author> GetAuthors(string fileName)
        {
            List<Author> authors = new List<Author>();
            using (var reader = new StreamReader(fileName))
            {
                var line = reader.ReadLine();
                line = reader.ReadLine();
                while (line != null)
                {
                    var authorParams = line.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                    var firstName = authorParams[0];
                    var lastName = authorParams[1];

                    Author author = new Author {FirstName = firstName, LastName = lastName};
                    authors.Add(author);
                    line = reader.ReadLine();
                }
            }
            return authors;
        }

        private static List<Category> GetCategories(string fileName)
        {
            List<Category> categories = new List<Category>();
            using (var reader = new StreamReader(fileName))
            {
                var line = reader.ReadLine();

                while (line != null)
                {
                    Category category = new Category {Name = line};
                    categories.Add(category);
                    line = reader.ReadLine();
                }
            }
            return categories;
        }

        private static void ImportData(BookShopContext context)
        {
            var authors = GetAuthors("authors.txt");
            var categories = GetCategories("categories.txt");

            var random = new Random();

            using (var reader = new StreamReader("books.txt"))
            {
                var line = reader.ReadLine();
                line = reader.ReadLine();
                while (line != null)
                {
                    var data = line.Split(new[] {' '}, 6);
                    var authorIndex = random.Next(0, authors.Count);
                    var author = authors[authorIndex];
                    var edition = (EditionType) int.Parse(data[0]);
                    var releaseDate = DateTime.ParseExact(data[1], "d/M/yyyy", CultureInfo.InvariantCulture);
                    var copies = int.Parse(data[2]);
                    var price = decimal.Parse(data[3]);
                    var ageRestriction = (AgeRestriction) int.Parse(data[4]);
                    var title = data[5];
                    var book = new Book
                               {
                                   Author = author,
                                   EditionType = edition,
                                   ReleaseDate = releaseDate,
                                   Copies = copies,
                                   Price = price,
                                   AgeRestriction = ageRestriction,
                                   Title = title

                               };
                    book.Category.Add(categories[random.Next(0,categories.Count)]);
                    context.Books.Add(book);

                    line = reader.ReadLine();
                }
            }
        }
    }
}