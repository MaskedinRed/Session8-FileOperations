public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int PageCount { get; set; }
    public bool IsCheckedOut { get; set; }

    public string DisplayInfo
    {
        get { return $"{Title} by {Author} ({PageCount} pages)"; }
    }

    public string CheckOut()
    {
        if (IsCheckedOut)
        {
            return $"{Title} is already checked out!";
        }

        IsCheckedOut = true;
        return $"You have checked out: {Title}";
    }

    public string Return()
    {
        if (!IsCheckedOut)
        {
            return $"{Title} was not checked out!";
        }

        IsCheckedOut = false;
        return $"Thank you for returning: {Title}";
    }
}
