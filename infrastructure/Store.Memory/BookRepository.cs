namespace Store.Memory
{
    public class BookRepository : IBookRepository
    {
        private readonly Book[] books = new[]
        {
            new Book(1, "Art of Programming", "ISBN 12321-32131", "D. Knuth" ),
            new Book(2, "Refactoring", "ISBN 12312-31232", "M. Fowler"),
            new Book(3, "C Programming Language", "ISBN 12312-31232", "B. Kernigan, D.Ritchie"),
        };

        public Book[] GetAllByIsbn(string isbn)
        {
            return books.Where(book => book.Isbn == isbn).ToArray();
        }

        public Book[] GetAllByTitleOrAuthor(string query)
        {
            return books.Where(book => book.Author.ToLower().Contains(query.ToLower())
                                    || book.Title.ToLower().Contains(query.ToLower()))
                        .ToArray();
        }
    }
}