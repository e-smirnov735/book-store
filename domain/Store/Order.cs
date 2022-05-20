namespace Store
{
    public class Order
    {
        public int Id { get; }
        public int TotalCount => _items.Sum(item => item.Count);
        public decimal TotalPrice => _items.Sum(item => item.Price * item.Count);
        private readonly List<OrderItem> _items;
        public IReadOnlyCollection<OrderItem> Items => _items;

        public Order(int id, IEnumerable<OrderItem> items)
        {
            if (items == null)
                throw new ArgumentNullException(nameof(items));

            Id = id;
            _items = new List<OrderItem>(items);
        }

        public OrderItem GetItem(int bookId)
        {
            int index = _items.FindIndex(item => item.BookId == bookId);

            if (index == -1)
                throw new InvalidOperationException("Book not found");

            return _items[index];
        }

        public void AddOrUpdateItem(Book book, int count)
        {
            if (book == null)
                throw new ArgumentNullException(nameof(book));

            int index = _items.FindIndex(item => item.BookId == book.Id);

            if (index == -1)
                _items.Add(new OrderItem(book.Id, count, book.Price));
            else
                _items[index].Count += count;
        }

        public void RemoveItem(int bookId)
        {
            int index = _items.FindIndex(item => item.BookId == bookId);

            if (index == -1)
                throw new InvalidOperationException("Order does not contains this book");

            _items.RemoveAt(index);
        }
    }
}
