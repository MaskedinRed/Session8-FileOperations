public class Library
{
    public string Name { get; set; }
    public List<Book> Books { get; set; }

    public Library() { }  // Needed for JSON deserialization

    public Library(string name)
    {
        Name = name;
        Books = new List<Book>();
    }

    public int BookCount
    {
        get { return Books?.Count ?? 0; }
    }

    public void AddBook(Book book)
    {
        Books.Add(book);
        Console.WriteLine($"Added '{book.Title}' to {Name}");
    }

    public bool RemoveBook(string title)
    {
        Book bookToRemove = FindBook(title);
        if (bookToRemove != null)
        {
            Books.Remove(bookToRemove);
            Console.WriteLine($"Removed '{title}' from {Name}");
            return true;
        }
        Console.WriteLine($"Book '{title}' not found");
        return false;
    }

    public Book FindBook(string title)
    {
        return Books.FirstOrDefault(b => b.Title.ToLower() == title.ToLower());
    }

    public List<Book> FindBooksByAuthor(string author)
    {
        return Books.Where(b => b.Author.ToLower().Contains(author.ToLower())).ToList();
    }

    public List<Book> GetAvailableBooks()
    {
        return Books.Where(b => !b.IsCheckedOut).ToList();
    }

    public void DisplayAllBooks()
    {
        Console.WriteLine($"\n=== {Name} ===");
        Console.WriteLine($"Total Books: {BookCount}");

        if (BookCount == 0)
        {
            Console.WriteLine("No books in library yet!");
            return;
        }

        Console.WriteLine();
        foreach (Book book in Books)
        {
            string status = book.IsCheckedOut ? "[CHECKED OUT]" : "[AVAILABLE]";
            Console.WriteLine($"  {status} {book.DisplayInfo}");
        }
    }
}
