// Session 8: File Operations & Data
// Let's learn how to save our library data!

// Create a library
Library myLibrary = new Library("Philly CoderDojo Library");

// Add some books
myLibrary.AddBook(new Book { Title = "Harry Potter", Author = "J.K. Rowling", PageCount = 309 });
myLibrary.AddBook(new Book { Title = "The Hobbit", Author = "J.R.R. Tolkien", PageCount = 310 });

// Display the library
myLibrary.DisplayAllBooks();

// PROBLEM: When you close the program, all the books disappear!
// We need to learn how to SAVE our data to a file.
Console.WriteLine("\n--- Close and reopen this program ---");
Console.WriteLine("Notice that you have to add the books again each time?");
Console.WriteLine("We'll fix that by learning to save data to files!");
