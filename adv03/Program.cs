using Adv_c__3;

namespace Adv_c__3
{
    public class Book
    {
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string[] Authors { get; set; }
        public DateTime PublicationDate { get; set; }
        public decimal Price { get; set; }

        public Book(string _ISBN, string _Title, string[] _Authors, DateTime _PublicationDate, decimal _Price)
        {
            ISBN = _ISBN;
            Title = _Title;
            Authors = _Authors;
            PublicationDate = _PublicationDate;
            Price = _Price;
        }
    }

}
public delegate string BookDelegate_GetTitle(Book B);
public delegate string BookDelegate_GetISBN(Book B);
public delegate string BookDelegate_GetDate(Book B);


public static class BookFunctions
{
    public static string GetBookTitle(Book B)
    {
        return B.Title;
    }

    public static string GetBookPrice(Book B)
    {
        return B.Price.ToString("C");
    }
}



class Program
{
    static void Main()
    {
        static void Main()
        {
            List<Book> books = new List<Book>
        {
            new Book("123", "C# Basics", new[] { "John Doe" }, new DateTime(2021, 5, 1), 29.99m),
            new Book("456", "Advanced C#", new[] { "Jane Smith" }, new DateTime(2022, 3, 15), 49.99m)
        };

            #region Case a: User Defined Delegate (GetTitle)

            Console.WriteLine("Case a) User Defined Delegate:");
            BookDelegate_GetTitle fPtrA = new BookDelegate_GetTitle(BookFunctions.GetBookTitle);
            foreach (Book B in books)
            {
                Console.WriteLine(fPtrA(B));
            }
            #endregion

            #region Case b: BCL Delegate Func<Book, string> (GetPrice)
            Console.WriteLine("\nCase b) BCL Func Delegate:");
            Func<Book, string> fPtrB = BookFunctions.GetBookPrice;
            foreach (Book B in books)
            {
                Console.WriteLine(fPtrB(B));
            }
            #endregion

            #region Case c: Anonymous Method (GetISBN)
            Console.WriteLine("\nCase c) Anonymous Method:");
            BookDelegate_GetISBN fPtrC = delegate (Book B)
            {
                return B.ISBN;
            };
            foreach (Book B in books)
            {
                Console.WriteLine(fPtrC(B));
            }
            #endregion

            #region Case d: Lambda Expression (GetPublicationDate)
            Console.WriteLine("\nCase d) Lambda Expression:");
            BookDelegate_GetDate fPtrD = (Book B) => B.PublicationDate.ToShortDateString();
            foreach (Book B in books)
            {
                Console.WriteLine(fPtrD(B));
            }
            #endregion
        
    }
    }
}