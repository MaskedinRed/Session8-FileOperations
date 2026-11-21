// Session 8: File Operations & Data
// Let's learn how to save our library data!
const string DATA_FILE = "library_data.json";
//Load existing library OR create new one
Library myLibrary = Library.LoadFromFile(DATA_FILE);

bool running = true;
while (running)
{
    Console.WriteLine("\n╔═══════════════════════╗");
    Console.WriteLine("║     LIBRARY MENU      ║");
    Console.WriteLine("╠═══════════════════════╣");
    Console.WriteLine("║ 1  View all books     ║");
    Console.WriteLine("║ 2  Add a book         ║");
    Console.WriteLine("║ 3  Search for a book  ║");
    Console.WriteLine("║ 4  Check out a book   ║");
    Console.WriteLine("║ 5  Return a book      ║");
    Console.WriteLine("║ 6  Save and exit      ║");
    Console.WriteLine("╚═══════════════════════╝");
    Console.WriteLine("Enter choice (1-6): ");

    string choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            myLibrary.DisplayAllBooks();
            break;
        
        case "2":
            Console.WriteLine("Enter title: ");
            string title = Console.ReadLine();
            Console.WriteLine("Enter author: ");
            string author = Console.ReadLine();
            Console.WriteLine("Enter page count: ");
            if (int.TryParse(Console.ReadLine(), out int pages))
            {
                myLibrary.AddBook(new Book { Title = title, Author = author, PageCount = pages });
            }
            else
            {
                Console.WriteLine("Invalid page count!");
            }
            break;
        
        case "3":
            Console.WriteLine("Enter search term: ");
            string search = Console.ReadLine();
            Book found = myLibrary.FindBook(search);
            if (found != null)
                Console.WriteLine($"Found: {found.DisplayInfo}");
            else
                Console.WriteLine("Book not found.");
            break;
        
         case "4":
             Console.WriteLine("Enter book title to check out: ");
             Book checkout = myLibrary.FindBook(Console.ReadLine());
             if (checkout != null)
                 Console.WriteLine(checkout.CheckOut());
             else
                 Console.WriteLine("Book not found.");
             break;
         
         case "5":
             Console.WriteLine("Enter book title to return: ");
             Book returnBook = myLibrary.FindBook(Console.ReadLine());
             if (returnBook != null)
                Console.WriteLine(returnBook.Return());
             else
                Console.WriteLine("Book not found.");
             break;
         
         case "6":
            myLibrary.SaveWithBackup(DATA_FILE);
            running = false;
            Console.WriteLine("Goodbye!");
            break;
         
         default:
             Console.WriteLine("Invalid choice. Enter 1-6.");
             break;
         
    }
}

// Add some books if library is empty
if (myLibrary.BookCount == 0)
{
    Console.WriteLine("Adding starter books.\n");
    myLibrary.AddBook(new Book { Title = "Harry Potter", Author = "J.K. Rowling", PageCount = 309 });
    myLibrary.AddBook(new Book { Title = "The Hobbit", Author = "J.R.R. Tolkien", PageCount = 310 });
}

// Display the library
myLibrary.DisplayAllBooks();

//Save before closing
myLibrary.SaveToFile(DATA_FILE);

// PROBLEM: When you close the program, all the books disappear!
// We need to learn how to SAVE our data to a file.
Console.WriteLine("\n--- Close and reopen this program ---");
Console.WriteLine("Notice that you have to add the books again each time?");
Console.WriteLine("We'll fix that by learning to save data to files!");
