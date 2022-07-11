namespace BookShop
{
    using Models.Enums;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;
    using System.Text;
    using System;
    using System.Linq;
    using System.Globalization;
    using BookShop.Models;
using static System.Reflection.Metadata.BlobBuilder;
using static Microsoft.EntityFrameworkCore.Internal.AsyncLock;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            /*
            DbInitializer.ResetDatabase(db);

            //02. Age Restriction
            var input = Console.ReadLine();
            Console.WriteLine(GetBooksByAgeRestriction(db, input));

            //03.Golden Books
            Console.WriteLine(GetGoldenBooks(db));

            //04.Books by Price
            Console.WriteLine(GetBooksByPrice(db));

            //5. Not Released In
            var input = int.Parse(Console.ReadLine());
            Console.WriteLine(GetBooksNotReleasedIn(db, input));

            //06. Book Titles by Category
            var input = Console.ReadLine();
            Console.WriteLine(GetBooksByCategory(db, input));

            //07. Released Before Date
            var input = Console.ReadLine();
            Console.WriteLine(GetBooksReleasedBefore(db, input));

            //08.Author Search
            var input = Console.ReadLine();
            Console.WriteLine(GetAuthorNamesEndingIn(db, input));

            //09.Book Search
            var input = Console.ReadLine();
            Console.WriteLine(GetBookTitlesContaining(db, input));

            //10. Book Search by Author
            var input = Console.ReadLine();
            Console.WriteLine(GetBooksByAuthor(db, input));

            //11. Count Books
            var input = int.Parse(Console.ReadLine());
            var output = CountBooks(db, input);
            Console.WriteLine(output);
            Console.WriteLine($"There are {output} books with longer title than {input} symbols");

            //12.Total Book Copies
            Console.WriteLine(CountCopiesByAuthor(db));

            //13. Profit by Category
            Console.WriteLine(GetTotalProfitByCategory(db));

            //14.Most Recent Books
            Console.WriteLine(GetMostRecentBooks(db));

            //15. Increase Prices
            IncreasePrices(db);
            */

            //16. Remove Books
            Console.WriteLine(RemoveBooks(db));

        }

        //16. Problem
        public static int RemoveBooks(BookShopContext context)
        {
            var lessCopies = 4200;
            var books = context.Books
                .Where(b => b.Copies < lessCopies);

            var countOfBooksToRemove = books.Count();

            foreach (var book in books)
            {
                context.Remove(book);
            }

            context.SaveChanges();

            return countOfBooksToRemove;
        }

        //15. Problem
        public static void IncreasePrices(BookShopContext context)
        {
            var releasedYear = 2010;
            var increasePrice = 5;

            var booksReleased = context.Books
                .Where(b => b.ReleaseDate.Value.Year < releasedYear);

            foreach (var book in booksReleased)
            {
                book.Price += increasePrice;
            }

            context.SaveChanges();
        }

        //14. Problem
        public static string GetMostRecentBooks(BookShopContext context)
        {
            var recentBooks = context.Categories
                .Select(c => new
                {
                    c.Name,
                    Books = c.CategoryBooks
                    .Select(b => b.Book)
                    .OrderByDescending(b => b.ReleaseDate)
                    .Take(3)
                    .Select(b => new
                    {
                        b.Title,
                        RecentYear = b.ReleaseDate.Value.Year
                    })
                    .ToList()
                })
                .OrderBy(c => c.Name)
                .ToList();

            var sb = new StringBuilder();

            foreach (var category in recentBooks)
            {
                sb.AppendLine($"--{category.Name}");

                foreach (var book in category.Books)
                {
                    sb.AppendLine($"{book.Title} ({book.RecentYear})");
                }
            }

            return sb.ToString().TrimEnd();
        }

        //13. Problem
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var books = context.Categories
                .Select(c => new
                {
                    c.Name,
                    Profit = c.CategoryBooks.Sum(cb => cb.Book.Copies * cb.Book.Price)
                })
                .OrderByDescending(c => c.Profit)
                .ThenBy(c => c.Name)
                .ToList();

            var sb = new StringBuilder();

            foreach (var category in books)
            {
                sb.AppendLine($"{category.Name} ${category.Profit}");
            }

            return sb.ToString().TrimEnd();
        }

        //12. Problem
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var books = context.Authors
                .Select(a => new
                {
                    FullName = $"{a.FirstName} {a.LastName}",
                    BooksCopies = a.Books.Sum(b => b.Copies),
                })
                .OrderByDescending(c => c.BooksCopies)
                .ToList();

            var sb = new StringBuilder();

            foreach (var author in books)
            {
                sb.AppendLine($"{author.FullName} - {author.BooksCopies}");
            }

            return sb.ToString().TrimEnd();
        }

        //11. Problem
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var books = context.Books
                .Count(b => b.Title.Length > lengthCheck);

            return books;
        }

        //10. Problem
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var givenString = input.ToUpper();
            var bookInfo = context.Authors
                .Where(a => a.LastName.ToUpper().StartsWith(givenString))
                .Select(a => new
                {
                    a.FirstName,
                    a.LastName,
                    BookTitle = a.Books.OrderBy(b => b.BookId).ToList(),
                })
                .ToList();

            var sb = new StringBuilder();

            foreach (var author in bookInfo)
            {
                foreach (var book in author.BookTitle)
                {
                    sb.AppendLine($"{book.Title} ({author.FirstName} {author.LastName})");
                }
            }

            return sb.ToString().TrimEnd();
        }

        //09. Problem
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var givenString = input.ToUpper();
            var book = context.Books
                .Where(b => b.Title.ToUpper().Contains(givenString))
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToList();

            var sb = new StringBuilder();
            foreach (var title in book)
            {
                sb.AppendLine(title);
            }

            return sb.ToString().TrimEnd();
        }

        //08 Problem
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authors = context.Authors
                .Where(a => a.FirstName.EndsWith(input))
                .OrderBy(a => a.FirstName)
                .ThenBy(a => a.LastName)
                .Select(a => new
                {
                    Fullname = $"{a.FirstName} {a.LastName}"
                })
                .ToList();

            var sb = new StringBuilder();

            foreach (var author in authors)
            {
                sb.AppendLine(author.Fullname);
            }

            return sb.ToString().TrimEnd();
        }

        //07. Problem
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            DateTime dateBefore = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var books = context.Books
                .Where(b => b.ReleaseDate < dateBefore)
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => new
                {
                    b.Title,
                    b.EditionType,
                    b.Price,
                })
                .ToList();

            var sb = new StringBuilder();

            foreach (var info in books)
            {
                sb.AppendLine($"{info.Title} - {info.EditionType} - ${info.Price:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        //06. Problem
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var category = input
                .ToLower()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var books = context.Books
                .Where(b => b.BookCategories.Any(bc => category.Contains(bc.Category.Name.ToLower())))
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToList();

            var sb = new StringBuilder();

            foreach (var title in books)
            {
                sb.AppendLine(title);
            }

            return sb.ToString().TrimEnd();
        }

        //05. Problem
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var books = context.Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToList();

            var sb = new StringBuilder();

            foreach (var title in books)
            {
                sb.AppendLine(title);
            }

            return sb.ToString().TrimEnd();
        }

        //04. Problem
        public static string GetBooksByPrice(BookShopContext context)
        {
            var targetPrice = 40;
            var books = context.Books
                .Where(b => b.Price > targetPrice)
                .OrderByDescending(b => b.Price)
                .Select(b => new
                {
                    b.Price,
                    b.Title,
                })
                .ToArray();

            var sb = new StringBuilder();

            foreach (var info in books)
            {
                sb.AppendLine($"{info.Title} - ${info.Price:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        //03. Problem
        public static string GetGoldenBooks(BookShopContext context)
        {
            var copies = 5000;

            var books = context.Books
                .Where(b => b.EditionType == EditionType.Gold && b.Copies < copies)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToArray();

            var sb = new StringBuilder();

            foreach (var title in books)
            {
                sb.AppendLine(title);
            }

            return sb.ToString().TrimEnd();
        }

        //02. Problem
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var ageRestriction = Enum.Parse<AgeRestriction>(command, true);

            var books = context.Books
                .Where(b => b.AgeRestriction == ageRestriction)
                .Select(b => b.Title)
                .OrderBy(title => title)
                .ToArray();

            var sb = new StringBuilder();

            foreach (var title in books)
            {
                sb.AppendLine(title);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
