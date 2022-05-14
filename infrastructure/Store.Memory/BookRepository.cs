namespace Store.Memory
{
    public class BookRepository : IBookRepository
    {
        private readonly Book[] books = new[]
        {
            new Book(1, "Art of Programming"),
            new Book(2, "Refactoring"),
            new Book(3, "C Programming Language"),
        };


        public Book[] GetAllByTitle(string titlePart)
        {
            string query = titlePart.ToLower();
            return books.Where(book => book.Title.ToLower().Contains(titlePart)).ToArray();
        }
    }
}