namespace Store.Tests
{
    public class BookTests
    {
        [Fact]
        public void IsIsbn_WithEmpty_ReturnFalse()
        {
            bool actual = Book.IsIsbn("");
            Assert.False(actual);
        }

        [Fact]
        public void IsIsbn_WithBlankString_ReturnFalse()
        {
            bool actual = Book.IsIsbn("         ");
            Assert.False(actual);
        }

        [Fact]
        public void IsIsbn_WithInvalidIsbn_ReturnFalse()
        {
            bool actual = Book.IsIsbn("ISBN 123");
            Assert.False(actual);
        }

        [Fact]
        public void IsIsbn_WithIsbn10_ReturnTrue()
        {
            bool actual = Book.IsIsbn("ISBN 123-456-789-0");
            Assert.True(actual);
        }

        [Fact]
        public void IsIsbn_WithIsbn13_ReturnTrue()
        {
            bool actual = Book.IsIsbn("ISBN 123-456-789-0123");
            Assert.True(actual);
        }

        [Fact]
        public void IsIsbn_WithTrashStar_ReturnFalse()
        {
            bool actual = Book.IsIsbn("xxxxcjhg876ISBN 123-456-789-0123yyyyy");
            Assert.False(actual);
        }
    }
}