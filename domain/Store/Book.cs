using System.Text.RegularExpressions;

namespace Store;

public class Book
{
    public int Id { get; }
    public string Title { get; }
    public string Isbn { get; }
    public string Author { get; }
    public string Description { get; }
    public decimal Price { get; }

    public Book(int id, string title, string isbn, string author, string description, decimal price)
    {
        Id = id;
        Title = title;
        Isbn = isbn;
        Author = author;
        Description = description;
        Price = price;
    }

    internal static bool IsIsbn(string str)
    {
        string newStr = str.Trim()
                 .Replace("-", "")
                 .Replace(" ", "")
                 .ToUpper();

        return Regex.IsMatch(newStr, @"^ISBN\d{10}(\d{3})?$");
    }
}
