using System;

struct Blank
{
    public string Get_date { get; set; }
    public string Return_date { get; set; }

    public Blank(string get_date, string return_date)
    {
        Get_date = get_date;
        Return_date = return_date;
    }
}
struct Book
{
    public string Author { get; set; }
    public string Name { get; set; }
    public int Year { get; set; }
    public string Publisher { get; set; }
    public List<Blank> Blanks { get; set; }

    public Book(string author, string name, int year, string publisher, List<Blank> blanks)
    {
        Author = author;
        Name = name;
        Year = year;
        Publisher = publisher;
        Blanks = blanks;
    }
}

struct Library
{
    public List<Book> Books { get; set; }

    public Library(List<Book> books)
    {
        Books = books;
    }

    public List<Book> Get_never_borrowed()
    {
        List<Book> books = new List<Book>();

        foreach (Book book in Books)
        {
            if (book.Blanks.Count == 0 || book.Blanks == null)
            {
                books.Add(book);
            }
        }

        return books;
    }

    public List<Book> Get_currently_borrowed()
    {
        List<Book> books = new List<Book>();

        foreach (Book book in Books)
        {
            if (book.Blanks != null && book.Blanks.Count > 0)
            {
                Blank lastBlank = book.Blanks[book.Blanks.Count - 1];
                if (lastBlank.Return_date == null)
                {
                    books.Add(book);
                }
            }
        }

        return books;
    }
}

class Program
{
    static void Main()
    {
        var blank1 = new Blank("2025-01-01", "2025-01-15");
        var blank2 = new Blank("2024-05-07", null);
        var blank3 = new Blank("2023-06-05", "2023-07-15");

        var book1 = new Book("Author1", "Book1", 2053, "A1", new List<Blank>());
        var book2 = new Book("Author2", "Book2", 6525, "A2", new List<Blank> { blank1 });
        var book3 = new Book("Author3", "Book3", 1353, "B3", new List<Blank> { blank2 });
        var book4 = new Book("Author4", "Book4", 3255, "N6", new List<Blank> { blank1, blank3 });

        var library = new Library(new List<Book> { book1, book2, book3, book4 });

        var never_borrowed = library.Get_never_borrowed();
        Console.WriteLine("Никогда не купленные книги:");
        foreach (var book in never_borrowed)
        {
            Console.WriteLine($"{book.Author} - {book.Name}");
        }

        var currently_borrowed = library.Get_currently_borrowed();
        Console.WriteLine("\nНевозвращеные книги:");
        foreach (var book in currently_borrowed)
        {
            Console.WriteLine($"{book.Author} - {book.Name}");
        }
    }
}