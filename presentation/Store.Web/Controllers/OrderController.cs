using Microsoft.AspNetCore.Mvc;
using Store.Web.Models;

namespace Store.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly IOrderRepository _orderRepository;

        public OrderController(IBookRepository bookRepository, IOrderRepository orderRepository)
        {
            _bookRepository = bookRepository;
            _orderRepository = orderRepository;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.TryGetCart(out Cart cart))
            {
                var order = _orderRepository.GetById(cart.OrderId);
                var model = Map(order);

                return View(model);
            }

            return View("Empty");
        }


        public IActionResult AddItem(int bookID, int count = 1)

        {
            (Order order, Cart cart) = GetOrCreateOrderAndCart();

            var book = _bookRepository.GetById(bookID);

            order.AddOrUpdateItem(book, count);

            SaveOrderAndCart(order, cart);

            return RedirectToAction("Index", "Book", new { id = bookID });
        }

        [HttpPost]
        public IActionResult UpdateItem(int bookId, int count)
        {
            (Order order, Cart cart) = GetOrCreateOrderAndCart();

            order.GetItem(bookId).Count = count;
            SaveOrderAndCart(order, cart);

            return RedirectToAction("Index", "Order");
        }

        public IActionResult RemoveItem(int bookId)
        {
            (Order order, Cart cart) = GetOrCreateOrderAndCart();
            order.RemoveItem(bookId);
            SaveOrderAndCart(order, cart);

            return RedirectToAction("Index", "Order");
        }

        private OrderModel Map(Order order)
        {
            var bookIds = order.Items.Select(item => item.BookId);
            var books = _bookRepository.GetAllByIds(bookIds);
            var itemsModels = from item in order.Items
                              join book in books on item.BookId equals book.Id
                              select new OrderItemModel
                              {
                                  BookId = book.Id,
                                  Title = book.Title,
                                  Author = book.Author,
                                  Price = item.Price,
                                  Count = item.Count,

                              };
            return new OrderModel
            {
                Id = order.Id,
                Items = itemsModels.ToArray(),
                TotalCount = order.TotalCount,
                TotalPrice = order.TotalPrice,
            };
        }

        private (Order order, Cart cart) GetOrCreateOrderAndCart()
        {
            Order order;
            if (HttpContext.Session.TryGetCart(out Cart cart))
                order = _orderRepository.GetById(cart.OrderId);
            else
            {
                order = _orderRepository.Create();
                cart = new Cart(order.Id);
            }

            return (order, cart);

        }

        private void SaveOrderAndCart(Order order, Cart cart)
        {
            _orderRepository.Update(order);

            cart.TotalCount = order.TotalCount;
            cart.TotalPrice = order.TotalPrice;

            HttpContext.Session.Set(cart);
        }
    }
}
