# C# File Operations & Data

## Lesson Snapshot
Save your library data to files and load it back so books don't disappear when you close the program! (Ages 8-18)

**Session Date:** Saturday, October 25, 2025 at 11:00 AM EST

---

## Age-Tiered Learning Goals

| | Elementary (8-11) | Middle School (12-14) | High School (15-18) |
|---|---|---|---|
| **Files** | Understand that files save data permanently | Read and write text files | Work with JSON and CSV formats |
| **Error Handling** | Know that file operations can fail | Use basic try-catch blocks | Handle specific exception types |
| **By End** | See data persist between runs | Implement save/load features | Design backup and recovery |

---

## Before You Code: Hands-On Activities (15 minutes)

### Activity 1: Memory vs Storage - The Whiteboard Game

**Materials:** Whiteboard (erasable) and paper (permanent)

**Demonstration:**

```
    COMPUTER MEMORY                    FILE ON DISK
    (Whiteboard)                       (Paper)

    ┌────────────────┐                 ┌────────────────┐
    │ Harry Potter   │                 │ Harry Potter   │
    │ The Hobbit     │     SAVE →      │ The Hobbit     │
    │ Percy Jackson  │                 │ Percy Jackson  │
    └────────────────┘                 └────────────────┘
           │                                  │
           │ POWER OFF                        │ POWER OFF
           ▼                                  ▼
    ┌────────────────┐                 ┌────────────────┐
    │                │                 │ Harry Potter   │
    │   (erased!)    │                 │ The Hobbit     │  ← Still there!
    │                │                 │ Percy Jackson  │
    └────────────────┘                 └────────────────┘
```

**Activity:**
1. Write three book titles on the whiteboard
2. "Oh no, the power went out!" (erase the whiteboard)
3. Write the same titles on paper
4. "Power went out again!" (paper still has the titles)

**Key Insight:**
> "Computer memory is like a whiteboard - it gets erased when you turn off the power. Files are like paper - they keep your data safe!"

---

### Activity 2: JSON Scavenger Hunt (Pairs)

**What is JSON?** JavaScript Object Notation - a way to write data that both humans AND computers can read!

**Look at this JSON and answer the questions:**

```json
{
  "Name": "Philly CoderDojo Library",
  "Books": [
    {
      "Title": "Harry Potter",
      "Author": "J.K. Rowling",
      "PageCount": 309,
      "IsCheckedOut": false
    },
    {
      "Title": "The Hobbit",
      "Author": "J.R.R. Tolkien",
      "PageCount": 310,
      "IsCheckedOut": true
    }
  ]
}
```

**Questions:**
1. What is the library's name?
2. How many books are in the library?
3. Which book is checked out?
4. How many pages is Harry Potter?

**Discussion:**
> "JSON looks a lot like our C# objects! That's why it's so easy to save and load data with JSON."

---

### Activity 3: Save Game Simulation (Whole Class)

**Roleplay:** You're playing Minecraft and want to save your game.

**Round 1: No Save**
```
You built an amazing house! 🏠
You found diamonds! 💎
You tamed a wolf! 🐕

*Computer crashes* 💥

Result: Everything is GONE! 😭
```

**Round 2: With Save**
```
You built an amazing house! 🏠
[SAVE GAME] 💾
You found diamonds! 💎
[SAVE GAME] 💾
You tamed a wolf! 🐕
[SAVE GAME] 💾

*Computer crashes* 💥

Result: Load your save - everything is still there! 🎉
```

**Key Insight:**
> "Our Library program is the same - without saving to a file, all your books disappear when you close the program!"

---

## Visual Concept Map

```
    ┌─────────────────────────────────────────────────────────────┐
    │                    THE SAVE/LOAD CYCLE                       │
    └─────────────────────────────────────────────────────────────┘

         YOUR PROGRAM                         THE FILE
    ┌───────────────────┐                ┌───────────────────┐
    │                   │                │                   │
    │   Library Object  │ ──── SAVE ───→ │  library.json     │
    │   (in memory)     │                │  (on disk)        │
    │                   │ ←─── LOAD ──── │                   │
    └───────────────────┘                └───────────────────┘

    SAVE = Convert object to JSON text, write to file
    LOAD = Read file text, convert JSON back to object
```

---

