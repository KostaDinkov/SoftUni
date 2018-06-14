namespace _05.BookLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class BookLibrary
    {
        private static void Main()
        {
            var library = new Library();
            var count = int.Parse(Console.ReadLine());
            for (var i = 0; i < count; i++)
            {
                var bookInput = Console.ReadLine().Split(" ");
                library.AddBook(new Book
                {
                    Title = bookInput[0],
                    Author = bookInput[1],
                    Publisher = bookInput[2],
                    ReleaseDate = DateTime.ParseExact(bookInput[3],"dd.MM.yyyy", null),
                    ISBN = bookInput[4],
                    Price = decimal.Parse(bookInput[5])
                });
            }

            var grouped = library.Books
                .GroupBy(b => b.Author)
                .Select(g => new
                {
                    Author = g.Key,
                    TotalPrice = g.Sum(b => b.Price)
                })
                .OrderByDescending(b=>b.TotalPrice)
                .ThenBy(b=>b.Author);
            foreach (var author in grouped)
            {
                Console.WriteLine($"{author.Author} -> {String.Format("{0:0.00}",author.TotalPrice)}");
            }
        }
    }


    internal class Library
    {
        public List<Book> Books { get; }

        public Library()
        {
            this.Books = new List<Book>();
        }

        public string Name { get; set; }

        public void AddBook(Book book)
        {
            this.Books.Add(book);
        }
    }

    internal class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string ISBN { get; set; }
        public decimal Price { get; set; }
    }
}