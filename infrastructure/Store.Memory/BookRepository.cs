namespace Store.Memory
{
    public class BookRepository : IBookRepository
    {
        private readonly Book[] books = new[]
        {
            new Book(1, "Art of Programming", "ISBN 12321-32131", "D. Knuth", "Description1", 7.19m ),
            new Book(2, "Refactoring", "ISBN 12312-31232", "M. Fowler", "Description2", 12.45m),
            new Book(3, "C Programming Language", "ISBN 12312-31232", "B. Kernigan, D.Ritchie", "description3", 14.98m),
        };

        public Book[] GetAllByIds(IEnumerable<int> bookIds)
        {
            var foundBooks = from book in books
                             join bookId in bookIds on book.Id equals bookId
                             select book;

            return foundBooks.ToArray();
        }

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

        public Book GetById(int id)
        {
            return books.Single(book => book.Id == id);
        }

    }
}