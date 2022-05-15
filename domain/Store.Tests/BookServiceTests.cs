using Moq;

namespace Store.Tests
{
    public class BookServiceTests
    {
        [Fact]
        public void getAllByQuery_WithIsbn_CallsGetAllByIsbn()
        {
            var bookRepositoryStub = new Mock<IBookRepository>();

            bookRepositoryStub.Setup(x => x.GetAllByIsbn(It.IsAny<string>()))
                .Returns(new[] { new Book(1, "", "", "", "", 10) });

            bookRepositoryStub.Setup(x => x.GetAllByTitleOrAuthor(It.IsAny<string>()))
               .Returns(new[] { new Book(2, "", "", "", "", 0m) });
            var bookService = new BookService(bookRepositoryStub.Object);
            var validIsbn = "ISBN 12345-67890";


            var actual = bookService.GetAllByQuery(validIsbn);
            Assert.Collection(actual, book => Assert.Equal(1, book.Id));
        }

        [Fact]
        public void getAllByQuery_WithAuthor_CallsGetAllBytitleOrAuthor()
        {
            var bookRepositoryStub = new Mock<IBookRepository>();

            bookRepositoryStub.Setup(x => x.GetAllByIsbn(It.IsAny<string>()))
                .Returns(new[] { new Book(1, "", "", "", "", 0) });

            bookRepositoryStub.Setup(x => x.GetAllByTitleOrAuthor(It.IsAny<string>()))
               .Returns(new[] { new Book(2, "", "", "", "", 0m) });
            var bookService = new BookService(bookRepositoryStub.Object);
            var invalidIsbn = "123567-890";


            var actual = bookService.GetAllByQuery(invalidIsbn);
            Assert.Collection(actual, book => Assert.Equal(2, book.Id));
        }
    }
}
