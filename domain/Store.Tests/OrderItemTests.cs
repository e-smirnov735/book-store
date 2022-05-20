namespace Store.Tests
{
    public class OrderItemTests
    {
        [Fact]
        public void OrderItem_WithZeroCount_ThrowException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                int count = 0;
                new OrderItem(1, count, 0m);
            });
        }

        [Fact]
        public void OrderItem_WithNegativeCount_ThrowException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                int count = -1;
                new OrderItem(1, count, 0m);
            });
        }

        [Fact]
        public void OrderItem_WithPositiveCount_ThrowException()
        {
            var orderItem = new OrderItem(1, 2, 3m);
            Assert.Equal(1, orderItem.BookId);
            Assert.Equal(2, orderItem.Count);
            Assert.Equal(3m, orderItem.Price);
        }

        [Fact]
        public void Count_WithNegativeValue_ThrowArgumentException()
        {
            var orderItem = new OrderItem(0, 5, 0m);

            Assert.Throws<ArgumentOutOfRangeException>(() =>
                {
                    orderItem.Count = -1;
                });
        }

        [Fact]
        public void Count_WithZeroValue_ThrowArgumentException()
        {
            var orderItem = new OrderItem(0, 5, 0m);

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                orderItem.Count = 0;
            });
        }

        [Fact]
        public void Count_WithPositiveValue_SetValue()
        {
            var orderItem = new OrderItem(0, 5, 0m);
            orderItem.Count = 2;

            Assert.Equal(2, orderItem.Count);
        }



    }
}
