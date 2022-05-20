namespace Store.Tests
{
    public class OrderTests
    {
        [Fact]
        public void Order_WithNullItems_ThrowsArgumentsNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new Order(1, null));
        }

        [Fact]
        public void TotalCount_WithEmptyItem_ReturnZero()
        {
            var order = new Order(1, new OrderItem[0]);
            Assert.Equal(0, order.TotalCount);
        }

        [Fact]
        public void TotalPrice_WithEmptyItem_ReturnZero()
        {
            var order = new Order(1, new OrderItem[0]);
            Assert.Equal(0m, order.TotalPrice);
        }

        [Fact]
        public void TotalCount_WithEmptyItem_CalculatesTotalCount()
        {
            var order = new Order(1, new[]
            {
                new OrderItem(1, 3, 10m),
                new OrderItem(2, 5, 100m)
            });
            Assert.Equal(3 + 5, order.TotalCount);
        }

        [Fact]
        public void TotalPrice_WithEmptyItem_CalculatesTotalCount()
        {
            var order = new Order(1, new[]
            {
                new OrderItem(1, 3, 10m),
                new OrderItem(2, 5, 100m)
            });
            Assert.Equal(3 * 10m + 5 * 100m, order.TotalPrice);
        }

        [Fact]
        public void GetExistingItem_ReturnItem()
        {
            var order = new Order(1, new[]
           {
                new OrderItem(1, 3, 10m),
                new OrderItem(2, 5, 100m)
            });

            var orderItem = order.GetItem(1);
            Assert.Equal(3, orderItem.Count);
        }

        [Fact]
        public void GetNonExistingItem_TrowsInvalidOperationException()
        {
            var order = new Order(1, new[]
           {
                new OrderItem(1, 3, 10m),
                new OrderItem(2, 5, 100m)
            });

            Assert.Throws<InvalidOperationException>(() => order.GetItem(4));
        }

        [Fact]
        public void AddOrUpdateItem_WithExistingItem_UpdatesCount()
        {
            var order = new Order(1, new[]
       {
                new OrderItem(1, 3, 10m),
                new OrderItem(2, 5, 100m)
            });

            var book = new Book(1, "", "", "", "", 0m);

            order.AddOrUpdateItem(book, 10);

            Assert.Equal(13, order.GetItem(1).Count);
        }

        [Fact]
        public void AddOrUpdateItem_WithNonExistingItem_UpdatesCount()
        {
            var order = new Order(1, new[]
            {
                new OrderItem(1, 3, 10m),
                new OrderItem(2, 5, 100m)
            });

            var book = new Book(10, "", "", "", "", 0m);

            order.AddOrUpdateItem(book, 10);

            Assert.Equal(10, order.GetItem(10).Count);
        }

        [Fact]
        public void RemoveItem_WithExistingItem_RemovesItem()
        {
            var order = new Order(1, new[]
            {
                new OrderItem(1, 3, 10m),
                new OrderItem(2, 5, 100m)
            });

            order.RemoveItem(1);

            Assert.Equal(1, order.Items.Count);
        }

        [Fact]
        public void RemoveItem_WithNonExistingItem_ThrowsInvalidOperationException()
        {
            var order = new Order(1, new[]
            {
                new OrderItem(1, 3, 10m),
                new OrderItem(2, 5, 100m)
            });

            Assert.Throws<InvalidOperationException>(() => order.RemoveItem(10));
        }
    }
}