## Flowchart: Save and Load Process

```
                    SAVING DATA
    ┌───────────────────────────────────────┐
    │  Library Object                       │
    │  ┌─────────────────────────────────┐  │
    │  │ Name: "My Library"              │  │
    │  │ Books: [book1, book2, book3]    │  │
    │  └─────────────────────────────────┘  │
    └───────────────────┬───────────────────┘
                        │
                        │  JsonConvert.SerializeObject()
                        │  "Turn object into text"
                        ▼
    ┌───────────────────────────────────────┐
    │  JSON Text String                     │
    │  '{"Name":"My Library","Books":[...]}'│
    └───────────────────┬───────────────────┘
                        │
                        │  File.WriteAllText()
                        │  "Write text to file"
                        ▼
    ┌───────────────────────────────────────┐
    │  📁 library_data.json                 │
    │  (saved on your hard drive!)          │
    └───────────────────────────────────────┘


                    LOADING DATA
    ┌───────────────────────────────────────┐
    │  📁 library_data.json                 │
    └───────────────────┬───────────────────┘
                        │
                        │  File.ReadAllText()
                        │  "Read text from file"
                        ▼
    ┌───────────────────────────────────────┐
    │  JSON Text String                     │
    └───────────────────┬───────────────────┘
                        │
                        │  JsonConvert.DeserializeObject()
                        │  "Turn text back into object"
                        ▼
    ┌───────────────────────────────────────┐
    │  Library Object (restored!)           │
    └───────────────────────────────────────┘
```

---

## Error Handling Visual

```
         What could go wrong?

    ┌─────────────────────────────────────┐
    │  TRY to save file                   │
    └────────────────┬────────────────────┘
                     │
         ┌───────────┴───────────┐
         │                       │
    ✅ SUCCESS               ❌ FAILURE
         │                       │
         ▼                       ▼
    "File saved!"          What went wrong?
                                 │
              ┌──────────────────┼──────────────────┐
              │                  │                  │
              ▼                  ▼                  ▼
        📁 File not       🔒 Permission       💾 Disk
        found!            denied!             full!
              │                  │                  │
              └──────────────────┼──────────────────┘
                                 │
                                 ▼
                    CATCH the error and
                    show helpful message
```

---

## Folder & File Map
```
LibraryManager/
├── .git/
├── .gitignore
├── LibraryManager.csproj
├── Program.cs
├── Book.cs
├── Library.cs
└── library_data.json     ← Created when you save!
```

---

## Prerequisites
- Completed Session 7 (Collections & Lists)
- Working Library with List<Book>

---

## Step-by-Step Build Guide

### 1. Fork and Clone the Repository
- **What to do**: Go to https://github.com/PhillyCoderDojo/Session8-FileOperations → Fork → Clone
- **Git command**: `git clone https://github.com/YOUR-USERNAME/Session8-FileOperations.git`

---

### 2. Understand the Problem

**Run the current program:**
1. Add some books
2. Close the program
3. Run again

**What happened to your books?** 😱 They're gone!

**Group Discussion:**
> "Why did the books disappear? Where were they stored?"

---

### 3. Learn Basic File Commands

**Three simple commands:**

```csharp
// Write text to a file
File.WriteAllText("filename.txt", "Hello, World!");

// Read text from a file
string content = File.ReadAllText("filename.txt");

// Check if file exists
bool exists = File.Exists("filename.txt");
```

**Pair Activity:**
> "What would happen if you try to read a file that doesn't exist?"

---

### 4. Check the JSON Package

Look in your `.csproj` file for this line:
```xml
<PackageReference Include="Newtonsoft.Json" Version="13.0.3" />
```

**If it's not there:** Right-click project → Manage NuGet Packages → Search "Newtonsoft.Json" → Install

---

### 5. Add Using Statement

At the top of Library.cs:
```csharp
using Newtonsoft.Json;
```

**Analogy:**
> "This is like telling C#: 'I want to use the JSON toolkit!'"

---

### 6. Add the Save Method

```csharp
public void SaveToFile(string filename)
{
    // Convert library to JSON text
    string json = JsonConvert.SerializeObject(this, Formatting.Indented);

    // Write to file
    File.WriteAllText(filename, json);

    Console.WriteLine($"📁 Library saved to {filename}");
}
```

