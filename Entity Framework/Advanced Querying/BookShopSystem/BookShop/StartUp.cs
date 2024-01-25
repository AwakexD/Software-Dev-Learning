using System.Text;
using BookShop.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace BookShop
{
    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            DbInitializer.ResetDatabase(db);

            Console.WriteLine(GetMostRecentBooks(db));
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            try
            {
                AgeRestriction restriction = Enum.Parse<AgeRestriction>(command, true);

                var books = context.Books
                    .Where(x => x.AgeRestriction == restriction)
                    .Select(x => x.Title)
                    .OrderBy(t => t)
                    .ToList();

                return string.Join("\n", books);

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            try
            {
                var books = context.Books
                    .Where(b => b.EditionType == EditionType.Gold)
                    .Where(b => b.Copies < 5000)
                    .OrderBy(b => b.BookId)
                    .Select(b => b.Title)
                    .ToList();

                return string.Join('\n', books);
            }
            catch (Exception e)
            {
                return e.Message;
            }

        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            try
            {
                var books = context.Books
                    .Where(b => b.Price > 40)
                    .OrderByDescending(b => b.Price)
                    .Select(b => $"{b.Title} - ${b.Price}")
                    .ToList();
                    

                return string.Join("\n", books);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            try
            {
                var books = context.Books
                    .Where(b => b.ReleaseDate.Value.Year != year)
                    .OrderBy(b => b.BookId)
                    .Select(b => b.Title)
                    .ToList();

                return string.Join("\n", books);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            try
            {
                string[] categories = input.ToLower().Split();

                var books = context.BooksCategories
                    .Where(bc => categories.Contains(bc.Category.Name.ToLower()))
                    .OrderBy(bc => bc.Book.Title)
                    .Select(bc => bc.Book.Title)
                    .ToList();

                return string.Join("\n", books);

            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            try
            {
                var books = context.Books
                    .Where(b => b.ReleaseDate < DateTime.ParseExact(date, "dd-MM-yyyy", null))
                    .OrderByDescending(b => b.ReleaseDate)
                    .Select(b => $"{b.Title} - {b.EditionType} - ${b.Price}")
                    .ToList();

                return string.Join("\n", books);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            try
            {
                var authorNames = context.Authors
                    .Where(a => a.FirstName.EndsWith(input))
                    .OrderBy(a => a.FirstName)
                    .ThenBy(a => a.LastName)
                    .Select(a => a.FirstName + ' ' + a.LastName)
                    .ToList();

                return string.Join("\n", authorNames);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            try
            {
                var books = context.Books
                    .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                    .OrderBy(b => b.Title)
                    .Select(b => b.Title)
                    .ToList();

                return string.Join("\n", books);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();

            try
            {
                var books = context.Books
                    .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                    .Select(b => new
                    {
                        b.Title,
                        b.BookId,
                        Author = $"{b.Author.FirstName} {b.Author.LastName}",
                    })
                    .OrderBy(b => b.BookId)
                    .ToList();

                foreach (var book in books)
                {
                    sb.AppendLine($"{book.Title} ({book.Author})");
                }

                return sb.ToString();
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            try
            {
                var booksCount = context.Books
                    .Where(b => b.Title.Length > lengthCheck)
                    .Count();

                return booksCount;
            }
            catch (Exception e)
            {
                return -1;
            }
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            try
            {
                var books = context.Authors
                    .Select(a => new
                    {
                        Name = $"{a.FirstName} {a.LastName}",
                        Copies = a.Books.Select(b => b.Copies).Sum()
                    })
                    .OrderByDescending(a => a.Copies)
                    .ToList();

                return string.Join('\n', books.Select(x => $"{x.Name} - {x.Copies}"));
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            try
            {
                var profits = context.Categories
                    .Select(c => new
                    {
                        CategoryName = c.Name,
                        TotalProfits = c.CategoryBooks
                            .Select(x => x.Book.Price * x.Book.Copies)
                            .Sum()
                    })
                    .OrderByDescending(x => x.TotalProfits)
                    .ThenBy(x => x.CategoryName)
                    .ToList();

                return string.Join('\n', profits.Select(x => $"{x.CategoryName} - ${x.TotalProfits:f2}"));
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            try
            {
                var listofMostRecentBooks = context.Categories
                    .Select(c => new
                    {
                        CategoryName = c.Name,
                        MostRecentBooks = c.CategoryBooks
                            .Select(b => b.Book)
                            .OrderByDescending(b => b.ReleaseDate)
                            .Take(3)
                            .Select(b => $"{b.Title} ({b.ReleaseDate.Value.Year})")
                            .ToList()
                    })
                    .OrderBy(c => c.CategoryName)
                    .ToList();

                foreach (var category in listofMostRecentBooks)
                {
                    sb.AppendLine($"--{category.CategoryName}");
                    foreach (var book in category.MostRecentBooks)
                    {
                        sb.AppendLine(book);
                    }
                }

                return sb.ToString();
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public static void IncreasePrices(BookShopContext context)
        {
            try
            {
                var books = context.Books
                    .Where(b => b.ReleaseDate.Value.Year < 2010)
                    .ToArray();

                foreach (var book in books)
                {
                    book.Price += 5;
                }

                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new DbUpdateException();
            }
        }

    }
}


