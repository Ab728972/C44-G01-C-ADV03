using System.Diagnostics;

namespace C44_G01_C_ADV03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Sample Data
            List<Book> books = new List<Book>
            {
                new Book("123-456", "C# Programming", new string[] { "John Doe", "Jane Smith" }, new DateTime(2022, 1, 15), 49.99m),
                new Book("789-012", "Advanced C#", new string[] { "Alice Johnson" }, new DateTime(2023, 5, 20), 59.99m),
                new Book("345-678", ".NET Core", new string[] { "Bob Brown", "Charlie Davis", "Eve Wilson" }, new DateTime(2021, 11, 30), 39.99m)
            };
            #endregion

            Console.WriteLine("Processing books using different delegate approaches:");
            Console.WriteLine("=================================================");

            #region Delegate Demonstrations
            // 1. Using user-defined delegate
            Console.WriteLine("\n1. Using user-defined delegate (GetTitle):");
            LibraryEngine.BookDelegate titleDelegate = BookFunctions.GetTitle;
            LibraryEngine.ProcessBooks(books, titleDelegate);

            // 2. Using built-in Func delegate
            Console.WriteLine("\n2. Using built-in Func delegate (GetAuthors):");
            LibraryEngine.ProcessBooks(books, BookFunctions.GetAuthors);

            // 3. Using anonymous method for GetISBN
            Console.WriteLine("\n3. Using anonymous method (GetISBN equivalent):");
            LibraryEngine.ProcessBooks(books, delegate (Book b) { return b.ISBN; });

            // 4. Using lambda expression for GetPublicationDate
            Console.WriteLine("\n4. Using lambda expression (GetPublicationDate equivalent):");
            LibraryEngine.ProcessBooks(books, b => b.PublicationDate.ToShortDateString());

            // Additional demonstration with price
            Console.WriteLine("\nBonus: Using lambda expression for price:");
            LibraryEngine.ProcessBooks(books, b => $"Price: {b.Price:C}");
            #endregion
        }
        #region Book Class
        public class Book
        {
            #region Properties
            public string ISBN { get; set; }
            public string Title { get; set; }
            public string[] Authors { get; set; }
            public DateTime PublicationDate { get; set; }
            public decimal Price { get; set; }
            #endregion
        }
        #endregion
        #region Constructor
        public Book(string isbn, string title, string[] authors, DateTime publicationDate, decimal price)
        {
            ISBN = isbn;
            Title = title;
            Authors = authors;
            PublicationDate = publicationDate;
            Price = price;
        }
        #endregion
        #region Methods
        public override string ToString()
        {
            return $"ISBN: {ISBN}, Title: {Title}, Authors: {string.Join(", ", Authors)}, " +
                   $"Publication Date: {PublicationDate.ToShortDateString()}, Price: {Price:C}";
        }
        #endregion
        #region BookFunctions Class
        public class BookFunctions
        {
            #region Static Methods
            public static string GetTitle(Book b)
            {
                return b.Title;
            }

            public static string GetAuthors(Book b)
            {
                return string.Join(", ", b.Authors);
            }

            public static string GetPrice(Book b)
            {
                return $"{b.Price:C}";
            }

            public static string GetISBN(Book b)
            {
                return b.ISBN;
            }

            public static string GetPublicationDate(Book b)
            {
                return b.PublicationDate.ToShortDateString();
            }
            #endregion
        }
        #endregion
        #region LibraryEngine Class
        public class LibraryEngine
        {
            #region User-defined Delegate
            public delegate string BookDelegate(Book b);
            #endregion

            #region ProcessBooks Methods
            // 1. Using user-defined delegate
            public static void ProcessBooks(List<Book> bList, BookDelegate f)
            {
                foreach (Book b in bList)
                {
                    Console.WriteLine(f(b));
                }
            }

            // 2. Using built-in Func delegate
            public static void ProcessBooks(List<Book> bList, Func<Book, string> f)
            {
                foreach (Book b in bList)
                {
                    Console.WriteLine(f(b));
                }
            }
            #endregion
        }
        #endregion



    }
}