**Visual - What SerializeObject Does:**
```
    Library Object                       JSON Text
    ┌──────────────────┐                ┌──────────────────────────┐
    │ Name = "My Lib"  │                │ {                        │
    │ Books = [...]    │  ────────→     │   "Name": "My Lib",      │
    └──────────────────┘  Serialize     │   "Books": [...]         │
                                        │ }                        │
                                        └──────────────────────────┘
```

---

### 7. Add the Load Method

```csharp
public static Library LoadFromFile(string filename)
{
    // Check if file exists
    if (!File.Exists(filename))
    {
        Console.WriteLine("📁 No saved data found. Starting fresh!");
        return new Library("My Library");
    }

    // Read file content
    string json = File.ReadAllText(filename);

    // Convert JSON back to Library
    Library library = JsonConvert.DeserializeObject<Library>(json);

    Console.WriteLine($"📁 Loaded {library.BookCount} books from {filename}");
    return library;
}
```

**Why is it `static`?**
> "We need to load the library BEFORE we have a library object. Static methods don't need an object to exist first!"

---

### 8. Test Save and Load

**Update Program.cs:**

```csharp
const string DATA_FILE = "library_data.json";

// Load existing library OR create new one
Library myLibrary = Library.LoadFromFile(DATA_FILE);

// Add books if library is empty
if (myLibrary.BookCount == 0)
{
    Console.WriteLine("Adding starter books...\n");
    myLibrary.AddBook(new Book { Title = "Harry Potter", Author = "J.K. Rowling", PageCount = 309 });
    myLibrary.AddBook(new Book { Title = "The Hobbit", Author = "J.R.R. Tolkien", PageCount = 310 });
}

// Show the library
myLibrary.DisplayAllBooks();

// Save before closing
myLibrary.SaveToFile(DATA_FILE);
```

**Test it:**
1. Run program (creates file, shows 2 books)
2. Close and run again (loads from file, still 2 books!)
3. 🎉 **Data persists!**

---

### 9. Look at the JSON File

Open `library_data.json` in Rider:

```json
{
  "Name": "My Library",
  "Books": [
    {
      "Title": "Harry Potter",
      "Author": "J.K. Rowling",
      "PageCount": 309,
      "IsCheckedOut": false
    },
    {
      "Title": "The Hobbit",
      "Author": "J.R.R. Tolkien",
      "PageCount": 310,
      "IsCheckedOut": false
    }
  ]
}
```

**Group Activity:**
> "Can you read this? Edit the JSON file directly and change a book title. Run the program - what happens?"

---

### 10. Add Error Handling

**What if something goes wrong?**

```csharp
public void SaveToFile(string filename)
{
    try
    {
        string json = JsonConvert.SerializeObject(this, Formatting.Indented);
        File.WriteAllText(filename, json);
        Console.WriteLine($"📁 Library saved to {filename}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"❌ Error saving: {ex.Message}");
    }
}
```

**Analogy:**
> "Try-catch is like a safety net. 'TRY to do this dangerous thing. If you fall (error), I'll CATCH you!'"

---

### 11. Add a Backup Feature

```csharp
public void SaveWithBackup(string filename)
{
    try
    {
        // Make backup of existing file
        if (File.Exists(filename))
        {
            string backupName = filename + ".backup";
            File.Copy(filename, backupName, overwrite: true);
            Console.WriteLine($"📋 Backup created: {backupName}");
        }

        // Save new version
        SaveToFile(filename);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"❌ Error during backup: {ex.Message}");
    }
}
```

**Visual:**
```
    library_data.json           library_data.json.backup
    ┌───────────────┐           ┌───────────────┐
    │ NEW DATA      │  BACKUP   │ OLD DATA      │
    │               │  ←──────  │ (just in case)│
    └───────────────┘           └───────────────┘
```

---

### 12. Create an Interactive Menu

