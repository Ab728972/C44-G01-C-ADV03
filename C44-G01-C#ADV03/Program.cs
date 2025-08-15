using System.Diagnostics;

namespace C44_G01_C_ADV03
{
    internal class Program
    {
        static void Main(string[] args)
        {

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

       
    }
}

