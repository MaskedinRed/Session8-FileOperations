using Newtonsoft.Json;

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
    
    public void SaveToFile(string filename)
    {
        try
        {
            //Convert library to JSON text
            string json = JsonConvert.SerializeObject(this, Formatting.Indented);

            //Write to file
            File.WriteAllText(filename, json);

            Console.WriteLine($"Library saved to {filename}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving: {ex.Message}");
        }
    }

    public void SaveWithBackup(string filename)
    {
        try
        {
            //Make backup of existing file
            if (File.Exists(filename))
            {
                string backupName = filename + ".backup";
                File.Copy(filename, backupName, overwrite: true);
                Console.WriteLine($"Backup created: {backupName}");
            }

            //Save new version
            SaveToFile(filename);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error during backup: {ex.Message}");
        }
    }

    public static Library LoadFromFile(string filename)
    {
        //Check if file exists
        if (!File.Exists(filename))
        {
            Console.WriteLine("No saved data found. Starting fresh...");
            return new Library("My Library");
        }
        
        //Read file content
        string json = File.ReadAllText(filename);
        
        //Convert JSON back to Library
        Library library = JsonConvert.DeserializeObject<Library>(json);

        Console.WriteLine($"Loaded {library.BookCount} books from {filename}");
        return library;
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

    public void ExportToCsv(string filename)
    {
        var lines = new List<string>();
        lines.Add("Title,Author,PageCount,IsCheckedOut");

        foreach (Book book in Books)
        {
            lines.Add($"\"{book.Title}\",\"{book.Author}\", {book.PageCount}, {book.IsCheckedOut}");
        }

        File.WriteAllLines(filename, lines);
        Console.WriteLine($"Exported to {filename}");
    }
}