```csharp
const string DATA_FILE = "library_data.json";
Library myLibrary = Library.LoadFromFile(DATA_FILE);

bool running = true;
while (running)
{
    Console.WriteLine("\n╔════════════════════════╗");
    Console.WriteLine("║    LIBRARY MENU        ║");
    Console.WriteLine("╠════════════════════════╣");
    Console.WriteLine("║ 1. View all books      ║");
    Console.WriteLine("║ 2. Add a book          ║");
    Console.WriteLine("║ 3. Search for a book   ║");
    Console.WriteLine("║ 4. Check out a book    ║");
    Console.WriteLine("║ 5. Return a book       ║");
    Console.WriteLine("║ 6. Save and exit       ║");
    Console.WriteLine("╚════════════════════════╝");
    Console.Write("Enter choice (1-6): ");

    string choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            myLibrary.DisplayAllBooks();
            break;

        case "2":
            Console.Write("Enter title: ");
            string title = Console.ReadLine();
            Console.Write("Enter author: ");
            string author = Console.ReadLine();
            Console.Write("Enter page count: ");
            if (int.TryParse(Console.ReadLine(), out int pages))
            {
                myLibrary.AddBook(new Book { Title = title, Author = author, PageCount = pages });
            }
            else
            {
                Console.WriteLine("❌ Invalid page count!");
            }
            break;

        case "3":
            Console.Write("Enter search term: ");
            string search = Console.ReadLine();
            Book found = myLibrary.FindBook(search);
            if (found != null)
                Console.WriteLine($"Found: {found.DisplayInfo}");
            else
                Console.WriteLine("Book not found.");
            break;

        case "4":
            Console.Write("Enter book title to check out: ");
            Book checkout = myLibrary.FindBook(Console.ReadLine());
            if (checkout != null)
                Console.WriteLine(checkout.CheckOut());
            else
                Console.WriteLine("Book not found.");
            break;

        case "5":
            Console.Write("Enter book title to return: ");
            Book returnBook = myLibrary.FindBook(Console.ReadLine());
            if (returnBook != null)
                Console.WriteLine(returnBook.Return());
            else
                Console.WriteLine("Book not found.");
            break;

        case "6":
            myLibrary.SaveWithBackup(DATA_FILE);
            running = false;
            Console.WriteLine("👋 Goodbye!");
            break;

        default:
            Console.WriteLine("❌ Invalid choice. Enter 1-6.");
            break;
    }
}
```

---

### 13-14. Commit and Push

1. **Commit:** "Add file save/load and interactive menu"
2. **Push:** Upload to GitHub

---

## Group Reflection (5 minutes)

**Partner Share:**
1. "Before today, when I closed a program, the data went to..."
2. "JSON is useful because..."
3. "Try-catch helps us when..."
4. "The coolest part was..."

---

## Run & Test Checklist

- [ ] First run creates starter books
- [ ] Closing and reopening keeps books
- [ ] Can add new books through menu
- [ ] Save creates .json file
- [ ] Backup file is created
- [ ] Invalid input doesn't crash

---

## Bonus Challenges

### Challenge 1: Auto-Save (All Levels)
Add a save after every add/remove/checkout operation!

### Challenge 2: Export to CSV (Middle+)
```csharp
public void ExportToCsv(string filename)
{
    var lines = new List<string>();
    lines.Add("Title,Author,PageCount,IsCheckedOut");

    foreach (Book book in Books)
    {
        lines.Add($"\"{book.Title}\",\"{book.Author}\",{book.PageCount},{book.IsCheckedOut}");
    }

    File.WriteAllLines(filename, lines);
    Console.WriteLine($"📄 Exported to {filename}");
}
```

### Challenge 3: Import from CSV (High School)
Write a method to import books from a CSV file!

---

## Vocabulary Wall

| Term | Kid-Friendly Definition | Code Example |
|------|------------------------|--------------|
| **File** | A way to store data permanently on disk | `library_data.json` |
| **JSON** | A text format for storing objects | `{"Title":"Harry Potter"}` |
| **Serialize** | Turn an object into text | `JsonConvert.SerializeObject()` |
| **Deserialize** | Turn text back into an object | `JsonConvert.DeserializeObject()` |
| **Try-Catch** | A safety net for risky code | `try { } catch { }` |
| **Backup** | A copy of your data just in case | `.backup` file |

---

## Take-Home Connection

**Family Activity:**
> Show your family member how the data persists:
> 1. Add their name as a book author
> 2. Close the program completely
> 3. Open it again - their name is still there!

**Real-World Files:**
- Minecraft saves worlds to files
- Word documents are files
- Phone contacts are stored in files
- Game progress is saved to files
