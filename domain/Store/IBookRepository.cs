namespace Store
{
    public interface IBookRepository
    {
        Book GetById(int id);

        Book[] GetAllByIsbn(string isbn);

        Book[] GetAllByTitleOrAuthor(string titlePart);

        Book[] GetAllByIds(IEnumerable<int> bookIds);
    }
}
